using MinecraftAccountsManager.Forms;
using System.Runtime.InteropServices;
using static MinecraftAccountsManager.Minecraft;

namespace MinecraftAccountsManager;
public sealed partial class AccountPanel : UserControl
{
    #region DllImports
    [DllImport("user32.dll")] public static extern int FindWindow(string lpClassName, string lpWindowName);
    [DllImport("user32.dll")] public static extern bool SetForegroundWindow(IntPtr hWnd);
    [DllImport("user32.dll")] public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    public static void FocusWindow(IntPtr hWnd)
    {
        ShowWindow(hWnd, 4);
        SetForegroundWindow(hWnd);
    }
    #endregion
    public AccountPanel(Account account)
    {
        InitializeComponent();
        NameL.Text = account.Name;
        this.account = account;
        AutoResizePanel();
        toolTips = new DHToolTips(Font);
    }
    private DHToolTips toolTips;
    private Account account;
    private Player lastPlayer;
    private string AccountToolTipCaption => account.Name + '\n' +
        $"Dimension: {Dimensions[account.Player.Dimension]}\n" +
        $"Coord: {account.Player.X} {account.Player.Y} {account.Player.Z}\n" +
        (account.Player.Dimension == 0 ? $"Nether Coord: {account.Player.X / 8} {account.Player.Y} {account.Player.Z / 8}\n" : "") +
        $"Health: {account.Player.Health}    Food: {account.Player.Food}";
    #region Form Events
    private void AccountPanel_Load(object sender, EventArgs e)
    {
        new Thread(() =>
        {
            while (account.SkinHead == null)
                Thread.Sleep(25);
            Bitmap head = new Bitmap(32, 32);
            #region Scale Image
            // Fuck Graphics.
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
            #endregion
            Invoke(() => SkinHeadAvatarPB.Image = head);
        }).Start();
        if (account.Minecraft.ExistsMinecraftProcess)
        {
            account.State = MinecraftState.InGame;
            StatusL.Text = MinecraftStringStates[account.State];
            LaunchB.Enabled = true;
            LaunchB.Text = "Close";
            ActiveWindowB.Enabled = true;
            account.JavaInputThread = new Thread(() =>
            {
                while (account.Minecraft.ExistsMinecraftProcess && account.State != MinecraftState.NotLaunched)
                    Update();
            });
            account.JavaInputThread.Start();
        }
    }
    private void ChangeAccountB_Click(object sender, EventArgs e)
    {
        ChangeAccountForm form = new ChangeAccountForm(account);
        if (form.ShowDialog() != DialogResult.OK)
            return;
        form.ToAccount(ref account);
        Wrapper.SaveAccounts();
        Wrapper.MainWindow.ReloadAccountPanel();
    }
    private void ActiveWindow_Click(object sender, EventArgs e) => FocusWindow(account.Minecraft.MinecraftProcess.MainWindowHandle);
    private void LaunchB_Click(object sender, EventArgs e)
    {
        LaunchB.Enabled = false;
        if (account.State == MinecraftState.NotLaunched)
        {
            new Thread(() =>
            {
                Thread.Sleep(1000);
                int maxattempt = 1000, attempt = 0;
                while (!account.Minecraft.ExistsMinecraftProcess)
                {
                    Thread.Sleep(100);
                    if (maxattempt < attempt++)
                        return;
                }
                StartMinecraft();
            }).Start();
        }
        else CloseMinecraft();
    }
    #endregion
    #region Methods
    private void AutoResizePanel()
    {
        int startWidth = NameL.Location.X + NameL.Size.Width + 24;
        ChangeAccountB.Location = new Point(startWidth, 4);
        startWidth += ChangeAccountB.Width + 2;
        LaunchB.Location = new Point(startWidth, 4);
        startWidth += LaunchB.Width + 2;
        ActiveWindowB.Location = new Point(startWidth, 4);
        startWidth += ActiveWindowB.Width + 4;
        Size = new Size(startWidth, 36);
    }
    private void StartMinecraft()
    {
        UpdateStatus(MinecraftState.Launched);
        account.Minecraft.Start();
        Invoke(() =>
        {
            LaunchB.Enabled = true;
            LaunchB.Text = "Close";
        });
        account.JavaInputThread = new Thread(() =>
        {
            while (account.Minecraft.ExistsMinecraftProcess && account.State != MinecraftState.NotLaunched)
                Update();
        });
        account.JavaInputThread.Start();
    }
    private void CloseMinecraft()
    {
        UpdateStatus(MinecraftState.NotLaunched);
        account.Minecraft.Close();
        new Thread(() =>
        {
            Invoke(() =>
            {
                LaunchB.Enabled = true;
                LaunchB.Text = "Launch";
                ActiveWindowB.Enabled = HealthL.Visible = false;
            });
        }).Start();
    }
    private void Update()
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
                Invoke(() => StatusL.Text = $"q: {account.queuePos} ({Wrapper.TimeSpanToString(DateTime.Now - (DateTime)account.joinToQueue)})");
            }
            else if (stringState.StartsWith("On2B2T"))
            {
                if (account.State != MinecraftState.On2B2T)
                {
                    account.joinToServer = DateTime.Now;
                    account.joinToQueue = null;
                    UpdateStatus(MinecraftState.On2B2T);
                }
                int[] pipelineArgs = File.ReadAllText(Path.Combine(account.Minecraft.Root, "pipeline.txt")).Split(' ').Take(6).Select(int.Parse).ToArray();
                account.Player = new Player(pipelineArgs[0], pipelineArgs[1], pipelineArgs[2], pipelineArgs[3], Math.Min(pipelineArgs[4] + 1, 20), pipelineArgs[5]);
                Invoke(() =>
                {
                    HealthL.Text = $"[{account.Player.Health}]";
                    HealthL.ForeColor = Color.FromArgb((byte)(255 - (12.75 * account.Player.Health)), (byte)(12.75 * account.Player.Health), 0);
                    HealthL.Location = new Point(NameL.Location.X + NameL.Size.Width, 2);
                    StatusL.Text = $"On 2B2T ({Wrapper.TimeSpanToString(DateTime.Now - (DateTime)account.joinToServer)})";
                    if (!account.Player.Equals(lastPlayer))
                    {
                        string caption = AccountToolTipCaption;
                        toolTips.SetDHToolTip(NameL, caption);
                        toolTips.SetDHToolTip(SkinHeadAvatarPB, caption);
                        lastPlayer = account.Player;
                    }
                });
            }
            if (account.State == MinecraftState.On2B2T)
                Invoke(() => HealthL.Visible = true);
            else
            {
                Invoke(() =>
                {
                    HealthL.Visible = false;
                    toolTips.SetDHToolTip(NameL, "");
                    toolTips.SetDHToolTip(SkinHeadAvatarPB, "");
                });
            }
        } catch { }
        Thread.Sleep(1000);
    }
    public void UpdateStatus(MinecraftState state) => Invoke(() => StatusL.Text = MinecraftStringStates[account.State = state]);
    #endregion
}