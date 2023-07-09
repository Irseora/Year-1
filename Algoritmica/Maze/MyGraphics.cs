using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Maze
{
    public class MyGraphics
    {
        PictureBox display;
        Bitmap bmp;
        public Graphics grp;
        Color bkColor = Color.RosyBrown;
        public int resX, resY;
        
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
