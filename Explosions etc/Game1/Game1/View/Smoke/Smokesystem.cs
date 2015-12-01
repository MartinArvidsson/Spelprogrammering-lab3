using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace View
{
    class Smokesystem
    {
        private List<Smokeparticle> particles = new List<Smokeparticle>();
        private int numberofsmokes = 100;
        private int lifetimeofsmoke = 1;
        private static Random rand = new Random();
        private Texture2D smoketexture;
        private SpriteBatch spritebatch;
        private Camera camera;
        private Vector2 startlocation = new Vector2();
        private float scale;

        public Smokesystem(Texture2D _smokeTexture, SpriteBatch _spritebatch,Camera _camera,float _scale,Vector2 _startlocation)
        {
            smoketexture = _smokeTexture;
            spritebatch = _spritebatch;
            camera = _camera;
            scale = _scale;
            startlocation = _startlocation;
            if (particles.Count < numberofsmokes)
            {
                particles.Add(new Smokeparticle(smoketexture, rand, lifetimeofsmoke,startlocation,scale));
            }
        }

        public void Draw()
        {
            foreach (Smokeparticle smoke in particles)
            {
                smoke.Draw(spritebatch, camera, smoketexture);
            }
        }

        private void addnewsmoke()
        {
            if (particles.Count < numberofsmokes)
            {
                particles.Add(new Smokeparticle(smoketexture, rand, lifetimeofsmoke,startlocation,scale));
            }
        }

        public void Update(float elapsedtime)
        {
            if(elapsedtime >= (float)lifetimeofsmoke /(float)numberofsmokes)
            {
                addnewsmoke();
            }
            foreach(Smokeparticle particle in particles)
            {
                particle.Updateposition(elapsedtime);
                //if(particle.islifeover())
                //{
                //    particle.Spawnnewparticle();
                //}
            }
        }

    }
}
