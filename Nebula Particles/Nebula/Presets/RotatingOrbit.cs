using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nebula.Particles2D.EmitterModifiers;
using Nebula.Particles2D.ParticleModifiers.AgeTransform;
using Supernova.Particles2D.Modifiers.Movement.Gravity;
using System;

namespace Nebula.Particles2D.Presets {
    public class RotatingOrbit : AbstractEmitterPreset {
        public RotatingOrbit(Texture2D texture) {
            Emitter emitter = CreateEmitter(texture);
            emitter.AddEmissionModifier(new Rotate(180));
            emitter.AddParticleModifier(new GravityPoint(new Vector2(1, 1), 1000, 6f));
            emitter.AddParticleModifier(new Alpha(0.5f, 0));
            this.AddEmitter(emitter);
        }
        private Emitter CreateEmitter(Texture2D texture) {
            Particle particle = CreateParticle(texture);
            float particlesPerSecond = 50;
            Range particleSpeed = new Range(6, 6);
            Range particleAngle = new Range(-10, 10);
            Range particleLifespan = new Range(10000, 10000);
            return new Emitter(particle, particleSpeed, particleAngle, particleLifespan, new Random(), particlesPerSecond);
        }
        private Particle CreateParticle(Texture2D texture) {
            Particle particle = new Particle(texture);
            particle.color = Color.Fuchsia;
            particle.Alpha = 0.5f;
            return particle;
        }
    }
}
