using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Curs6
{
    public class MyGraphics
    {
        Bitmap bmp;
        public Graphics g;
        PictureBox display;
        Color bgColor = Color.LightGreen;
        public int resX, resY;

        public MyGraphics(PictureBox display)
        {
            this.display = display;
            bmp = new Bitmap(display.Width, display.Height);
            g = Graphics.FromImage(bmp);

            resX = display.Width;
            resY = display.Height;
        }

        // ---------------------------------------------

        public void Refresh()
        {
            display.Image = bmp;
        }

        public void Clear()
        {
            g.Clear(bgColor);
        }

        // ---------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poligon"></param>
        /// <param name="translation"></param>
        /// <returns></returns>
        public Poligon Translate(Poligon poligon, PointF translation)
        {
            Matrix C = new Matrix(poligon.length, translation);

            Matrix P = poligon.PoligonToMatrix();

            Matrix T = P + C;
            return T.MatrixToPoligon();
        }

        public Poligon Scale(Poligon poligon, float factorX, float factorY)
        {
            Matrix M = new Matrix(2, 2);
            M.mat[0, 0] = factorX;
            M.mat[0, 1] = 0;
            M.mat[1, 0] = 0;
            M.mat[1, 1] = factorY;

            Matrix P = poligon.PoligonToMatrix();

            Matrix S = M * P;
            return S.MatrixToPoligon();
        }

        public Poligon Rotate(Poligon poligon, float angle, PointF center) 
        {
            Matrix M = new Matrix(2, 2);
            M.mat[0, 0] = (float)Math.Cos(angle);
            M.mat[0, 1] = -(float)Math.Sin(angle);
            M.mat[1, 0] = (float)Math.Sin(angle);
            M.mat[1, 1] = (float)Math.Cos(angle);

            Matrix P = poligon.PoligonToMatrix();
            Matrix C = new Matrix(poligon.length, center);

            Matrix R = M * (P - C) + C;
            return R.MatrixToPoligon();
        }
    }
}
