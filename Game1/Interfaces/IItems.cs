using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;


namespace Game1
{
    public interface IItems: ICollidable
    {
        int Size { get; set; }
        void SetPosition(int x, int y);
        Vector2 GetPosition();
        Vector2 GetBoundary();

        void Stop();
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}