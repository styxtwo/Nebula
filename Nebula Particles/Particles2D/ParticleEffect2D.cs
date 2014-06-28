using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nebula.Particles2D.Modifiers;
using Nebula.Particles2D.Patterns;

namespace Nebula.Particles2D {
    public class ParticleEffect2D {
        private Random random = new Random();
        private Particle2D[] particles;
        private List<IModifier> Modifiers;
        private Particle2D template;
        private IEmissionPattern EmissionPattern;
        private Queue<Particle2D> freeParticles = new Queue<Particle2D>();

        public Vector2 Position { get; set; }
        public int EmitPerSecond { get; set; }
        public ParticleEffect2D(Particle2D template, int maxParticles = 1000, int EmitPerSecond = 100) {
            Modifiers = new List<IModifier>();
            particles = new Particle2D[maxParticles];
            EmissionPattern = new PointEmissionPattern();
            this.template = template;
            this.EmitPerSecond = EmitPerSecond;

            for (int i = 0; i < particles.Length; i++) {
                particles[i] = new Particle2D(template);
                freeParticles.Enqueue(particles[i]);
            }

        }
        public void Update(int elapsedMiliseconds) {
            Emit(elapsedMiliseconds);
            foreach (Particle2D particle in particles) {
                if (particle.IsAlive()) {
                    UpdateLivingParticle(particle, elapsedMiliseconds);
                    RemoveDeadParticle(particle);
                }
            }
        }
        private void UpdateLivingParticle(Particle2D particle, int elapsedMiliseconds) {

            foreach (IModifier modifier in Modifiers) {
                modifier.Update(particle, elapsedMiliseconds);
            }
            particle.Update(elapsedMiliseconds);
        }
        private void RemoveDeadParticle(Particle2D particle) {
            if (!particle.IsAlive()) {
                freeParticles.Enqueue(particle);
            }
        }




        private void Emit(int elapsedMiliseconds) {
            int particlesToEmit = 30;
            if (freeParticles.Count >= particlesToEmit) {
                for (int i = 0; i < particlesToEmit; i++) {
                    InitParticle();
                }
            }
        }
        private void InitParticle() {
            Particle2D particle = freeParticles.Dequeue();

            Vector2 position = EmissionPattern.CalculateParticlePosition(random, Position);
            float angle = MathHelper.ToRadians((float)random.NextDouble()*360);
            float EmissionSpeed = 3;
            Vector2 velocity = Vector2.Transform(new Vector2(EmissionSpeed, 0), Matrix.CreateRotationZ(angle));

            particle.Reset(template, position, velocity);
        }



        public void Draw(SpriteBatch spriteBatch) {
            foreach (Particle2D particle in particles) {
                if (particle.IsAlive()) {
                    particle.Draw(spriteBatch);
                }
            }
        }
        public int GetActiveParticles() {
            return particles.Length - freeParticles.Count;
        }


        public ParticleEffect2D SetEmissionPattern(IEmissionPattern emissionPattern) {
            this.EmissionPattern = emissionPattern;
            return this;
        }
        public ParticleEffect2D AddModifier(IModifier modifier) {
            this.Modifiers.Add(modifier);
            return this;
        }
        public ParticleEffect2D SetTemplateParticle(Particle2D templateParticle) {
            this.template = templateParticle;
            return this;
        }

    }
}
