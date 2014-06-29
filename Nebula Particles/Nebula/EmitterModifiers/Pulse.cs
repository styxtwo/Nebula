
namespace Nebula.Particles2D.EmitterModifiers {
    public class Pulse : IEmitterModifier {
        private enum State { On, Off };
        State state = State.On;
        private double offmilliseconds = 0;
        private double onmilliseconds = 0;
        private double milliseconds = 0;
        private float standardEmission;
        public Pulse(int onMilliseconds = 0, int offMilliseconds = 1000) {
            this.offmilliseconds = offMilliseconds;
            this.onmilliseconds = onMilliseconds;
        }
        public void Update(Emitter emitter, double elapsedMilliseconds) {
            if (state == State.On) {
                standardEmission = emitter.particleInfo.perSecond;
                if (milliseconds > onmilliseconds) {
                    milliseconds = 0;
                    emitter.particleInfo.perSecond = 0;
                    state = State.Off;
                }
            } else if (state == State.Off) {
                if (milliseconds > offmilliseconds) {
                    milliseconds = 0;
                    emitter.particleInfo.perSecond = standardEmission;
                    state = State.On;
                }
            }
            milliseconds += elapsedMilliseconds;
        }
    }
}

