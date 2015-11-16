using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Roll_a_Ball.View
{
    class Camera
    {
        int height;
        int width;
        int scaleheight;
        int scalewidth;
        int scale;
        int size = 1;
        private int bordersize = 15;

        public Camera(Viewport graphics)
        {
            width = graphics.Width - bordersize * 2;
            height = graphics.Height - bordersize * 2;

            if (height < width)
            {
                width = height;
            }
            else
            {
                height = width;
            }

            scale = width / size; 
        }
        
        public Vector2 getCoordinates(float X,float Y)
        {
            return new Vector2(0, 0);
        }

        public Rectangle getGame()
        {
            return new Rectangle((int)bordersize, (int)bordersize, (int)width, (int)height);
        }
    }
}
