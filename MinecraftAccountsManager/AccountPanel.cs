using MinecraftAccountsManager.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Reflection;
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
    private void ActiveWindow_Click(object sender, EventArgs e)
    {
        bool exists = account.Minecraft.ExistsMinecraftProcess;
        if (exists)
        {
            IntPtr handle = account.Minecraft.MinecraftProcess.MainWindowHandle;
            ShowWindow(handle, 0);
            SetForegroundWindow(handle);
        }
    }
    private void LaunchB_Click(object sender, EventArgs e)
    {
        LaunchB.Enabled = false;
        if (account.State == MinecraftState.NotLaunched)
        {
            UpdateStatus(MinecraftState.Launched);
            account.Minecraft.Start();
            new Thread(() =>
            {
                Thread.Sleep(1000);
                int maxattempt = 1000, attempt = 0;
                while(!account.Minecraft.ExistsMinecraftProcess)
                {                    
                    Thread.Sleep(100);
                    if (maxattempt < attempt++)
                        return;
                }
                Invoke(() =>
                {
                    LaunchB.Enabled = true;
                    LaunchB.Text = "Close";
                });
                account.JavaInputThread = new Thread(() =>
                {
                    while (account.Minecraft.ExistsMinecraftProcess && account.State != MinecraftState.NotLaunched)
                    {
                        try
                        {
                            string stringState = File.ReadAllText(Path.Combine(account.Minecraft.Root, "state.txt"));
                            if (stringState.StartsWith("InGame"))
                            {
                                if (account.State != MinecraftState.InGame)
                                {
                                    account.joinToServer = account.joinToQueue = null;
                                    UpdateStatus(MinecraftState.InGame);
                                    Invoke(() =>
                                    {
                                        ActiveWindowB.Enabled = true;
                                    });
                                }
                            }
                            else if (stringState.StartsWith("InQueue"))
                            {
                                if (account.State != MinecraftState.InQueue)
                                {
                                    account.joinToQueue = DateTime.Now;
                                    account.joinToServer = null;
                                    UpdateStatus(MinecraftState.InQueue);
                                }
                                account.queuePos = int.Parse(stringState.Split(' ')[^1]);
                                Invoke(() => StatusL.Text = "In Queue: " + account.queuePos);
                            }
                            else if (stringState.StartsWith("On2B2T"))
                            {
                                if (account.State != MinecraftState.On2B2T)
                                {
                                    account.joinToServer = DateTime.Now;
                                    account.joinToQueue = null;
                                    UpdateStatus(MinecraftState.On2B2T);
                                }
                                int health = Math.Min(int.Parse(File.ReadAllText(Path.Combine(account.Minecraft.Root, "pipeline.txt")).Split(' ')[4]) + 1, 20);
                                Invoke(() =>
                                {                                    
                                    HealthL.Text = health.ToString();
                                    HealthL.ForeColor = Color.FromArgb((byte)(255 - (12.75 * health)), (byte)(12.75 * health), 0);
                                });
                            }
                            if(account.State == MinecraftState.On2B2T)
                                Invoke(() => HealthL.Visible = true);
                            else Invoke(() => HealthL.Visible = false);
                        } catch { }
                    }
                });
                account.JavaInputThread.Start();
            }).Start();
        }
        else
        {
            account.Minecraft.Close();
            new Thread(() =>
            {
                UpdateStatus(MinecraftState.NotLaunched);
                Invoke(() =>
                {
                    LaunchB.Enabled = true;
                    LaunchB.Text = "Launch";
                    ActiveWindowB.Enabled = false;
                });
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
            
            account.Minecraft = Wrapper.BootManager.NewMinecraft(account);
            Wrapper.SaveAccounts();
            Wrapper.MainWindow.ReloadAccountPanel();
        }
    }
    public void UpdateStatus(MinecraftState state) => Invoke(() => StatusL.Text = MinecraftStringStates[account.State = state]);
}
