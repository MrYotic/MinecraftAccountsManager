using MinecraftAccountsManager.Forms;

namespace MinecraftAccountsManager;

public partial class MainWindow : Form
{
    #region Hood
    public void MouseDownRelocate(object sender, MouseEventArgs e)
    {
        if (e.Button.Equals(MouseButtons.Left))
        {
            ((Control)sender).Capture = false;
            var m = Message.Create(Handle, 0xa1, new IntPtr(0x2), IntPtr.Zero);
            WndProc(ref m);
        }
    }
    private static IEnumerable<Control> GetControls(Control control, params Type[] types)
    {
        var controls = control.Controls.Cast<Control>();
        return controls.Cast<Control>().SelectMany(x => GetControls(x, types)).Concat(controls).Where(c => types.Contains(c.GetType()));
    }
    #endregion
    public MainWindow()
    {
        InitializeComponent();
        AllowTransparency = true;
        Wrapper.LoadAccounts();
        ReloadAccountPanel();
    }
    private bool collapsed;
    private AddAccountForm form = new AddAccountForm();
    private void CloseB_Click(object sender, EventArgs e) => Environment.Exit(0);
    private void AddAccountB_Click(object sender, EventArgs e)
    {
        if(form.ShowDialog() == DialogResult.OK)
        {
            Account account = new Account(form.NameTB.Text, form.EmailTB.Text, form.PasswordTB.Text, MojangAPI.GetUUID(form.NameTB.Text), MojangAPI.PrepairAccessToken(form.AccessTokenTB.Text));
            Wrapper.Accounts.Add(account);
            Wrapper.SaveAccounts();
            ReloadAccountPanel();
            form = new AddAccountForm();
        }
    }
    public void ReloadAccountPanel()
    {
        GetControls(this, typeof(Panel), typeof(Label), typeof(PictureBox), typeof(AccountPanel)).Concat(new Control[] { this }).ToList().ForEach(z => z.MouseDown -= MouseDownRelocate);
        AccountsP.Controls.Clear();
        int index = 0;
        Wrapper.Accounts.ForEach(z =>
        {
            AccountsP.Controls.Add(z.Panel);
            z.Panel.Location = new Point(0, index * 36);
            index++;
        });
        GetControls(this, typeof(Panel), typeof(Label), typeof(PictureBox), typeof(AccountPanel)).Concat(new Control[] { this }).ToList().ForEach(z => z.MouseDown += MouseDownRelocate);
        int height = index * 36;
        AccountsP.Size = new Size(600, height);
        Size = new Size(600, height + 20);
    }
    private void CollapseB_Click(object sender, EventArgs e)
    {
        if (collapsed) CollapseB.Text = "卍";
        else CollapseB.Text = "卐";
        collapsed = TopMost = !collapsed;
        CollapseB.BackColor = CollapseB.FlatAppearance.MouseOverBackColor = CollapseB.FlatAppearance.MouseDownBackColor = (collapsed ? Color.FromArgb(47, 67, 47) : Color.FromArgb(67, 47, 47));
    }
}