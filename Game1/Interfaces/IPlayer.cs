using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game1 {
    public interface IPlayer : ICollidable, IDrawable
    {
        int Speed { get; set; }
        new int Size{ get; set;}
        bool IsRangActive { get; set; }
        List<IProjectile> GetProjectiles();
        new void SetPosition(int x, int y);
        new Vector2 GetPosition();
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
    }
}