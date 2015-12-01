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
        int scale;
        int size = 1;
        private int bordersize = 15;


        //Decides if we want to create the scale depending on width of window or height
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
        
        //Returns the coordinates to create the playable board on, starts on 0-0 upper left corner
        public Vector2 getCoordinates(float X,float Y)
        {
            return new Vector2(0, 0);
        }

        //Returns the Rectangle that will act as the playable board, in which the ball will bounce around
        public Rectangle getGame()
        {
            return new Rectangle((int)bordersize, (int)bordersize, (int)width, (int)height);
        }

        //Scales down the ball to a playable size
        public float ScaledBallsize(float Ballsize,float size)
        {
            float normalsize = width / Ballsize;
            float scaledball = normalsize * size;
            return scaledball;
        }

        //New ballposition on the board.
        public Vector2 newboardpos(float x, float y)
        {
            float visualX = bordersize + x * scale;
            float visualY = bordersize + y * scale;

            return new Vector2(visualX, visualY);
        }
    }
}
