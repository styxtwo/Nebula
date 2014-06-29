namespace Nebula.Particles2D.EmitterModifiers {
    public interface IEmitterModifier {
        void Update(Emitter emitter, double elapsedMilliseconds);
    }
}