using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nebula.Particles2D.EmitterModifiers;
using Nebula.Particles2D.ParticleModifiers.AgeTransform;
using Nebula.Particles2D.ParticleModifiers.Movement.Gravity;
using Nebula.Particles2D.Patterns;
using System;

namespace Nebula.Particles2D.Presets {
    public class Fire : AbstractEmitterPreset {
        public Fire(Texture2D texture) {
            Emitter smoke = CreateSmoke(texture);
            smoke.AddParticleModifier(new Colour(Color.Gray, Color.Black));
            smoke.AddParticleModifier(new DirectionalPull(new Vector2(0, -0.5f)));
            smoke.AddParticleModifier(new Alpha(1, 0));
            smoke.AddParticleModifier(new Scale(1, 2));
            smoke.AddEmissionModifier(new Pulse(10, 10));
            this.AddEmitter(smoke);

            Emitter fire = CreateFire(texture);
            fire.AddParticleModifier(new Colour(Color.Yellow, Color.Red));
            fire.AddParticleModifier(new DirectionalPull(new Vector2(0, -5)));
            fire.AddParticleModifier(new Alpha(1, 0));
            fire.SetEmissionPattern(new CircleEmissionPattern(8));
            this.AddEmitter(fire);

            Emitter sparks = CreateSparks(texture);
            sparks.AddParticleModifier(new DirectionalPull(new Vector2(0, 7)));
            sparks.AddParticleModifier(new Alpha(1, 0));
            sparks.SetEmissionPattern(new CircleEmissionPattern(5));
            this.AddEmitter(sparks);

            Emitter whiteFront = CreateWhite(texture);
            whiteFront.AddParticleModifier(new Alpha(1, 0));
            whiteFront.SetEmissionPattern(new CircleEmissionPattern(4));
            this.AddEmitter(whiteFront);
        }
        private Emitter CreateSmoke(Texture2D texture) {
            float particlesPerMillisecond = 60;
            Range particleSpeed = new Range(0.2f, 0.4f);
            Range particleAngle = new Range(240, 300);
            Range particleLifespan = new Range(1000, 2500);
            Particle particle = new Particle(texture);
            return new Emitter(particle, particleSpeed, particleAngle, particleLifespan, new Random(), particlesPerMillisecond);
        }
        private Emitter CreateFire(Texture2D texture) {
            float particlesPerMillisecond = 360;
            Range particleSpeed = new Range(0, 1f);
            Range particleAngle = new Range(225, 315);
            Range particleLifespan = new Range(250, 600);
            Particle particle = new Particle(texture);
            return new Emitter(particle, particleSpeed, particleAngle, particleLifespan, new Random(), particlesPerMillisecond);
        }
        private Emitter CreateSparks(Texture2D texture) {
            float particlesPerMillisecond = 12.5f;
            Range particleSpeed = new Range(0, 3f);
            Range particleAngle = new Range(0, 360);
            Range particleLifespan = new Range(200, 500);
            Particle particle = new Particle(texture);
            particle.Scale = 0.3f;
            return new Emitter(particle, particleSpeed, particleAngle, particleLifespan, new Random(), particlesPerMillisecond);
        }
        private Emitter CreateWhite(Texture2D texture) {
            float particlesPerMillisecond = 60;
            Range particleSpeed = new Range(0, 0.7f);
            Range particleAngle = new Range(0, 360);
            Range particleLifespan = new Range(200, 250);
            Particle particle = new Particle(texture);
            return new Emitter(particle, particleSpeed, particleAngle, particleLifespan, new Random(), particlesPerMillisecond);
        }
    }
}
