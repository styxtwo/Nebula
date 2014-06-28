using System;
using Microsoft.Xna.Framework;

namespace Nebula.Particles2D.Patterns {
    public class LineEmissionPattern : IEmissionPattern {
        private readonly float width;
        private readonly float angle;
        public LineEmissionPattern(float width, float angle = 0) {
            this.width = width;
            this.angle = angle;
        }

        public Vector2 CalculateParticlePosition(Random random, Vector2 emitPosition) {
            float randomWidth = width * (float)random.NextDouble();
            Vector2 offset = new Vector2((float)Math.Cos(angle) * randomWidth, (float)Math.Sin(angle) * randomWidth);

            return emitPosition + offset;
        }
    }
}
