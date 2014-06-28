
namespace Nebula.Particles2D.EmitterModifiers {
    public class Burst : IEmitterModifier {
        private int burstFrames;
        public Burst(int burstFrames = 1) {
            this.burstFrames = burstFrames;
        }
        public void Update(Emitter emitter, int elapsedMiliseconds) {
            burstFrames--;
            if (burstFrames < 0) {
                emitter.ParticlesPerFrame = 0;
            }
        }
    }
}
