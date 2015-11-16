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
        public Vector2 BallPos;
        private Vector2 BallVelocity = new Vector2(0.002f,0.005f); //Speed of ball in Xaxis and Yaxis low values because otherwhise the ball acts like sonic
        private float Ballradius = 0.05f;

        public Ball()
        {
            BallPos = new Vector2(0.19f, 0.75f); //Where the ball starts
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
