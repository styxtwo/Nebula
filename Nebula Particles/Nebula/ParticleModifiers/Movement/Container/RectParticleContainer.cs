using Microsoft.Xna.Framework;

namespace Nebula.Particles2D.ParticleModifiers.Movement {
    /// <summary>
    /// Modifier to contain particles within a rectangular container
    /// </summary>
    public class RectParticleContainer : IParticleModifier {
        private float bounce;
        public RectParticleContainer(Rectangle Container, float bouce = 0) {
            this.Container = Container;
            this.Bounce = bouce;
        }
        public void Update(Emitter emitter, Particle particle, double milliseconds) {
            Vector2 particleVelocity = particle.Velocity;

            if (particle.ProjectedPosition.Y < Container.Top || particle.ProjectedPosition.Y > Container.Bottom)
                particleVelocity.Y *= -bounce;
            else if (particle.ProjectedPosition.X < Container.Left || particle.ProjectedPosition.X > Container.Right)
                particleVelocity.X *= -bounce;

            particle.Velocity = particleVelocity;
        }

        /// <summary>
        /// Gets or sets the rectangle to contain particles in
        /// </summary>
        public Rectangle Container { get; set; }

        /// <summary>
        /// Gets or sets the "bounciness" of the container walls.  Value between 0 and 1
        /// </summary>
        public float Bounce {
            get { return bounce; }
            set { bounce = MathHelper.Clamp(value, 0, 1); }
        }
    }
}
