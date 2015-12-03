using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace View
{
    class SplitterParticle
    {
        private float particlesize = 0.02f;
        private Vector2 randomdirection;
        private float maxspeed = 1f;
        private float scale;
        private Random rand;
        private Texture2D spark;
        private Vector2 velocity;
        private Vector2 acceleration = new Vector2(0.0f, 0.5f);
        private Vector2 startpos;
        private float lifetime;
        private SpriteBatch spritebatch;
        private Camera camera;


        public SplitterParticle(Texture2D _spark, Random _rand, SpriteBatch _spritebatch, Camera _camera, float _scale, Vector2 _startpos, float _lifetime)
        {
            spark = _spark;
            rand = _rand;
            spritebatch = _spritebatch;
            camera = _camera;
            scale = _scale;
            startpos = _startpos;
            lifetime = _lifetime;

            randomdirection = new Vector2((float)rand.NextDouble() - 0.5f, (float)rand.NextDouble() - 0.7f);
            //normalize to get it spherical vector with length 1.0
            randomdirection.Normalize();
            randomdirection = randomdirection * ((float)rand.NextDouble() * maxspeed);
            velocity = randomdirection *scale;
        }

        public void UpdatePos(float elapsedtime)
        {
            velocity = elapsedtime * acceleration + velocity;
            startpos = elapsedtime * velocity + startpos;
        }

        public void Draw()
        {
            float scale = camera.Scale(particlesize, spark.Width);

            spritebatch.Draw(spark, camera.Converttovisualcoords(startpos, spark.Width, spark.Height, scale), null, Color.White, 0, randomdirection, scale, SpriteEffects.None, 0.7f);

        }

    }
}
