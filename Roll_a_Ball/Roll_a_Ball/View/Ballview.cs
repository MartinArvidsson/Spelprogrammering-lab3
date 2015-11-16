using Roll_a_Ball.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Roll_a_Ball.View
{

    class Ballview
    {
        Texture2D box;
        Texture2D ball;
        private Camera camera;
        private BallSimulation ballSimulation;

        //Loads the sprites aswell as creating the board.
        public Ballview(GraphicsDeviceManager graphics, BallSimulation ballsimulation, ContentManager Content)
        {
            ball = Content.Load<Texture2D>("BALL.png");
            
            box = new Texture2D(graphics.GraphicsDevice,1,1);
            box.SetData<Color>(new Color[]
                {
                    Color.White
                });
                camera = new Camera(graphics.GraphicsDevice.Viewport);
                ballSimulation = ballsimulation;

        }

        //USes the sprites created above to load them into the board, first the board then the ball.
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Begin();
            spritebatch.Draw(box,camera.getGame(),Color.Black);

            spritebatch.Draw(ball, camera.newboardpos(ballSimulation.ball.BallPos.X, ballSimulation.ball.BallPos.Y),
                null, Color.White,0f, new Vector2(ball.Width / 2, ball.Height / 2),
                camera.ScaledBallsize(ball.Width, ballSimulation.ball.getballradius * 2f),
                SpriteEffects.None, 0f);
            
            spritebatch.End();

        }
    }
}
