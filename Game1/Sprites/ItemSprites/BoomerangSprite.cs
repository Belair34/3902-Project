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
            base.srcHeight = 8;
            base.destWidth = 5;
            base.destHeight = 8;
            base.srcX = 362;
            base.srcY = 148;
        }

        public BoomerangSprite(IDrawable drawable, Texture2D texture) : base(drawable, texture) { }
    }
}
