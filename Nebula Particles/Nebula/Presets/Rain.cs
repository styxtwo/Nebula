using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Nebula.Particles2D.Patterns;
using Nebula.Particles2D.ParticleModifiers.Movement.Gravity;
using Nebula.Particles2D.ParticleModifiers.Movement;
using Nebula.Particles2D.ParticleModifiers.AgeTransform;
using System;
namespace Nebula.Particles2D.Presets {
    public class Rain : AbstractEmitterPreset {
        public Rain(Texture2D rainTexture, Vector2 area, float gravity = 1, float wind = 0) {
            Emitter rain = CreateRainEmitter(rainTexture, gravity);
            this.AddEmitter(rain);

            int windOffset = -100;
            this.Position = new Vector2(windOffset, 0);
            rain.AddParticleModifier(new Alpha(1f, 0.5f, 1));
            rain.AddParticleModifier(new DirectionalPull(new Vector2(wind, gravity)));
            rain.SetEmissionPattern(new LineEmissionPattern(area.X - windOffset, 0));
            rain.AddParticleModifier(new HorizontalLineContainer((int)area.Y, 0.15f, 0.1f));
        }
        private Emitter CreateRainEmitter(Texture2D rainTexture, float gravity) {
            Particle particle = new Particle(rainTexture);
            Range particleSpeed = new Range(gravity * 0.5f, gravity * 1.2f);
            Range particleLifespan = new Range(1000, 1500);
            Range particleAngle = new Range(90, 90);
            float particlesPerSecond = 600;
            return new Emitter(particle, particleSpeed, particleAngle, particleLifespan, new Random(), particlesPerSecond);
        }
    }
}
