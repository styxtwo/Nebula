namespace Nebula.Particles2D.Modifiers {
    public interface IModifier {
        void Update(Particle2D particle, int elapsedMiliseconds);
    }
}