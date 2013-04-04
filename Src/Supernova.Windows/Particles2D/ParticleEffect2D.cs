﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Supernova.Windows.Particles2D
{
    public class ParticleEffect2D
    {
        private static readonly Random Random = new Random();

        private readonly List<Texture2D> textures = new List<Texture2D>();
        private readonly Queue<Particle2D> freeParticles = new Queue<Particle2D>();
        private readonly Particle2D[] particles;

        private Color particleColor = Color.White;
        private int particleLifespan;
        private int activeParticleCount;

        private int emissionAmount = 5;
        private float emissionSpeed = 1f;

        public ParticleEffect2D(int maxParticles, int particleLifespan)
        {
            this.particleLifespan = particleLifespan;
            particles = new Particle2D[maxParticles];

            for(int i = 0; i < particles.Length; i++)
            {
                particles[i] = new Particle2D();
                freeParticles.Enqueue(particles[i]);
            }
        }

        public void Emit(float totalMilliseconds, Vector2 position)
        {
            if (textures.Count == 0)
                throw new InvalidOperationException("Error emitting particles - no textures have be specified.");

            if (freeParticles.Count >= 1)
            {
                int totalParticlesToEmit = (int) MathHelper.Clamp(Random.Next((int) (emissionAmount * 0.8f), emissionAmount), 1, freeParticles.Count);

                for (int i = 0; i < totalParticlesToEmit; i++)
                {
                    Vector2 emitPosition = position;
                    Texture2D texture = textures[Random.Next(textures.Count)];

                    float angle = MathHelper.ToRadians(Random.Next(360));
                    Vector2 velocity = Vector2.Transform(new Vector2((float)Random.NextDouble() * emissionSpeed, 0), Matrix.CreateRotationZ(angle));

                    Particle2D newParticle = freeParticles.Dequeue();
                    newParticle.Initialize(texture, emitPosition, velocity, particleColor, particleLifespan, totalMilliseconds);

                    activeParticleCount++;
                }
            }
        }

        public void Update(double totalMilliseconds)
        {
            if (IsActive)
            {
                foreach (Particle2D particle in particles)
                {
                    if(particle.IsAlive)
                    {
                        particle.Update(totalMilliseconds);

                        if (!particle.IsAlive)
                        {
                            freeParticles.Enqueue(particle);
                            activeParticleCount--;
                        }
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(IsActive)
            {
                foreach (Particle2D particle in particles)
                {
                    if(particle.IsAlive)
                    {
                        particle.Draw(spriteBatch);
                    }
                }
            }
        }

        public bool IsActive
        {
            get { return activeParticleCount > 0; }
        }

        public int ActiveParticleCount
        {
            get { return activeParticleCount; }
        }

        public int EmissionAmount
        {
            get { return emissionAmount; }
            set { emissionAmount = value; }
        }

        public float EmissionSpeed
        {
            get { return emissionSpeed; }
            set { emissionSpeed = value; }
        }

        public int ParticleLifespan
        {
            get { return particleLifespan; }
            set { particleLifespan = value; }
        }

        public Color ParticleColor
        {
            get { return particleColor; }
            set { particleColor = value; }
        }

        public List<Texture2D> Textures
        {
            get { return textures; }
        }
    }
}