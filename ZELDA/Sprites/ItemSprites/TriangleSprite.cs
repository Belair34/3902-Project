using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System;

namespace Game1
{
    class TriangleSprite : AbstractSprite, ISprite
    {
        internal override void Initialize()
        {
            base.srcWidth = 10;
            base.srcHeight = 10;
            base.destWidth = 10;
            base.destHeight = 10;
            base.srcX = 333;
            base.srcY = 288;
        }

        public TriangleSprite(IDrawable drawable, Texture2D texture) : base(drawable, texture) {    }
    }
}
