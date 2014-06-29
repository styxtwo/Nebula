using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nebula.Particles2D.ParticleModifiers;
using Nebula.Particles2D.Patterns;
using System.Linq;
using Nebula.Particles2D.EmitterModifiers;
namespace Nebula.Particles2D {
    struct ParticleInfo {
        public float perSecond;
        public Range lifeSpan;
        public Range speed;
        public Range angle;
        public Particle template;
    }
    public class Emitter : IEmitter {
        private List<IParticleModifier> particleModifiers = new List<IParticleModifier>();
        private List<IEmitterModifier> emitterModifiers = new List<IEmitterModifier>();
        private IEmissionPattern emissionPattern = new PointEmissionPattern();
        private List<Particle> aliveParticles = new List<Particle>();
        private List<Particle> deadParticles = new List<Particle>();
        internal ParticleInfo particleInfo = new ParticleInfo();
        public Vector2 Position { get; set; }
        private Random random;
        public Emitter(Particle template, Range Speed, Range Angle, Range ParticleLifeSpan, Random random, float ParticlesPerFrame = 1) {
            particleInfo.perSecond = ParticlesPerFrame;
            particleInfo.lifeSpan = ParticleLifeSpan;
            particleInfo.speed = Speed;
            particleInfo.angle = Angle;
            particleInfo.template = template;
            this.random = random;
        }
        /* Update */
        public void Update(double time) {
            Emit(time);
            UpdateParticles(time);
        }
        /* Draw */
        public void Draw(SpriteBatch spriteBatch) {
            foreach (Particle particle in aliveParticles) {
                particle.Draw(spriteBatch);
            }
        }

        /*Emit functions */
        private void Emit(double time) {
            UpdateEmitterModifiers(time);
            CreateNewParticles(time);
        }
        private void UpdateEmitterModifiers(double time) {
            foreach (IEmitterModifier modifier in emitterModifiers) {
                modifier.Update(this, time);
            }
        }
        private void CreateNewParticles(double time) {
            double particles = particlesThisFrame(time);
            if (RandomHigherThenFraction(particles)) {
                AddAliveParticle();
            }
            for (int i = 0; i < (int)particles; i++) {
                AddAliveParticle();
            }
        }
        private double particlesThisFrame(double time) {
            return (particleInfo.perSecond / 1000) * time;
        }
        private bool RandomHigherThenFraction(double particles) {
            return random.NextDouble() < (particles % 1);
        }
        private void AddAliveParticle() {
            if (deadParticles.Count == 0) {
                deadParticles.Add(new Particle(particleInfo.template));
            }
            Particle particle = deadParticles.Last();
            ReviveParticle(particle);
            aliveParticles.Add(particle);
        }
        private Particle ReviveParticle(Particle particle) {
            deadParticles.Remove(particle);
            Vector2 position = emissionPattern.CalculateParticlePosition(random, Position);
            float angle = MathHelper.ToRadians(particleInfo.angle.Lerp(random.NextDouble()));
            float speed = particleInfo.speed.Lerp(random.NextDouble());
            int lifeSpan = (int)particleInfo.lifeSpan.Lerp(random.NextDouble());
            Vector2 velocity = Vector2.Transform(new Vector2(speed, 0), Matrix.CreateRotationZ(angle));
            particle.Reset(particleInfo.template, position, velocity, lifeSpan);
            return particle;
        }

        /*Update functions */
        private void UpdateParticles(double time) {
            foreach (Particle particle in new List<Particle>(aliveParticles)) {
                UpdateParticleModifiers(particle, time);
                particle.Update(time);
                RemoveDeadParticle(particle);
            }
            RemoveDeadParticleOverflow();
        }
        private void UpdateParticleModifiers(Particle particle, double time) {
            foreach (IParticleModifier modifier in particleModifiers) {
                modifier.Update(this, particle, time);
            }
        }
        private void RemoveDeadParticle(Particle particle) {
            if (!particle.IsAlive()) {
                aliveParticles.Remove(particle);
                deadParticles.Add(particle);
            }
        }
        private void RemoveDeadParticleOverflow() {
            if (deadParticles.Count >= 500) {
                deadParticles.RemoveRange(0, 250);
            }
        }

        /* Public getters and adders*/
        public int GetAliveParticles() {
            return aliveParticles.Count;
        }
        public int GetDeadParticles() {
            return deadParticles.Count;
        }
        public void SetEmissionPattern(IEmissionPattern emissionPattern) {
            this.emissionPattern = emissionPattern;
        }
        public Emitter AddParticleModifier(IParticleModifier modifier) {
            this.particleModifiers.Add(modifier);
            return this;
        }
        public Emitter AddEmissionModifier(IEmitterModifier modifier) {
            this.emitterModifiers.Add(modifier);
            return this;
        }
    }
}
