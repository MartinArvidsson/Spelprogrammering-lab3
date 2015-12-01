using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Roll_a_Ball.Model
{
    class BallSimulation
    {
        public Ball ball;
        public BallSimulation()
        {
            ball = new Ball(); //new ball object
        }

        public void Updatepos(float Elapsedtime)
        {
            ball.BallPos += ball.getballVelocity * Elapsedtime;

            if(ball.BallPos.X + ball.getballradius > 1.0 || ball.BallPos.X - ball.getballradius < 0.0) //If ball bounces <---->
            {
                ball.setballVelocityX();
            }
            if(ball.BallPos.Y + ball.getballradius > 1.0 || ball.BallPos.Y - ball.getballradius < 0.0) //If ball bounces ^ v
            {
                ball.setballVelocityY();
            }

        }

    }
}
