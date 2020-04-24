using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public interface IProjectile: ICollidable, IDrawable
    {
        int GetDamage();
        bool IsDone { get; set; }
        int Speed { get; set; }
        int ShotDistance { get; set; }
        void Shoot();
        void Explode();

    }
}
