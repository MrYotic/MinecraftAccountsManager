using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace MinecraftAccountsManager;
//this class from other project (DH - DooDHack).
public partial class DHToolTips : ToolTip
{
    private Dictionary<Control, (string caption, Size size)> AssociatedControls = new Dictionary<Control, (string caption, Size size)>();
    private Font font;
    public Font Font { get => font; set {
        font = value;
        AssociatedControls = AssociatedControls.ToList().Select(z => (z.Key, (z.Value.caption, Graphics.FromImage(new Bitmap(1, 1)).MeasureString(z.Value.caption, Font).ToSize()))).ToDictionary(z => z.Key, z => z.Item2);
    }}
    public DHToolTips(Font font)
    {
        this.font = font;
        InitializeComponent();
        OwnerDraw = true;
        UseFading = true;
        this.UseAnimation = true;
        Draw += OnDraw;
        Popup += OnPopup;
    }
    private void OnPopup(object sender, PopupEventArgs e)
    {
        e.ToolTipSize = AssociatedControls.ContainsKey(e.AssociatedControl) ? AssociatedControls[e.AssociatedControl].size : new Size(200, 100);
    }
    private void OnDraw(object sender, DrawToolTipEventArgs e)
    { 
        Graphics g = e.Graphics;
        LinearGradientBrush b = new LinearGradientBrush(e.Bounds, Color.FromArgb(57, 57, 57), Color.FromArgb(60, 60, 60), 45f);
        e.DrawBackground();
        g.FillRectangle(new SolidBrush(Color.FromArgb(70, 70, 70)), e.Bounds);
        g.DrawRectangle(new Pen(Color.FromArgb(80, 80, 80)), new Rectangle(e.Bounds.X, e.Bounds.X, e.Bounds.Width - 1, e.Bounds.Height - 1));
        string caption = AssociatedControls.ContainsKey(e.AssociatedControl) ? AssociatedControls[e.AssociatedControl].caption : e.ToolTipText;
        //g.DrawString(caption, font, new SolidBrush(Color.FromArgb(80, Color.Silver.R, Color.Silver.G, Color.Silver.B)), new PointF(e.Bounds.X + 3, e.Bounds.Y + 3)); // shadow layer
        g.DrawString(caption, font, Brushes.Silver, new PointF(e.Bounds.X + 2, e.Bounds.Y + 2)); // top layer
        b.Dispose();
    }
    public void SetDHToolTip(Control control, string text)
    {
        SetToolTip(control, text != "" ? "." : "");
        //string caption = ControlHelper.SplitStringAsString(Font, 470, 500, text);
        Size captionSize = Graphics.FromImage(new Bitmap(1, 1)).MeasureString(text, Font).ToSize();
        AssociatedControls[control] = (text, new Size(captionSize.Width + 5, captionSize.Height + 5));
    }
}
