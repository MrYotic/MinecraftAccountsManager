public sealed partial class ChangeAccountForm : Form
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
    public ChangeAccountForm()
    {
        InitializeComponent();
        ControlHelper.GetControls(this, typeof(Panel), typeof(Label), typeof(PictureBox), typeof(AccountPanel)).Concat(new Control[] { this }).ToList().ForEach(z => z.MouseDown += MouseDownRelocate);
    }
    public ChangeAccountForm(Account account) : this()
    {
        NameTB.Text = account.Name;
        EmailTB.Text = account.Email;
        PasswordTB.Text = account.Password;
        AccessTokenTB.Text = account.AccessToken;
    }
    public void ToAccount(ref Account account)
    {
        account.Name = NameTB.Text;
        account.Email = EmailTB.Text;
        account.Password = PasswordTB.Text;
        account.AccessToken = MojangAPI.PrepairAccessToken(AccessTokenTB.Text);
        account.UUID = MojangAPI.GetUUID(account.Name);
        account.Minecraft.Close();
        account.Minecraft = Wrapper.BootManager.NewMinecraft(account);
    }
}
