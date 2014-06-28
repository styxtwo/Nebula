using Microsoft.Xna.Framework;
namespace Nebula.Particles2D.Modifiers.AgeTransform {
    public class Scale : AbstractAgeTransform<float> {
        public Scale(float Start, float End, int Cycles = 1)
            : base(Start, End, Cycles) {
        }
        public override void Update(Particle2D particle, int elapsedMiliseconds) {
            float amount = this.InterpolateAmount(particle);
            particle.Scale = MathHelper.Lerp(this.Start, this.End, amount);
        }
    }
}
