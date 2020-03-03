using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System;

namespace Game1
{
    class BombSprite : AbstractSprite, ISprite
    {
        internal override void Initialize()
        {
            base.srcWidth = 12;
            base.srcHeight = 15;
            base.destWidth = 12;
            base.destHeight = 15;
            base.srcX = 360;
            base.srcY = 225;
        }

        public BombSprite(IDrawable drawable, Texture2D texture) : base(drawable, texture) { }

    }
}
