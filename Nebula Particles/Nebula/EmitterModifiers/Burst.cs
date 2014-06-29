
namespace Nebula.Particles2D.EmitterModifiers {
    public class Burst : IEmitterModifier {
        private double burstmilliseconds;
        public Burst(double burstmilliseconds = 1) {
            this.burstmilliseconds = burstmilliseconds;
        }
        public void Update(Emitter emitter, double elapsedMilliseconds) {
            if (burstmilliseconds <= 0) {
                emitter.particleInfo.perSecond = 0;
            }
            burstmilliseconds -= elapsedMilliseconds;
        }
    }
}
