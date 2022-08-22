public sealed partial class MainWindow : Form
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
    #endregion
    public MainWindow()
    {
        InitializeComponent();
        AllowTransparency = true;
        Wrapper.LoadAccounts();
        ReloadAccountPanel();
    }
    private bool collapsed;
    private AddAccountForm addAccountForm = new AddAccountForm();
    private ExitConfirm exitConfirmForm = new ExitConfirm();
    private void CloseB_Click(object sender, EventArgs e)
    {
        if(exitConfirmForm.ShowDialog() == DialogResult.OK)
            Environment.Exit(0);
    }
    private void AddAccountB_Click(object sender, EventArgs e)
    {
        if(addAccountForm.ShowDialog() == DialogResult.OK)
        {
            Account account = new Account(addAccountForm.NameTB.Text, addAccountForm.EmailTB.Text, addAccountForm.PasswordTB.Text, MojangAPI.GetUUID(addAccountForm.NameTB.Text), MojangAPI.PrepairAccessToken(addAccountForm.AccessTokenTB.Text));
            Wrapper.Accounts.Add(account);
            Wrapper.SaveAccounts();
            ReloadAccountPanel();
            addAccountForm = new AddAccountForm();
        }
    }
    public void ReloadAccountPanel()
    {
        ControlHelper.GetControls(this, typeof(Panel), typeof(Label), typeof(PictureBox), typeof(AccountPanel)).Concat(new Control[] { this }).ToList().ForEach(z => z.MouseDown -= MouseDownRelocate);
        AccountsP.Controls.Clear();
        int index = 0;
        Wrapper.Accounts.ForEach(z =>
        {
            AccountsP.Controls.Add(z.Panel);
            z.Panel.Location = new Point(0, index * 36);
            index++;
        });
        ControlHelper.GetControls(this, typeof(Panel), typeof(Label), typeof(PictureBox), typeof(AccountPanel)).Concat(new Control[] { this }).ToList().ForEach(z => z.MouseDown += MouseDownRelocate);
        int height = index * 36;
        int width = Math.Max(100, Wrapper.Accounts.Count > 0 ? Wrapper.Accounts.Select(z => z.Panel.Size.Width).Max() : 300);
        AccountsP.Size = new Size(width, height);
        Size = new Size(width, height + 20);
    }
    private void CollapseB_Click(object sender, EventArgs e)
    {
        CollapseB.Text = (collapsed = TopMost = !collapsed) ? "卐" : "卍";
        CollapseB.BackColor = CollapseB.FlatAppearance.MouseOverBackColor = CollapseB.FlatAppearance.MouseDownBackColor = (collapsed ? Color.FromArgb(47, 67, 47) : Color.FromArgb(67, 47, 47));
    }
}