using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Game1
{
    class Shockwave
    {
        private Camera camera;
        private SpriteBatch spritebatch;
        private Texture2D shockwavetexture;
        private Vector2 currentPos;


        private float fade = 1;
        private float shockwaveminsize = 0;
        private float shockwavemaxsize = 1;
        private float currentsize;
        private float scale;
        private float maxtime = 1;
        private float timealive = 0;
        private float lifepercent;


        public Shockwave(Texture2D _shockwavetexture, SpriteBatch _spritebatch, Camera _camera, Vector2 _startpos)
        {
            camera = _camera;
            spritebatch = _spritebatch;
            shockwavetexture = _shockwavetexture;
            currentPos = _startpos; 

        }

        public void Draw(float timeElapsed)
        {
            fade -= timeElapsed / maxtime;
            timealive += timeElapsed;
            lifepercent = timealive / maxtime;

            currentsize = shockwaveminsize + lifepercent * shockwavemaxsize;
            scale = camera.Scale(currentsize, shockwavetexture.Width);
            Color color = new Color(fade, fade, fade, fade);
            spritebatch.Draw(shockwavetexture, camera.Converttovisualcoords(currentPos, shockwavetexture.Width, shockwavetexture.Height, scale), null, color,0,Vector2.Zero,scale,SpriteEffects.None,0);
        }
    }
}
