using Microsoft.Xna.Framework;
using Nebula.Particles2D;
using Nebula.Particles2D.ParticleModifiers;

namespace Supernova.Particles2D.Modifiers.Movement.Gravity {
    public class GravityPoint : IParticleModifier {
        public Vector2 Position { get; set; }
        public float Radius { get; set; }
        public float Strength { get; set; }
        public GravityPoint(Vector2 Position, float Radius, float Strength) {
            this.Position = Position;
            this.Radius = Radius;
            this.Strength = Strength;
        }
        public void Update(Emitter emitter, Particle particle, double milliseconds) {
            {
                Vector2 distance = Vector2.Subtract(Position + emitter.Position, particle.Position);
                if (distance.LengthSquared() < Radius * Radius) {
                    Vector2 force = Vector2.Normalize(distance);
                    force = Vector2.Multiply(force, Strength);
                    force = Vector2.Multiply(force, (float)(milliseconds / 1000));
                    particle.Affect(force);
                }
            }
        }
    }
}
