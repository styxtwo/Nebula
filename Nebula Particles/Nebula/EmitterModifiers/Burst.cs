
namespace Nebula.Particles2D.EmitterModifiers {
    public class Burst : IEmitterModifier {
        private double burstMilliseconds;
        public Burst(double burstMilliseconds = 1) {
            this.burstMilliseconds = burstMilliseconds;
        }
        public void Update(Emitter emitter, double milliseconds) {
            if (burstMilliseconds <= 0) {
                emitter.particleInfo.perSecond = 0;
            }
            burstMilliseconds -= milliseconds;
        }
    }
}
