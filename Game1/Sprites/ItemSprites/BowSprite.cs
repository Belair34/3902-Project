using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System;

namespace Game1
{
    class BowSprite : AbstractSprite, ISprite
    {
        internal override void Initialize()
        {
            base.srcWidth = 11;
            base.srcHeight = 20;
            base.destWidth = 11;
            base.destHeight = 20;
            base.srcX = 421;
            base.srcY = 253;
        }

        public BowSprite(IDrawable drawable, Texture2D texture) : base(drawable, texture) { }

    }
}
