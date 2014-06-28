namespace Nebula.Particles2D.ParticleModifiers {
    public interface IParticleModifier {
        void Update(Emitter emitter, Particle particle, int elapsedMiliseconds);
    }
}