using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftAccountsManager;
public static class ControlHelper
{
    public static Point FindMiddle(Control ownControl, Control memControl, bool x, bool y) => new Point(x ? ownControl.Width / 2 - memControl.Width / 2 : memControl.Location.X, y ? ownControl.Height / 2 - memControl.Height / 2 : memControl.Location.Y);
    public static void Round(this Control control, int radius, bool topRight = true, bool topLeft = true, bool bottomLeft = true, bool bottomRight = true)
    {
        try
        {
            using (var path = new GraphicsPath())
            {
                if (topRight)
                {
                    path.AddLine(radius, 0, control.Width - radius, 0);
                    path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
                }
                else
                    path.AddLine(0, 0, control.Width, 0);
                if (bottomRight)
                {
                    path.AddLine(control.Width, radius, control.Width, control.Height - radius);
                    path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
                }
                else
                    path.AddLine(control.Width, 0, control.Width, control.Height);
                if (bottomLeft)
                {
                    path.AddLine(control.Width - radius, control.Height, radius, control.Height);
                    path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
                }
                else
                    path.AddLine(control.Width, control.Height, 0, control.Height);
                if (topLeft)
                {
                    path.AddLine(0, control.Height - radius, 0, radius);
                    path.AddArc(0, 0, radius, radius, 180, 90);
                }
                else
                    path.AddLine(0, control.Height, 0, 0);
                control.Region = new Region(path);
            }
        }
        catch (Exception e) { Console.WriteLine("При прорисовке элемента: " + control.Name + " Произошла ошибка: " + e); }
    }
    public static GraphicsPath GetRoundPath(Size bounds, int radius, bool topRight = true, bool topLeft = true, bool bottomLeft = true, bool bottomRight = true)
    {
        var path = new GraphicsPath();
        if (topRight)
        {
            path.AddLine(radius, 0, bounds.Width - radius, 0);
            path.AddArc(bounds.Width - radius, 0, radius, radius, 270, 90);
        }
        else
            path.AddLine(0, 0, bounds.Width, 0);
        if (bottomRight)
        {
            path.AddLine(bounds.Width, radius, bounds.Width, bounds.Height - radius);
            path.AddArc(bounds.Width - radius, bounds.Height - radius, radius, radius, 0, 90);
        }
        else
            path.AddLine(bounds.Width, 0, bounds.Width, bounds.Height);
        if (bottomLeft)
        {
            path.AddLine(bounds.Width - radius, bounds.Height, radius, bounds.Height);
            path.AddArc(0, bounds.Height - radius, radius, radius, 90, 90);
        }
        else
            path.AddLine(bounds.Width, bounds.Height, 0, bounds.Height);
        if (topLeft)
        {
            path.AddLine(0, bounds.Height - radius, 0, radius);
            path.AddArc(0, 0, radius, radius, 180, 90);
        }
        else
            path.AddLine(0, bounds.Height, 0, 0);
        return path;
    }
    public static void DrawBorder(Control control, Color color) => ControlPaint.DrawBorder(control.CreateGraphics(), control.ClientRectangle, color, ButtonBorderStyle.Solid);
    public static IEnumerable<Control> GetControls(Control control, params Type[] type)
    {
        var controls = control.Controls.Cast<Control>();
        return controls.Cast<Control>().SelectMany(x => GetControls(x, type)).Concat(controls).Where(c => type.Contains(c.GetType()));
    }
    public static string SplitStringAsString(Font font, int minLength, int maxLength, string input)
    {
        Graphics g = Graphics.FromImage(new Bitmap(1, 1));
        StringBuilder result = new StringBuilder();
        int spaceLength = g.MeasureString("                ", font).ToSize().Width / 16,
            splitLength = g.MeasureString("----------------", font).ToSize().Width / 16;
        int curLength = 0;
        foreach (string word in input.Split(' '))
        {
            int lengthWord = g.MeasureString(word, font).ToSize().Width;
            if (curLength + lengthWord >= maxLength)
            {
                if (curLength >= minLength - splitLength)
                {
                    result.Append('\n').Append(word).Append(' ');
                    curLength = lengthWord + spaceLength;
                }
                else
                {
                    for (int i = 0; i < word.Length; i++)
                    {
                        int sequenceLength = g.MeasureString(word.Substring(0, i + 1), font).ToSize().Width;
                        if (curLength + splitLength + sequenceLength > maxLength)
                        {
                            result.Append(word.Substring(0, i + 1)).Append('-').Append('\n').Append(word.Substring(i + 1)).Append(' ');
                            curLength = g.MeasureString(word.Substring(i) + " ", font).ToSize().Width;
                            break;
                        }
                    }
                }
            }
            else
            {
                result.Append(word).Append(' ');
                curLength += lengthWord + spaceLength;
            }
        }
        return result.Append('\n').ToString();
    }
}