using Microsoft.Xna.Framework;

namespace Nebula.Particles2D.ParticleModifiers.Movement {
    /// <summary>
    /// Modifier to contain particles within a rectangular container
    /// </summary>
    public class HorizontalLineContainer : IParticleModifier {
        public float Bounce { get; set; }
        public float Friction { get; set; }
        private int y;
        public HorizontalLineContainer(int y, float Bouce = 0, float Friction = 1) {
            this.y = y;
            this.Bounce = Bouce;
            this.Friction = Friction;
        }
        public void Update(Emitter emitter, Particle particle, double milliseconds) {
            Vector2 particleVelocity = particle.Velocity;
            if (particle.ProjectedPosition.Y > (y + emitter.Position.Y)) {
                particleVelocity.Y *= -Bounce;
                particleVelocity.X *= Friction;
            }
            particle.Velocity = particleVelocity;
        }
    }
}