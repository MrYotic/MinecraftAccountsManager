using MinecraftAccountsManager.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MinecraftAccountsManager.Minecraft;

namespace MinecraftAccountsManager;
public partial class AccountPanel : UserControl
{
    #region DllImports
    [DllImport("user32.dll")] public static extern int FindWindow(string lpClassName, string lpWindowName);
    [DllImport("user32.dll")] public static extern bool SetForegroundWindow(IntPtr hWnd);
    [DllImport("user32.dll")] public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    #endregion
    public AccountPanel(Account account)
    {
        InitializeComponent();
        NameL.Text = account.Name;
        UUIDL.Text = account.UUID;
        this.account = account;
    }
    private void AccountPanel_Load(object sender, EventArgs e)
    {
        new Thread(() =>
        {
            while (account.SkinHead == null)
                Thread.Sleep(25);
            Bitmap head = new Bitmap(32, 32);
            for (int x = 0; x < 8; x++)
                for (int y = 0; y < 8; y++)
                {
                    int posX = x * 4;
                    int posY = y * 4;
                    Color pixel = ((Bitmap)account.SkinHead).GetPixel(x, y);
                    for (int ix = 0; ix < 4; ix++)
                        for (int iy = 0; iy < 4; iy++)
                            head.SetPixel(posX + ix, posY + iy, pixel);
                }
            Invoke(() => SkinHeadAvatarPB.Image = head);
        }).Start();
    }
    private Account account;
    public void OnChatReceive(string text)
    {
        if (!text.Contains('<') && text.Contains("Position in queue: "))
        {
            int queuePos = int.Parse(text.Split("Position in queue: ")[1].Split(@"\n")[0]);
            if (account.State == MinecraftState.InGame)
            {
                account.State = MinecraftState.InQueue;
                account.joinToQueue = DateTime.Now;
            }
            else if (account.State == MinecraftState.InQueue)
            {
                Invoke(() => StatusL.Text = MinecraftStringStates[account.State] + queuePos);
                account.queuePos = queuePos;
            }
        }
        else if (text.Where(z => z == '<' || z == '>').Count() >= 2)
        {
            if(account.State == MinecraftState.InQueue)
            {
                account.State = MinecraftState.On2B2T;
                account.queuePos = -1;
                account.joinToServer = DateTime.Now;
                HealthL.Visible = true;
                account.PipleLineThread = new Thread(() =>
                {
                    while(account.State == MinecraftState.On2B2T)
                    {
                        Thread.Sleep(500);
                        account.PipleLine.Seek(0, SeekOrigin.Begin);
                        byte[] buffer = new byte[account.PipleLine.Length];
                        account.PipleLine.Read(buffer, 0, buffer.Length);
                        string data = Encoding.UTF8.GetString(buffer);
                        string[] args = data.Split(' ');
                        int index = int.Parse(args[0]);
                        if(lastPipeLineIndex != index)
                        {
                            lastPipeLineIndex = index;
                            int health = (int)float.Parse(args[1]);
                            HealthL.Text = health.ToString();
                            HealthL.ForeColor = Color.FromArgb((byte)(255 - (12.75 * health)), (byte)(12.75 * health), 0);
                        }
                    }
                    Invoke(() => HealthL.Visible = false);
                });
                account.PipleLineThread.Start();
            }
            else if(account.State == MinecraftState.On2B2T)
            {
                Invoke(() => StatusL.Text = MinecraftStringStates[account.State] + Wrapper.TimeSpanToString(DateTime.Now - (DateTime)account.joinToServer));
            }
        }
    }
    private int lastPipeLineIndex = -1;
    public MinecraftState UpdateStatus()
    {
        MinecraftState state = UpdateState();
        account.State = state;
        StatusL.Text = MinecraftStringStates[state];
        return state;
    }
    public MinecraftState UpdateState()
    {
        if (account.State == MinecraftState.Launched)
        {
            account.Minecraft.MinecraftProcess = MinecraftProcess;
            ActiveWindowB.Enabled = true;
            LaunchB.Enabled = true;
            LaunchB.Text = "Close";
            return MinecraftState.InGame;
        }
        else if(account.State == MinecraftState.InGame || account.State == MinecraftState.InQueue || account.State == MinecraftState.On2B2T)
        {
            ActiveWindowB.Enabled = false;
            LaunchB.Enabled = true;
            LaunchB.Text = "Launch";
            account.Minecraft.ChatManager.OnChatReceive -= OnChatReceive;
            return MinecraftState.NotLaunched;
        }
        return account.State;
    }
    private bool ExistsMinecraftProcess => Process.GetProcesses().Where(z => z.MainWindowTitle.Contains(account.Name)).Count() != 0;
    private Process MinecraftProcess => Process.GetProcesses().Where(z => z.MainWindowTitle.Contains(account.Name)).FirstOrDefault();
    private void ActiveWindow_Click(object sender, EventArgs e)
    {
        bool exists = ExistsMinecraftProcess;
        if (exists)
        {
            IntPtr handle = MinecraftProcess.MainWindowHandle;
            ShowWindow(handle, 1);
            SetForegroundWindow(handle);
        }
    }
    private void LaunchB_Click(object sender, EventArgs e)
    {
        LaunchB.Enabled = false;
        if (account.State == MinecraftState.NotLaunched)
        {
            account.State = MinecraftState.Launched;
            StatusL.Text = MinecraftStringStates[account.State];
            account.Minecraft.Start();
            new Thread(() =>
            {
                int maxAttempt = 1000;
                int attempt = 0;
                while (!ExistsMinecraftProcess)
                {
                    Thread.Sleep(100);
                    attempt++;
                    if (attempt > maxAttempt)
                    {
                        Invoke(() => UpdateStatus());
                        return;
                    }
                }
                Invoke(() => UpdateStatus());
            }).Start();
        }
        else
        {
            account.Minecraft.Close();
            new Thread(() =>
            {
                Thread.Sleep(100);
                Invoke(() => UpdateStatus());
            }).Start();
        }
    }
    private void ChangeAccountB_Click(object sender, EventArgs e)
    {
        ChangeAccountForm form = new ChangeAccountForm();
        form.NameTB.Text = account.Name;
        form.EmailTB.Text = account.Email;
        form.PasswordTB.Text = account.Password;
        form.AccessTokenTB.Text = account.AccessToken;
        if (form.ShowDialog() == DialogResult.OK)
        {
            account.Name = form.NameTB.Text;
            account.Email = form.EmailTB.Text;
            account.Password = form.PasswordTB.Text;
            account.AccessToken = MojangAPI.PrepairAccessToken(form.AccessTokenTB.Text);
            account.UUID = MojangAPI.GetUUID(account.Name);
            account.Minecraft.Close();
            new Thread(() =>
            {
                Thread.Sleep(100);
                Invoke(() => UpdateStatus());
            }).Start();
            account.Minecraft = Wrapper.BootManager.NewMinecraft(account);
            Wrapper.SaveAccounts();
            Wrapper.MainWindow.ReloadAccountPanel();
        }
    }
}
