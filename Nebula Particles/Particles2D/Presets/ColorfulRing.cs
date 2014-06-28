using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nebula.Particles2D.ParticleModifiers;
using Nebula.Particles2D.ParticleModifiers.AgeTransform;
using Nebula.Particles2D.Patterns;
using Supernova.Particles2D.Modifiers.Movement.Gravity;

namespace Nebula.Particles2D.Presets {
    public class ColorfulRing : AbstractEmitterPreset {
        public ColorfulRing(Texture2D texture) {
            Particle particle = new Particle(texture, Color.White);


            float particlesPerFrame = 50;
            Range particleSpeed = new Range(0f, 0f);
            Range particleAngle = new Range(0f, 360f);
            Range particleLifespan = new Range(500, 1000);
            Emitter emitter = new Emitter(particle, particleSpeed, particleAngle, particleLifespan, particlesPerFrame);
            emitter.AddParticleModifier(new RandomColor());
            emitter.AddParticleModifier(new Alpha(1f, 0f));
            emitter.AddParticleModifier(new GravityPoint(new Vector2(0, 0), 600, -0.005f));
            emitter.SetEmissionPattern(new CircleEmissionPattern(100));
            this.AddEmitter(emitter);
            this.Position = new Vector2(600, 300);
        }
    }
}
