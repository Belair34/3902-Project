﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public interface IGameState
    {
        void SetRoom(IRoom room);
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
