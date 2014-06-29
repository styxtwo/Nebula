using Microsoft.Xna.Framework;
using System;

namespace Nebula.Particles2D.ParticleModifiers {
    public class RandomColor : IParticleModifier {
        private Random random;
        public RandomColor(Random random) {
            this.random = random;
        }
        public void Update(Emitter emitter, Particle particle, double milliseconds) {
            if (particle.Age == 0) {
                int r = random.Next(255);
                int g = random.Next(255);
                int b = random.Next(255);
                particle.color = new Microsoft.Xna.Framework.Color((byte)r, (byte)g, (byte)b);
            }
        }
    }
}
