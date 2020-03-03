using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public interface IProjectile: IDrawable
    {
        int Size { get; set; }
        int Speed { get; set; }
        int ShotDistance { get; set; }
        void SetPosition(int x, int y);
        Vector2 GetPosition();
        void Shoot();
        void Explode();
        void Update();
        void Draw(SpriteBatch spriteBatch);

    }
}
