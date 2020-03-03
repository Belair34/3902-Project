using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System;

namespace Game1
{
    class BoomerangSprite : AbstractSprite, ISprite
    {
        internal override void Initialize()
        {
            base.srcWidth = 5;
            base.srcHeight = 10;
            base.destWidth = 5;
            base.destHeight = 10;
            base.srcX = 0;
            base.srcY = 111;
        }

        public BoomerangSprite(IDrawable drawable, Texture2D texture) : base(drawable, texture) { }
    }
}
