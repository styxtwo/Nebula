
namespace Nebula.Particles2D.EmitterModifiers {
    public class Pulse : IEmitterModifier {
        private enum State { On, Off };
        State state = State.On;
        private double offTime = 0;
        private double onTime = 0;
        private double time = 0;
        private float standardEmission;
        public Pulse(int onMilliseconds = 0, int offMilliseconds = 1000) {
            this.offTime = offMilliseconds;
            this.onTime = onMilliseconds;
        }
        public void Update(Emitter emitter, double elapsedMilliseconds) {
            if (state == State.On) {
                standardEmission = emitter.particleInfo.perSecond;
                if (time > onTime) {
                    time = 0;
                    emitter.particleInfo.perSecond = 0;
                    state = State.Off;
                }
            } else if (state == State.Off) {
                if (time > offTime) {
                    time = 0;
                    emitter.particleInfo.perSecond = standardEmission;
                    state = State.On;
                }
            }
            time += elapsedMilliseconds;
        }
    }
}

