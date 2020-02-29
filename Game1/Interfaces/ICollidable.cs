using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public interface ICollidable
    {
        void CheckCollisions(ICollidable collidable, Border border);
        void PlayerCollision(ICollidable collidable);
        void EnemyCollision(ICollidable collidable);
        void ProjectileCollision(ICollidable collidable);
        void BlockCollision(ICollidable collidable);
        void BorderCollision();
        void SetPosition(int x, int y);
        Rectangle GetHitBox();
    }
}
