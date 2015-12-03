using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace View
{
    class Smokeparticle
    {
        private Vector2 randomdirection;
        
        private Vector2 currentpos;
        private Vector2 acceleration = new Vector2(0.0f, -0.8f);
        private Vector2 velocity;
        private Vector2 startpos = new Vector2();
        private Texture2D smokecloud;
        Random random = new Random();
        Color color = new Color();

        private float maxparticlespeed = 0.4f;
        private float particleminsize = 0f;
        private float particlemaxsize = 0.3f;
        private float scale;
        private float timetolive;
        private float lifepercentage;
        private float timehaslived;
        private float randrotation;
        private float particlesize;
        private float rotation;
        private float fade;

        public Smokeparticle(Texture2D _smokecloud, Random _random, float _lifetime,Vector2 _startpos,float _scale) //Creates the random direction and speed
        {
            random = _random;
            timetolive = _lifetime;
            startpos = _startpos;
            scale = _scale;
            smokecloud = _smokecloud;

            Spawnnewparticle();
            randrotation = 0.01f * ((float)random.NextDouble() - (float)random.NextDouble()); //Slight spin on the smokeclouds
        }

        public void Spawnnewparticle()
        {            
            particlesize = particleminsize;
            currentpos = startpos;
            fade = 1f;
            timehaslived = 0;
            rotation = -2; //Temp, fungerar men vet inte varför borde vara 0

            color = new Color(fade, fade, fade, fade);

            randomdirection = new Vector2((float)random.NextDouble() - 0.5f, (float)random.NextDouble() - 0.5f);
            //normalize to get it spherical vector with length 1.0
            randomdirection.Normalize();
            //add random length between 0 to maxSpeed
            randomdirection = randomdirection * ((float)random.NextDouble() * maxparticlespeed);
            
            velocity = randomdirection;
 
        }
        public void Updateposition(float elapsedtime)
        {
            rotation += randrotation;
            fade -= elapsedtime / timetolive;
            //Coursepress https://coursepress.lnu.se/kurs/grundlaggande-spelprogrammering/laborationsoversikt/laboration-2-simuleringar-och-partiklar/
            timehaslived += elapsedtime;

            lifepercentage = timehaslived / timetolive;
            particlesize = particleminsize + lifepercentage * particlemaxsize;

            velocity = (elapsedtime * acceleration) + velocity;

            currentpos = (elapsedtime * (velocity*scale)) + currentpos;

            color = new Color(fade, fade, fade, fade);
        }

        public void Draw(SpriteBatch spritebatch, Camera camera)
        {
            float scale = camera.Scale(particlesize,smokecloud.Width);

            spritebatch.Draw(smokecloud, camera.Converttovisualcoords(currentpos, scale), null, color, rotation, randomdirection, scale, SpriteEffects.None, 0.8f);
        }
    }
}
