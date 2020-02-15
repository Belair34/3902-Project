using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game1
{
    public interface IEnemy
    {
        int Speed { get; set; }
        int Size { get; set; }
        List<IProjectile> GetProjectiles();
        void SetPosition(int x, int y);
        Vector2 GetPosition();
        Vector2 GetBoundary();
        void SetState(IEnemyState state);

        IEnemyState GetState();
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void MoveToPlayer();
        void Stop();
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}