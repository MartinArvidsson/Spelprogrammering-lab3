using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameExplosion
{
    class Camera
    {
        private int fieldsize;
        int width;
        int height;
        public void setFieldSize(Viewport board) //If width is bigger than height use it for scaling, otherwhise the other way around
        {
            width = board.Width;
            height = board.Height;

            if (width < height)
            {
                fieldsize = width;
            }
            else
            {
                fieldsize = height;
            }
        }

        public Vector2 Converttovisualcoords(Vector2 coords, int explosionheight,int explosionwidth) //gamecoords to visualcoords
        {
            float visualX = (coords.X * fieldsize) - (explosionwidth / 2);
            float visualY = (coords.Y * fieldsize) - (explosionheight / 2);
            return new Vector2(visualX, visualY);
        }
    }
}
