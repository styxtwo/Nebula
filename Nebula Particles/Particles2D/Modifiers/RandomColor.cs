using Microsoft.Xna.Framework;
using System;

namespace Nebula.Particles2D.Modifiers {
    public class RandomColor : IModifier {
        public void Update(Particle2D particle, int elapsedMiliseconds) {
            if (particle.Age == 0) {
                Random random = new Random();
                int r = random.Next(255);
                int g = random.Next(255);
                int b = random.Next(255);
                particle.color = new Microsoft.Xna.Framework.Color((byte)r, (byte)g, (byte)b);
            }
        }
    }
}
