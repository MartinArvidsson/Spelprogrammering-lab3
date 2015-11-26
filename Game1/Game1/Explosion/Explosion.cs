using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace GameExplosion
{
    class Explosion
    {
        Camera camera = new Camera();
        private Vector2 startpos = new Vector2(0.5f, 0.5f);
        SpriteBatch spritebatch;
        private Texture2D explosion;

        private float timeElapsed;
        private float animationspeed = 1f;
        private int totalframes = 24;
        private int numframesX = 4;
        private int numframesY = 8;
        private int explosionheight;
        private int explosionwidth;

        public Explosion(SpriteBatch _spritebatch,Texture2D _explosion,Camera _camera)
        {
            camera = _camera;
            spritebatch = _spritebatch;
            explosion = _explosion;

            timeElapsed = 0;
            explosionwidth = _explosion.Width / numframesX;
            explosionheight = _explosion.Height / numframesY;
        }

        public void Draw(float elapsedtime)
        {
            timeElapsed += elapsedtime;
            if (timeElapsed >= animationspeed)
            {
                timeElapsed = 0;
            }
            float percentAnimated = timeElapsed / animationspeed;
            int frame = (int)(percentAnimated * totalframes);
            int frameX = frame % numframesX;
            int frameY = frame / numframesX;
            explosionwidth = explosion.Width / numframesX;
            explosionheight = explosion.Height / numframesY;

            Rectangle rect = new Rectangle(explosionwidth * frameX, explosionheight * frameY, explosionwidth, explosionheight);
            spritebatch.Begin();
            spritebatch.Draw(explosion, camera.Converttovisualcoords(startpos, explosionheight, explosionwidth), rect, Color.White);
            spritebatch.End();
        }
    }
}
