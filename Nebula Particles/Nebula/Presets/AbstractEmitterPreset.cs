using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace Nebula.Particles2D.Presets {
    public class AbstractEmitterPreset : IEmitter {
        private List<IEmitter> emitterList = new List<IEmitter>();
        private List<Vector2> offsetList = new List<Vector2>();
        private Vector2 position = new Vector2(0, 0);
        public AbstractEmitterPreset() {
        }
        public void Update(double milliseconds) {
            foreach (IEmitter emitter in emitterList) {
                emitter.Update(milliseconds);
            }
        }
        public void Draw(SpriteBatch spriteBatch) {
            foreach (IEmitter emitter in emitterList) {
                emitter.Draw(spriteBatch);
            }
        }
        public void AddEmitter(IEmitter emitter) {
            if (!emitterList.Contains(emitter)) {
                emitterList.Add(emitter);
                offsetList.Add(emitter.Position);
            }
        }
        public Vector2 Position {
            get {
                return this.position;
            }
            set {
                this.position = value;
                for (int i = 0; i < emitterList.Count; i++) {
                    emitterList[i].Position = this.position + offsetList[i];
                }
            }
        }
        public int GetAliveParticles() {
            int sum = 0;
            foreach (IEmitter emitter in emitterList) {
                sum += emitter.GetAliveParticles();
            }
            return sum;
        }
        public int GetDeadParticles() {
            int sum = 0;
            foreach (IEmitter emitter in emitterList) {
                sum += emitter.GetDeadParticles();
            }
            return sum;
        }
    }
}
