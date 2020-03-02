using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game1
{
    public interface IEnemy : ICollidable
    {
        
        int Speed { get; set; }
        int Size { get; set; }
        List<IProjectile> GetProjectiles();
        void SetPosition(int x, int y);
        Vector2 GetPosition();
        Vector2 GetBoundary();
        void SetState(IEnemyState state);

        IEnemyState GetState();
        void MoveHorizontal();
        void MoveDown();
        void MoveVertical();
        void Stop();
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}