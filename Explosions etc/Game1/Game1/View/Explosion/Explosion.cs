using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace View
{
    class Explosion
    {
        Camera camera = new Camera();
        SpriteBatch spritebatch;
        private Texture2D explosion;
        private Vector2 currentPos = new Vector2();
        private float timeElapsed;
        private float animationspeed = 1f;
        private int totalframes = 24;
        private int numframesX = 4;
        private int numframesY = 8;
        private int explosionheight;
        private int explosionwidth;
        private float scale;
        public Explosion(Texture2D _explosiontexture,SpriteBatch _spritebatch,Camera _camera,float _scale,Vector2 _startpos)
        {
            camera = _camera;
            spritebatch = _spritebatch;
            explosion = _explosiontexture;
            currentPos = _startpos;
            scale = _scale;

            timeElapsed = 0;
            explosionwidth = _explosiontexture.Width / numframesX;
            explosionheight = _explosiontexture.Height / numframesY;
        }

        public void Draw(float elapsedtime)
        {
            timeElapsed += elapsedtime;

            float percentAnimated = timeElapsed / animationspeed;
            int frame = (int)(percentAnimated * totalframes);
            int frameX = frame % numframesX;
            int frameY = frame / numframesX;
            explosionwidth = explosion.Width / numframesX;
            explosionheight = explosion.Height / numframesY;

            Rectangle rect = new Rectangle(explosionwidth * frameX, explosionheight * frameY, explosionwidth, explosionheight);

            spritebatch.Draw(explosion, camera.Converttovisualcoords(currentPos,explosionwidth,explosionheight,scale), rect, Color.White,0f,Vector2.Zero,scale,SpriteEffects.None,0.1f);
        }
    }
}
