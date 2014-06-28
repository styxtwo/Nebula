using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Nebula.Particles2D.Patterns;
using Nebula.Particles2D.ParticleModifiers;
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
        public Rain(Texture2D rainTexture, Vector2 area,float gravity = 1, float wind = 0) {
            int windOffset = -100;
            Particle particle = new Particle(rainTexture, Color.White);
            Range particleSpeed = new Range(gravity*0.5f, gravity*1.2f);
            Range particleLifespan = new Range(1000, 1500);
            Range particleAngle = new Range(90, 90);
            float particlesPerFrame = 10;
            Emitter emitter = new Emitter(particle, particleSpeed, particleAngle, particleLifespan, particlesPerFrame);
            emitter.SetEmissionPattern(new LineEmissionPattern(area.X - windOffset, 0));

            emitter.AddParticleModifier(new Alpha(1f, 0.5f, 1));
            emitter.AddParticleModifier(new DirectionalPull(new Vector2(wind, gravity)));
            this.AddEmitter(emitter);

            this.Position = new Vector2(windOffset, 0);
            emitter.AddParticleModifier(new HorizontalLineContainer((int)area.Y, 0.15f, 0.1f));
        }
    }
}
