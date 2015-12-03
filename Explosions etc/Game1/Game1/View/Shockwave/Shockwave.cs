using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace View
{
    class Shockwave
    {
        private Camera camera;
        private SpriteBatch spritebatch;
        private Texture2D shockwavetexture;
        private Vector2 currentPos;
        private Vector2 centertexture;

        private float fade = 1;
        private float shockwaveminsize = 0;
        private float shockwavemaxsize;
        private float currentsize;
        private float scale;
        private float maxtime = 1;
        private float timealive = 0;
        private float lifepercent;


        public Shockwave(Texture2D _shockwavetexture, SpriteBatch _spritebatch, Camera _camera,float _scale, Vector2 _startpos)
        {
            camera = _camera;
            spritebatch = _spritebatch;
            shockwavetexture = _shockwavetexture;
            currentPos = _startpos;
            shockwavemaxsize = _scale;
        }

        public void Draw(float timeElapsed)
        {
            fade -= timeElapsed / maxtime;
            timealive += timeElapsed;
            lifepercent = timealive / maxtime;

            currentsize = shockwaveminsize + lifepercent * shockwavemaxsize;
            scale = camera.Scale(currentsize, shockwavetexture.Width);
            Color color = new Color(fade, fade, fade, fade);
            centertexture = new Vector2(shockwavetexture.Width / 2, shockwavetexture.Height / 2);
            spritebatch.Draw(shockwavetexture, camera.Converttovisualcoords(currentPos, scale), null, color, 0, centertexture, scale, SpriteEffects.None, 0.9f);
        }
    }
}
