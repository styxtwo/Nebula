using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nebula.Particles2D.ParticleModifiers;
using Nebula.Particles2D.ParticleModifiers.AgeTransform;
using Nebula.Particles2D.Patterns;
using Supernova.Particles2D.Modifiers.Movement.Gravity;
namespace Nebula.Particles2D.Presets {
    public class ColorfulRing : AbstractEmitterPreset {
        public ColorfulRing(Texture2D texture) {
            Emitter ring = CreateRingEmitter(texture);
            this.AddEmitter(ring);
            this.Position = new Vector2(600, 300);

            ring.AddParticleModifier(new Alpha(1f, 0f));
            ring.AddParticleModifier(new RandomColor());
            ring.SetEmissionPattern(new RingEmissionPattern(100));
            ring.AddParticleModifier(new GravityPoint(new Vector2(0, 0), 600, -0.005f));
        }
        private Emitter CreateRingEmitter(Texture2D texture) {
            float particlesPerFrame = 50;
            Range particleSpeed = new Range(0f, 0f);
            Range particleAngle = new Range(0f, 360f);
            Range particleLifespan = new Range(500, 1000);
            Particle particle = new Particle(texture);
            return new Emitter(particle, particleSpeed, particleAngle, particleLifespan, particlesPerFrame);
        }
    }
}
