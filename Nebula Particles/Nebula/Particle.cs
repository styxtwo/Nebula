using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Nebula.Particles2D {
    public class Particle {
        internal Vector2 ProjectedPosition { get; private set; }
        internal double LifeSpan { get; private set; }
        internal double Age { get; private set; }
        internal Vector2 Position { get; set; }
        internal Vector2 Velocity { get; set; }
        internal float Rotation { get; set; }
        internal Color color { get; set; }
        internal float Alpha { get; set; }
        internal float Scale { get; set; }
        private Vector2 textureOrigin;
        private Texture2D Texture;
        public Particle(Texture2D Texture, float Alpha = 1, float Scale = 1, float Rotation = 0) {
            if (Texture != null) {
                this.textureOrigin = new Vector2(Texture.Width / 2f, Texture.Height / 2f);
            } else {
                this.textureOrigin = new Vector2(0, 0);
            } this.Rotation = Rotation;
            this.color = Color.White;
            this.Texture = Texture;
            this.Scale = Scale;
            this.Alpha = Alpha;
        }
        public Particle(Particle template) {
            Reset(template, new Vector2(0, 0), new Vector2(0, 0), 0);
            this.textureOrigin = template.textureOrigin;
            this.Texture = template.Texture;
        }
        public void Reset(Particle template, Vector2 position, Vector2 velocity, int LifeSpan) {
            this.Rotation = template.Rotation;
            this.Alpha = template.Alpha;
            this.color = template.color;
            this.Scale = template.Scale;
            this.Velocity = velocity;
            this.Position = position;
            this.LifeSpan = LifeSpan;
            this.Age = 0;
        }
        internal void Update(double milliseconds) {
            if (IsAlive()) {
                Age += milliseconds;
                Position += Velocity;
                ProjectedPosition = Position + Velocity;
            }
        }
        internal void Affect(Vector2 attraction) {
            Velocity += attraction;
        }
        internal void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(Texture, Position, null, color * Alpha, Rotation, textureOrigin, Scale, SpriteEffects.None, 0);
        }
        internal bool IsAlive() {
            return Age <= LifeSpan;
        }
    }
}