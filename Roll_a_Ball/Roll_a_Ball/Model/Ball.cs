using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Roll_a_Ball.Model
{
    class Ball
    {
        private Vector2 BallPos;
        private Vector2 BallSpeed = new Vector2(0.05f,0.05f);
        private float Ballradius = 0.05f;

        public Ball()
        {
            Random random = new Random();

        }


    }
}
