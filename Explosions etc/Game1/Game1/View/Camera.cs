using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace View
{
    class Camera
    {
        private int fieldsize;
        int width;
        int height;
        float scale;
        public void SetFieldSize(Viewport board) //If width is bigger than height use it for scaling, otherwhise the other way around
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

        public Vector2 Converttovisualcoords(Vector2 coords, float width,float height,float scale) //gamecoords to visualcoords
        {
            float visualX = coords.X * fieldsize - (width / 2) * scale;
            float visualY = coords.Y * fieldsize - (height / 2) * scale;
            return new Vector2(visualX, visualY);
        }

        public float Scale(float size,float width) //scales the particle
        {
            return scale = fieldsize * size / width;

        }
    }
}
