
namespace Nebula.Particles2D.EmitterModifiers {
    public class Pulse : IEmitterModifier {
        private enum State { On, Off };
        State state = State.On;
        private int offFrames = 0;
        private int onFrames = 0;
        private int counter = 0;
        private float onEmission;
        public Pulse(int onFrames = 0, int offFrames = 100) {
            this.offFrames = offFrames;
            this.onFrames = onFrames;
        }
        public void Update(Emitter emitter, int elapsedMiliseconds) {
            if (state == State.On) {
                onEmission = emitter.ParticlesPerFrame;
                if (counter > onFrames) {
                    counter = 0;
                    emitter.ParticlesPerFrame = 0;
                    state = State.Off;
                }
            } else if (state == State.Off) {
                if (counter > offFrames) {
                    counter = 0;
                    emitter.ParticlesPerFrame = onEmission;
                    state = State.On;
                }
            }
            counter++;
        }
    }
}

