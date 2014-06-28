using Microsoft.Xna.Framework;

namespace Nebula.Particles2D.ParticleModifiers.Movement {
    /// <summary>
    /// Modifier to contain particles within a rectangular container
    /// </summary>
    public class HorizontalLineContainer : IParticleModifier {
        private float bounce;
        public float Friction { get; set; }
        private int y;
        public HorizontalLineContainer(int y, float Bouce = 0, float Friction = 1) {
            this.y = y;
            this.Bounce = Bouce;
            this.Friction = Friction;
        }
        public void Update(Emitter emitter, Particle particle, int elapsedMiliseconds) {
            Vector2 particleVelocity = particle.Velocity;
            if (particle.ProjectedPosition.Y > y) {
                particleVelocity.Y *= -bounce;
                particleVelocity.X *= Friction;
            }
            particle.Velocity = particleVelocity;
        }
        public float Bounce {
            get { return bounce; }
            set { bounce = MathHelper.Clamp(value, 0, 1); }
        }
    }
}