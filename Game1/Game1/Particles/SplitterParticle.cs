using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Game1
{
    class SplitterParticle
    {

        public Vector2 randomDirection;
        public float maximumspeed = 0.5f;
        public Vector2 startpos = new Vector2(0.5f, 0.5f); //Startpos.
        public Vector2 velocity;
        public Vector2 acceleration = new Vector2(0.0f, 0.7f);

        public SplitterParticle(Texture2D spark,Random random)
        {

            Vector2 randomDirection = new Vector2((float)random.NextDouble() - 0.5f, (float)random.NextDouble() - 0.5f);
            //normalize to get it spherical vector with length 1.0
            randomDirection.Normalize();
            //add random length between 0 to maxSpeed
            randomDirection = randomDirection * ((float)random.NextDouble() * maximumspeed);
        }
        //Particlemovement etc..
    }
}
