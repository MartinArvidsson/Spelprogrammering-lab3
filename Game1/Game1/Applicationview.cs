using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Game1
{
    class Applicationview
    {
        private ContentManager content;
        private Camera camera;
        private SpriteBatch spritebatch;
        private SplitterSystem splittersystem;
        private Smokesystem smokesystem;
        private Explosion explosion;
        private Shockwave shockwave;

        private Texture2D splittertexture;
        private Texture2D smoketexture;
        private Texture2D explosiontexture;
        private Texture2D shockwavetexture;

        private Vector2 startpos = new Vector2(0.5f, 0.5f);
        private float scale = 1f;


        public Applicationview(ContentManager _content,Camera _camera,SpriteBatch _spritebatch)
        {
            content = _content;
            camera = _camera;
            spritebatch = _spritebatch;

            splittertexture = content.Load<Texture2D>("spark");
            smoketexture = content.Load<Texture2D>("smoke");
            explosiontexture = content.Load<Texture2D>("explosion");
            shockwavetexture = content.Load<Texture2D>("Shockwave");

            splittersystem = new SplitterSystem(splittertexture, spritebatch, camera, scale, startpos);
            smokesystem = new Smokesystem(smoketexture, spritebatch, camera, startpos);

            explosion = new Explosion(explosiontexture, spritebatch, camera, scale, startpos);
            shockwave = new Shockwave(shockwavetexture, spritebatch, camera, startpos);
        }

        public void UpdateGame(float timeElapsed)
        {
            splittersystem.Update(timeElapsed);
            smokesystem.Update(timeElapsed);
        }

        public void Draw(float timeElapsed)
        {
            spritebatch.Begin();
            splittersystem.Draw();
            smokesystem.Draw();
            explosion.Draw(timeElapsed);
            shockwave.Draw(timeElapsed);
            spritebatch.End();
        }
    }
}
