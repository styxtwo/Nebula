namespace Nebula.Particles2D.ParticleModifiers.AgeTransform {
    public abstract class AbstractAgeTransform<T> : IParticleModifier {
        public T Start { get; set; }
        public T End { get; set; }
        public int Cycles { get; set; }
        public AbstractAgeTransform(T Start, T End, int Cycles = 1) {
            this.Start = Start;
            this.End = End;
            this.Cycles = Cycles;
        }
        internal double InterpolationAmount(Particle particle) {
            double age = particle.Age;
            double lifeSpan = particle.LifeSpan;
            return (age / (lifeSpan / Cycles)) % 1;
        }
        public abstract void Update(Emitter emitter, Particle particle, double milliseconds);
    }
}
