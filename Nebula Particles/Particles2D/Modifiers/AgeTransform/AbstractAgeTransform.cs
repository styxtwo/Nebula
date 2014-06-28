namespace Nebula.Particles2D.Modifiers.AgeTransform {
    public abstract class AbstractAgeTransform<T> : IModifier {
        public T Start { get; set; }
        public T End { get; set; }
        public int Cycles { get; set; }
        public AbstractAgeTransform(T Start, T End, int Cycles = 1) {
            this.Start = Start;
            this.End = End;
            this.Cycles = Cycles;
        }
        internal float InterpolateAmount(Particle2D particle) {
            float age = particle.Age;
            float lifeSpan = particle.LifeSpan;
            return (age / (lifeSpan / Cycles)) % 1;
        }
        public abstract void Update(Particle2D particle, int elapsedMiliseconds);
    }
}
