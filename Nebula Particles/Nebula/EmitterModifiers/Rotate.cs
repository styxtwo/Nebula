namespace Nebula.Particles2D.EmitterModifiers {
    public class Rotate : IEmitterModifier {
        private float speed;
        public Rotate(float speed) {
            this.speed = speed;
        }
        public void Update(Emitter emitter, double milliseconds) {
            float rotation = (float)(speed / 1000 * milliseconds);
            emitter.particleInfo.angle = new Range(emitter.particleInfo.angle.Min() + rotation, emitter.particleInfo.angle.Max() + rotation);
        }
    }
}
