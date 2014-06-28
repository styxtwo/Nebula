using Microsoft.Xna.Framework;

namespace Nebula.Particles2D.ParticleModifiers.Movement.Gravity {
    /// <summary>
    /// Modifier to gradually pull particles in a particular direction
    /// </summary>
    public class DirectionalPull : IParticleModifier {
        public Vector2 Gravity { get; set; }
        public DirectionalPull(Vector2 Gravity) {
            this.Gravity = Gravity;
        }
        public void Update(Emitter emitter, Particle particle, int elapsedMiliseconds) {
            Vector2 deltaGrav = Vector2.Multiply(Gravity, (float)elapsedMiliseconds) / 1000;
            particle.Affect(deltaGrav);
        }
    }
}
