using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    class BallSimulation
    {
        private List<Ball> balls = new List<Ball>();
        private List<Ball> deadballs;
        public Ball ball;
        Random rand = new Random();
        int numberofballs = 10;
        public BallSimulation()
        {
            for (int i = 0; i < numberofballs; i++)
            {
                balls.Add(ball = new Ball(rand)); //new ball object
            }
        }

        public void UpdateBall(float Elapsedtime)
        {
            foreach(Ball ball in balls)
            {
                if(ball.Getballstatus == false)
                { 
                    hitwall(ball);
                    ball.updatecurrentpos(Elapsedtime);
                }
                else
                {
                    
                }
            }
        }
        public void hitwall(Ball ball)
        {

            if (ball.BallPos.X + ball.getballradius > 1.0 || ball.BallPos.X - ball.getballradius < 0.0) //If ball bounces <---->
            {
                ball.setballVelocityX();
            }
            if (ball.BallPos.Y + ball.getballradius > 1.0 || ball.BallPos.Y - ball.getballradius < 0.0) //If ball bounces ^ v
            {
                ball.setballVelocityY();
            }

        }

        public void killballs(float Xcoord,float Ycoord,float Crosshair)
        {
            deadballs = new List<Ball>();

            foreach(Ball ball in balls)
            {
                if(ball.Getballstatus != true)
                {
                    if (ball.getballpos.X + ball.getballradius > Xcoord - Crosshair && //Ball upper side
                        ball.getballpos.X - ball.getballradius < Xcoord + Crosshair && //Ball bottom side
                        ball.getballpos.Y + ball.getballradius > Ycoord - Crosshair && //Ball Side
                        ball.getballpos.Y - ball.getballradius < Ycoord + Crosshair)   //Ball side
                    {
                        deadballs.Add(ball);
                        ball.Killball = true;
                    }
                }
            }
        }

        public List<Ball> getballs()
        {
            return balls;
        }

        public List<Ball> getdeadballs()
        {
            return deadballs;
        }

    }
}
