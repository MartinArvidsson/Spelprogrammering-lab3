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
        private int width;
        private int height;
        private float scale;
        private int border = 20;
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
            fieldsize = fieldsize - (border * 2);
        }

        public Vector2 Converttovisualcoords(Vector2 coords, float width,float height,float scale) //gamecoords to visualcoords
        {
            float visualX = coords.X * fieldsize - (width / 2) * scale;
            float visualY = coords.Y * fieldsize - (height / 2) * scale;
            
            return new Vector2(visualX, visualY);
        }

        public Vector2 ConvertMouseToLogical(Vector2 Mousecoords)
        {
            float VisualX = (Mousecoords.X/ fieldsize);// -(width / 2) * scale;
            float VisualY = (Mousecoords.Y/ fieldsize);// -(height / 2) * scale;

            return new Vector2(VisualX, VisualY);
        }

        public float Scale(float size,float width) //scales the particle
        {
            return scale = fieldsize * size / width;

        }

        public int ReturnFieldsize()
        {
            return fieldsize;
        }

        public int ReturnBorder()
        {
            return border;
        }
    }
}
