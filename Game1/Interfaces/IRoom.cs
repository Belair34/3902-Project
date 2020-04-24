using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public interface IRoom
    {
        bool Transitioning { get; set; }
        void ResetCamera();
        void SetBorders();
        void SpawnLink(int spawnDoor);
        void TransitionLeft();
        void TransitionRight();
        void TransitionUp();
        void TransitionDown();
        void IncrementSourcePosition(int distance, bool vertical);
        void Update();
        void Draw(SpriteBatch spriteBatch);

    }
}
