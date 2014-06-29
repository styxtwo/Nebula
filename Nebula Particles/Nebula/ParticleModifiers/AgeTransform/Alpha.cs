using Microsoft.Xna.Framework;
namespace Nebula.Particles2D.ParticleModifiers.AgeTransform {
    public class Alpha : AbstractAgeTransform<float> {
        public Alpha(float Start = 1, float End = 0, int Cycles = 1)
            : base(Start, End, Cycles) {
        }
        public override void Update(Emitter emitter, Particle particle, double milliseconds) {
            float amount = (float)this.InterpolationAmount(particle);
            particle.Alpha = MathHelper.Lerp(this.Start, this.End, amount);
        }
    }
}
