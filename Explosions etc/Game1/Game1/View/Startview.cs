using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Model;
namespace View
{
    class Startview
    {
        
        private ContentManager content;
        private Camera camera;
        private SpriteBatch spritebatch;
        private BallSimulation ballsim;
        private GraphicsDeviceManager graphics;

        private SoundEffect firesound;
        private Texture2D balltexture;
        private Texture2D splittertexture;
        private Texture2D smoketexture;
        private Texture2D explosiontexture;
        private Texture2D shockwavetexture;
        private Texture2D background;
        private Texture2D crosshair;
        private Texture2D deadball;
        private Vector2 ballcenter;
        private Rectangle rect;
        private int fieldsize;
        private int bordersize;
        private float crosshairsize = 0.3f;
        List<Explosionview> numberofexplosions = new List<Explosionview>();

        public Startview(ContentManager _content, Camera _camera, SpriteBatch _spritebatch,BallSimulation _ballsim,GraphicsDeviceManager _graphics)
        {
            content = _content;
            camera = _camera;
            spritebatch = _spritebatch;
            ballsim = _ballsim;
            graphics = _graphics;

            fieldsize = camera.ReturnFieldsize();
            bordersize = camera.ReturnBorder();

            rect = new Rectangle(bordersize, bordersize, fieldsize, fieldsize);

            splittertexture = content.Load<Texture2D>("spark");
            smoketexture = content.Load<Texture2D>("smoke");
            explosiontexture = content.Load<Texture2D>("explosion");
            shockwavetexture = content.Load<Texture2D>("Shockwave");
            balltexture = content.Load<Texture2D>("BALL");
            deadball = content.Load<Texture2D>("Deadball");
            crosshair = content.Load<Texture2D>("Crosshair");
            firesound = content.Load<SoundEffect>("fire");
            ballcenter = new Vector2(balltexture.Width / 2, balltexture.Height / 2);

            background = new Texture2D(graphics.GraphicsDevice, 1, 1);
            background.SetData(new Color[] { Color.Black });
        }

        public void Draw(float elapsedtime)
        {
            spritebatch.Begin(SpriteSortMode.FrontToBack);

            DrawCrosshair();
            DrawExplosions(elapsedtime);
            DrawBalls();

            spritebatch.End();
        }
        public void DrawCrosshair()
        {
            float crosshairscaled = camera.Scale(crosshairsize, crosshair.Width);
            var mousepos = Mouse.GetState();
            Vector2 _mousepos = new Vector2(mousepos.X, mousepos.Y);
            Vector2 pos = camera.Centercursortexture(crosshair,_mousepos, crosshairscaled);
            spritebatch.Draw(crosshair, pos, null, Color.White, 0, Vector2.Zero, crosshairscaled, SpriteEffects.None, 1f);
        }

        public void DrawBalls()
        {
            foreach (Ball ball in ballsim.getballs())
            {
                spritebatch.Draw(background, rect, Color.White);
                Vector2 currentballpos = ball.getballpos;
                float scale = camera.Scale(ball.getballradius * 2, balltexture.Width);
                var ballvisualpos = camera.Converttovisualcoords(currentballpos, scale);
                if(ball.Getballstatus == false)
                {
                    spritebatch.Draw(balltexture, ballvisualpos, null, Color.White, 0, ballcenter, scale, SpriteEffects.None, 0.4f);
                }
                else
                {
                    spritebatch.Draw(deadball, ballvisualpos, null, Color.White, 0, ballcenter, scale, SpriteEffects.None, 0.4f);
                }
           }
        }

        public void DrawExplosions(float elapsedtime)
        {
            for (int i = numberofexplosions.Count - 1; i >= 0; i--)
            {
                Explosionview explosion = numberofexplosions.ElementAt(i);
                explosion.UpdateGame(elapsedtime);
                explosion.Draw(elapsedtime);
                if (explosion.Getlifetimeofexplosion() == true)
                {
                    numberofexplosions.RemoveAt(i);
                }
            }
        }

        public void CreateExplosion(float Xcoord,float Ycoord,SpriteBatch spritebatch)
        {
            Vector2 mouseclick = new Vector2(Xcoord,Ycoord);
            Vector2 explosionpos = camera.ConvertMouseToLogical(mouseclick);

            if(explosionpos.X <= 1f && explosionpos.X >= 0f && explosionpos.Y <=1f && explosionpos.Y >= 0f)
            {
                numberofexplosions.Add(new Explosionview(camera, spritebatch, explosionpos, splittertexture, smoketexture, explosiontexture, shockwavetexture));
                firesound.Play(0.1f, 0, 0);
            }
            ballsim.killballs(explosionpos.X, explosionpos.Y, (crosshairsize/2));
        }
    }
}
