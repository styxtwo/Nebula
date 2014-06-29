using Microsoft.Xna.Framework;
namespace Nebula.Particles2D.ParticleModifiers.AgeTransform {
    public class Scale : AbstractAgeTransform<float> {
        public Scale(float Start, float End, int Cycles = 1)
            : base(Start, End, Cycles) {
        }
        public override void Update(Emitter emitter, Particle particle, double elapsedMilliseconds) {
            float amount = (float) this.InterpolationAmount(particle);
            particle.Scale = MathHelper.Lerp(this.Start, this.End, amount);
        }
    }
}
