using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using View;

namespace View
{
    class Explosionview
    {
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
        private float lifetimeofexplosion = 5f;
        private float currentlife = 0;
        private Vector2 startpos;
        private float scale = 0.5f;


        public Explosionview(Camera _camera,SpriteBatch _spritebatch,Vector2 _startpos,
        Texture2D _splittertexture,Texture2D _smoketexture,Texture2D _explosiontexture,Texture2D _shockwavetexture)
        {
            camera = _camera;
            spritebatch = _spritebatch;
            startpos = _startpos;

            splittertexture = _splittertexture;
            smoketexture = _smoketexture;
            explosiontexture = _explosiontexture;
            shockwavetexture = _shockwavetexture;

            splittersystem = new SplitterSystem(splittertexture, spritebatch, camera, scale, startpos);
            smokesystem = new Smokesystem(smoketexture, spritebatch, camera,scale, startpos);

            explosion = new Explosion(explosiontexture, spritebatch, camera, scale, startpos);
            shockwave = new Shockwave(shockwavetexture, spritebatch, camera,scale, startpos);
        }

        public void UpdateGame(float timeElapsed)
        {
            currentlife += timeElapsed;
            splittersystem.Update(timeElapsed);
            smokesystem.Update(timeElapsed);
        }

        public void Draw(float timeElapsed)
        {
            splittersystem.Draw();
            smokesystem.Draw();
            explosion.Draw(timeElapsed);
            shockwave.Draw(timeElapsed);

        }

        public bool Getlifetimeofexplosion()
        {
            if(currentlife >= lifetimeofexplosion)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
