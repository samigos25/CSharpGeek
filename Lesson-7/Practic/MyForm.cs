using System;
using System.Drawing;
using System.Windows.Forms;

namespace Practic
{
    class MyForm : Form
    {
        static int  countPaint = 0;
        public MyForm()
        {
            Text = "My Inherited Form";
            Width *= 2;
            Click += MyClicker;
            Paint += MyPainter;
        }

        void MyClicker(object objSrc, EventArgs args)
        {
            MessageBox.Show("The button has been clicked!", "Click");
        }

        void MyPainter(object objSrc, PaintEventArgs args)
        {
            Graphics grfx = args.Graphics;
            countPaint++;
            grfx.DrawString($"Hello, Windows Forms {countPaint}", Font,
                SystemBrushes.ControlText, 0, 0);
        }
    }
}