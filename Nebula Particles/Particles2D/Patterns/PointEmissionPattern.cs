using System;
using Microsoft.Xna.Framework;

namespace Nebula.Particles2D.Patterns {
    public class PointEmissionPattern : IEmissionPattern {
        public Vector2 CalculateParticlePosition(Random random, Vector2 emitPosition) {
            return emitPosition;
        }
    }
}