using Microsoft.Xna.Framework;

namespace Nebula.Particles2D.Modifiers.Movement
{
    /// <summary>
    /// Modifier to apply friction to individual particles
    /// </summary>
    public class Friction : IModifier
    {
        private float friction;

        public void Update(Particle2D particle, int elapsedMiliseconds)
        {
            particle.Velocity *= friction;
        }

        /// <summary>
        /// Gets or sets the friction coefficient.  Value between 0 and 1
        /// </summary>
        public float FrictionCoefficient
        {
            get { return friction; }
            set { friction = MathHelper.Clamp((1 - value), 0, 1); }
        }
    }
}