using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Of_Life
{
    public class MyGraphics
    {
        Bitmap bmp;
        public Graphics grp;
        PictureBox display;
        public Color bgColor = Color.AliceBlue;

        // -------------------------------------------------------------

        public int resX { get { return display.Height; } }
        public int resY { get { return display.Width; } }

        // --------------------------------------------------------------
        // METHODS

        public void InitGraphics(PictureBox display)
        {
            this.display = display;
            this.bmp = new Bitmap(display.Width, display.Height);
            grp = Graphics.FromImage(bmp);

            Clear();
            Refresh();
        }

        public void Refresh()
        {
            display.Image = bmp;
        }

        public void Clear()
        {
            grp.Clear(bgColor);
        }
    }
}
