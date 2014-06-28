using Microsoft.Xna.Framework;

namespace Nebula.Particles2D {
    public class Range {
        private float min;
        private float max;
        public Range(float min, float max) {
            this.min = min;
            this.max = max;
        }
        public float Lerp(double amount) {
            float clampedAmount = MathHelper.Clamp((float)amount, 0, 1);
            return MathHelper.Lerp(min, max, clampedAmount);
        }
        public float Min() {
            return min;
        }
        public float Max() {
            return max;
        }
    }
}
