using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game1
{
    public interface IEnemy : ICollidable, IDrawable
    {
        bool IsDone { get; set; }
        int Speed { get; set; }
        List<IProjectile> GetProjectiles();
        void SetState(IEnemyState state);
        IEnemyState GetState();
        void MoveHorizontal();
        void MoveDown();
        void MoveVertical();
        void Stop();
        void TakeDamage(int damage);
        void Die();
    }
}