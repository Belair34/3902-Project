using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;


namespace Game1
{
    public interface IItem: ICollidable, IDrawable
    {
        void Consume();
        bool IsDone { get; set; }
    }
}