using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Nebula.Particles2D {
    public class Particle {
        private Texture2D Texture;
        private Vector2 textureOrigin;
        internal Vector2 ProjectedPosition { get; private set; }

        internal Vector2 Position { get; set; }
        internal Vector2 Velocity { get; set; }
        internal float Alpha { get; set; }
        internal Color color { get; set; }
        internal float Scale { get; set; }
        internal float Rotation { get; set; }

        internal int LifeSpan { get; private set; }
        internal int Age { get; private set; }
        public Particle(Texture2D Texture, Color color, float Alpha = 1, float Scale = 1, float Rotation = 0) {
            this.textureOrigin = new Vector2(Texture.Width / 2f, Texture.Height / 2f);
            this.Texture = Texture;
            this.Alpha = Alpha;
            this.color = color;
            this.Scale = Scale;
            this.Rotation = Rotation;
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

        internal void Update(int elapsedMiliseconds) {
            if (IsAlive()) {
                Age += elapsedMiliseconds;
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