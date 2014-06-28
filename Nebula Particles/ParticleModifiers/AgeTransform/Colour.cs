using Microsoft.Xna.Framework;
namespace Nebula.Particles2D.ParticleModifiers.AgeTransform {
    public class Colour : AbstractAgeTransform<Color> {
        public Colour(Color Start, Color End, int Cycles = 1)
            : base(Start, End, Cycles) {
        }
        public override void Update(Emitter emitter, Particle particle, int elapsedMiliseconds) {
            float amount = this.InterpolateAmount(particle);
            int r = (int)MathHelper.Lerp(this.Start.R, this.End.R, amount);
            int g = (int)MathHelper.Lerp(this.Start.G, this.End.G, amount);
            int b = (int)MathHelper.Lerp(this.Start.B, this.End.B, amount);
            particle.color = new Microsoft.Xna.Framework.Color((byte)r, (byte)g, (byte)b);
        }
    }
}
