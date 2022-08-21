using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinecraftAccountsManager.Forms;
public partial class ChangeAccountForm : Form
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
}
