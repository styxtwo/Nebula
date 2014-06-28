﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Nebula.Particles2D.Patterns;
using Nebula.Particles2D.ParticleModifiers.Movement.Gravity;
using Nebula.Particles2D.ParticleModifiers.Movement;
using Nebula.Particles2D.ParticleModifiers.AgeTransform;
namespace Nebula.Particles2D.Presets {
    public class Rain : AbstractEmitterPreset {
        /*
            Example usage:
            Texture2D raindrop = Content.Load<Texture2D>(@"Particles/Raindrop");
            rain = new Rain(raindrop, new Vector2(1200, 600), 10, 5, 2);
          */
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
            float particlesPerFrame = 10;
            return new Emitter(particle, particleSpeed, particleAngle, particleLifespan, particlesPerFrame);
        }
    }
}