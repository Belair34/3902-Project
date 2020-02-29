using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game1 {
    public interface IPlayer : ICollidable
    {
        int Speed { get; set; }
        int Size{ get; set;}
        List<IProjectile> GetProjectiles();
        
        Vector2 GetPosition();
        void SetState(IPlayerState state);
        IInventory GetInventory();
        IPlayerState GetState();
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void SlotA();
        void SlotB();
        void Stop();
        void TakeDamage(int damage);
        void Update();
        void Draw(SpriteBatch spriteBatch);

    }
}