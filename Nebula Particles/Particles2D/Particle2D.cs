using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Nebula.Particles2D {
    public class Particle2D {
        internal enum Status { Alive, Dead };
        private Texture2D Texture;
        private Vector2 textureOrigin;
        internal Vector2 ProjectedPosition { get; private set; }

        internal Vector2 Position { get; set; }
        internal Vector2 Velocity { get; set; }

        internal float Alpha { private get; set; }
        internal Color color { private get; set; }
        internal float Scale { private get; set; }
        internal float Rotation { private get; set; }

        internal int LifeSpan { get; private set; } // how long it will live
        internal int Age { get; private set; } // how long it has lived
        internal Status status { get; private set; }

        public Particle2D(Texture2D Texture, int LifeSpan, Color color, float Alpha = 1, float Scale = 1, float Rotation = 0) {
            this.textureOrigin = new Vector2(Texture.Width / 2f, Texture.Height / 2f);
            this.LifeSpan = LifeSpan;
            this.Texture = Texture;
            this.Alpha = Alpha;
            this.color = color;
            this.Scale = Scale;
            this.Rotation = Rotation;
        }
        public Particle2D(Particle2D template) {
            Reset(template, new Vector2(0, 0), new Vector2(0, 0));
            Texture = template.Texture;
            textureOrigin = template.textureOrigin;
            LifeSpan = template.LifeSpan;
            status = Status.Dead;
        }
        public void Reset(Particle2D template, Vector2 position, Vector2 velocity) {
            Alpha = template.Alpha;
            color = template.color;
            Scale = template.Scale;
            Rotation = template.Rotation;

            Velocity = velocity;
            Position = position;
            status = Status.Alive;
            Age = 0;
        }

        internal void Update(int elapsedMiliseconds) {
            if (status == Status.Alive && Age >= LifeSpan) {
                status = Status.Dead;
            } else {
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
            return status == Status.Alive;
        }
    }
}