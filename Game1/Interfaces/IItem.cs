using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;


namespace Game1
{
    public interface IItem: ICollidable, IDrawable
    {
        int Size { get; set; }
        Vector2 GetPosition();
        void Stop();
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}