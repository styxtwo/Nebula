using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nebula.Particles2D.ParticleModifiers;
using Nebula.Particles2D.Patterns;
using System.Linq;
using Nebula.Particles2D.EmitterModifiers;
namespace Nebula.Particles2D {
    public class Emitter : IEmitter {
        private List<IParticleModifier> particleModifiers = new List<IParticleModifier>();
        private List<IEmitterModifier> emitterModifiers = new List<IEmitterModifier>();
        private IEmissionPattern emissionPattern = new PointEmissionPattern();
        private List<Particle> aliveParticles = new List<Particle>();
        private List<Particle> deadParticles = new List<Particle>();
        private Random random = new Random();
        private Particle template;

        public Vector2 Position { get; set; }
        public Range ParticleSpeed { get; set; }
        public Range ParticleAngle { get; set; }
        public Range ParticleLifeSpan { get; set; }
        public float ParticlesPerFrame { get; set; }
        public Emitter(Particle template, Range Speed, Range Angle, Range ParticleLifeSpan, float ParticlesPerFrame = 1) {
            this.ParticlesPerFrame = ParticlesPerFrame;
            this.ParticleLifeSpan = ParticleLifeSpan;
            this.ParticleSpeed = Speed;
            this.ParticleAngle = Angle;
            this.template = template;
        }
        public void Update(int elapsedMiliseconds) {
            foreach (IEmitterModifier modifier in emitterModifiers) {
                modifier.Update(this, elapsedMiliseconds);
            }
            Emit(elapsedMiliseconds);
            List<Particle> tempAliveParticles = new List<Particle>(aliveParticles);
            foreach (Particle particle in tempAliveParticles) {
                foreach (IParticleModifier modifier in particleModifiers) {
                    modifier.Update(this, particle, elapsedMiliseconds);
                }
                particle.Update(elapsedMiliseconds);
                if (!particle.IsAlive()) {
                    aliveParticles.Remove(particle);
                    deadParticles.Add(particle);
                }
            }
            if (deadParticles.Count > 500) {
                deadParticles.RemoveRange(0, 250); //batch remove dead particles when count gets too high
            }
        }
        private void Emit(int elapsedMiliseconds) {
            if (ParticlesPerFrame < 1) {
                if (random.NextDouble() < ParticlesPerFrame) {
                    if (deadParticles.Count == 0) {
                        deadParticles.Add(new Particle(template));
                    }
                    InitParticle();
                }
            } else {
                for (int i = 0; i < ParticlesPerFrame; i++) {
                    if (deadParticles.Count == 0) {
                        deadParticles.Add(new Particle(template));
                    }
                    InitParticle();
                }
            }

        }
        private void InitParticle() {
            Particle particle = deadParticles.Last();
            deadParticles.Remove(particle);

            Vector2 position = emissionPattern.CalculateParticlePosition(random, Position);
            float angle = MathHelper.ToRadians(ParticleAngle.Lerp(random.NextDouble()));
            float speed = ParticleSpeed.Lerp(random.NextDouble());
            int lifeSpan = (int)ParticleLifeSpan.Lerp(random.NextDouble());
            Vector2 velocity = Vector2.Transform(new Vector2(speed, 0), Matrix.CreateRotationZ(angle));

            particle.Reset(template, position, velocity, lifeSpan);
            aliveParticles.Add(particle);
        }

        public void Draw(SpriteBatch spriteBatch) {
            foreach (Particle particle in aliveParticles) {
                particle.Draw(spriteBatch);
            }
        }
        public int GetAliveParticles() {
            return aliveParticles.Count;
        }
        public int GetDeadParticles() {
            return deadParticles.Count;
        }
        public Emitter AddParticleModifier(IParticleModifier modifier) {
            this.particleModifiers.Add(modifier);
            return this;
        }
        public Emitter AddEmissionModifier(IEmitterModifier modifier) {
            this.emitterModifiers.Add(modifier);
            return this;
        }
        public Emitter SetEmissionPattern(IEmissionPattern emissionPattern) {
            this.emissionPattern = emissionPattern;
            return this;
        }
        public Emitter SetTemplateParticle(Particle templateParticle) {
            this.template = templateParticle;
            return this;
        }
    }
}
