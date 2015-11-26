using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class Camera
    {
        int height;
        int width;
        int scale;
        int fieldsize;

        private Vector2 offset;

        public void setFieldSize(Viewport graphics)
        {
            width = graphics.Width;
            height = graphics.Height;

            if (width < height)
            {
                fieldsize = width;
                offset.Y = (width - fieldsize) / 2;
            }
            else
            {
                fieldsize = height;
                offset.X = (height - fieldsize) / 2;
            }
        }

        public Vector2 convertToVisualCoords(Vector2 coordinates,float sparkwidth,float sparkheight)
        {
            float VisualX = coordinates.X * fieldsize - (sparkwidth / 2) * scale + offset.X;
            float VisualY = coordinates.Y * fieldsize - (sparkheight / 2) * scale + offset.Y;

            return new Vector2(VisualX, VisualY);
        }

        public void scalegame()
        {

        }
    }
}
