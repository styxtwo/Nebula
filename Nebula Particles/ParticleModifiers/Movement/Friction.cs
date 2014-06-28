namespace Nebula.Particles2D.ParticleModifiers.Movement {
    /// <summary>
    /// Modifier to apply friction to individual particles
    /// </summary>
    public class Friction : IParticleModifier {
        public float Coefficient { get; set; }
        public Friction(float Coefficient) {
            this.Coefficient = Coefficient;
        }
        public void Update(Emitter emitter, Particle particle, int elapsedMiliseconds) {
            particle.Velocity *= Coefficient;
        }
    }
}