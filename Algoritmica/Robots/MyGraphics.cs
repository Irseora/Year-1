using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Robots
{
    public class MyGraphics
    {
        PictureBox display;
        Bitmap bmp;
        Color bkColor = Color.GhostWhite;

        public Graphics grp;
        public int resX, resY;

        // ---------------------------------------------

        public void InitGraphics(PictureBox display)
        {
            this.display = display;
            this.bmp = new Bitmap(display.Width, display.Height);
            grp = Graphics.FromImage(bmp);

            resX = display.Width;
            resY = display.Height;

            ClearGraphics();
            RefreshGraphics();
        }

        public void ClearGraphics()
        {
            grp.Clear(bkColor);
        }

        public void RefreshGraphics()
        {
            this.display.Image = bmp;
        }
    }
}
