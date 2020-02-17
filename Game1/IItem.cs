﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game1
{
    public interface IItem
    {
        int Size { get; set; }
        List<IItem> GetItems();
        void SetPosition(int x, int y);
        Vector2 GetPosition();
        Vector2 GetBoundary();

        void Stop();
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}