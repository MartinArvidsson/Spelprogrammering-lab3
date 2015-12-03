using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Model
{
    class Ball
    {
        public Vector2 BallPos;
        private float maxspeed = 0.7f;
        private float minspeed = 0.3f;
        private Vector2 BallVelocity;
        private float Ballradius = 0.05f;
        private Random rand = new Random();
        private Vector2 randomdirection;

        public Ball()
        {
            BallPos = new Vector2(0.5f, 0.5f); //Where the ball starts
            randomdirection = new Vector2((float)rand.NextDouble() - 0.5f, (float)rand.NextDouble() - 0.7f);
            //normalize to get it spherical vector with length 1.0
            randomdirection.Normalize();
            randomdirection = randomdirection * ((float)rand.NextDouble() * maxspeed);
            BallVelocity = randomdirection;
        }
        
        public float getballradius //Gets the radius
        {
            get
            {
                return Ballradius;
            }
        }

        public Vector2 getballVelocity //Gets the velocity
        {
            get
            {
                return BallVelocity;
            }
        }

        public Vector2 getballpos //Gets the position
        {
            get
            {
                return BallPos;
            }
        }


        //Makes velocity the opposite of what it was since it hit a wall and needs to turn, otherwhise it keeps going in same direction.
        public void setballVelocityX() //Sets a new velocity on X
        {
            BallVelocity.X = -BallVelocity.X;
        }

        public void setballVelocityY() //Sets a new Velocity on Y 
        {
            BallVelocity.Y = -BallVelocity.Y;
        }



    }
}
