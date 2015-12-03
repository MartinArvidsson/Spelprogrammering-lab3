using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

namespace View
{
    class Startview
    {
        private ContentManager content;
        private Camera camera;
        private SpriteBatch spritebatch;

        private Texture2D splittertexture;
        private Texture2D smoketexture;
        private Texture2D explosiontexture;
        private Texture2D shockwavetexture;

        private SoundEffect firesound;

        List<Explosionview> numberofexplosions = new List<Explosionview>();
        //List<Smokesystem> numberofsmokes = new List<Smokesystem>();

        public Startview(ContentManager _content, Camera _camera, SpriteBatch _spritebatch)
        {
            content = _content;
            camera = _camera;
            spritebatch = _spritebatch;

            splittertexture = content.Load<Texture2D>("spark");
            smoketexture = content.Load<Texture2D>("smoke");
            explosiontexture = content.Load<Texture2D>("explosion");
            shockwavetexture = content.Load<Texture2D>("Shockwave");
            firesound = content.Load<SoundEffect>("fire");
        }

        public void Draw(float elapsedtime)
        {
            spritebatch.Begin(SpriteSortMode.BackToFront);
            DrawExplosions(elapsedtime);
            spritebatch.End();

        }

        public void DrawExplosions(float elapsedtime)
        {
            foreach(Explosionview explosion in numberofexplosions)
            {
                explosion.UpdateGame(elapsedtime);
                explosion.Draw(elapsedtime);
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
        }
    }
}
