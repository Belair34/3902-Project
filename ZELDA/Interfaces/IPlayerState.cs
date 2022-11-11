using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public interface IPlayerState
    {
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void SlotA();
        void SlotB();
        void Stop();
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
