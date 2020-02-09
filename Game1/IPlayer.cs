using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1 {
    public interface IPlayer
    {
        int Speed { get; set; }
        int Size{ get; set;}
        void SetPosition(int x, int y);
        Vector2 GetPosition();
        void SetState(IPlayerState state);

        IPlayerState GetState();
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