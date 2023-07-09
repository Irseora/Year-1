using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Particule
{
    public class MyGraphics
    {
        Bitmap bmp;
        public Graphics g;
        PictureBox display;
        Color bgColor = Color.AliceBlue;
        public int resX, resY;

        // ---------------------------------------------
        // METHODS

        public void InitGraphics(PictureBox display)
        {
            this.display = display;
            this.bmp = new Bitmap(display.Width, display.Height);
            g = Graphics.FromImage(bmp);

            resX = display.Width;
            resY = display.Height;

            Clear();
            Refresh();
        }

        public void Refresh()
        {
            display.Image = bmp;
        }

        public void Clear()
        {
            g.Clear(bgColor);
        }
    }
}
