using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System;

namespace Game1
{
    class HeartSprite : AbstractSprite, ISprite
    {
        internal override void Initialize()
        {
            base.srcWidth = 15;
            base.srcHeight = 15;
            base.destWidth = 15;
            base.destHeight = 15;
            base.srcX = 300;
            base.srcY = 195;
        }

        public HeartSprite(IDrawable drawable, Texture2D texture) : base(drawable, texture) { }

    }
}
