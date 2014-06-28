using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Nebula.Particles2D {
    public interface IEmitter {
        void Update(int elapsedMiliseconds);
        void Draw(SpriteBatch spriteBatch);
        int GetAliveParticles();
        int GetDeadParticles();
        Vector2 Position { get; set; }
    }
}
