using Microsoft.Xna.Framework;

namespace Nebula.Particles2D.Modifiers.Movement.Gravity {
    /// <summary>
    /// Modifier to gradually pull particles in a particular direction
    /// </summary>
    public class DirectionalPull : IModifier {
        public Vector2 Gravity { get; set; }
        public DirectionalPull(Vector2 Gravity) {
            this.Gravity = Gravity;
        }
        public void Update(Particle2D particle, int elapsedMiliseconds) {
            Vector2 deltaGrav = Vector2.Multiply(Gravity, (float)elapsedMiliseconds) / 1000;
            particle.Affect(deltaGrav);
        }
    }
}
