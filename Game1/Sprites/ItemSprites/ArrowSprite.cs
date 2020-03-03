using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System;

namespace Game1
{
    class ArrowSprite : AbstractSprite, ISprite
    {
        internal override void Initialize()
        {
            base.srcWidth = 15;
            base.srcHeight = 15;
            base.destWidth = 15;
            base.destHeight = 15;
            base.srcX = 181;
            base.srcY = 195;
        }

        public ArrowSprite(IDrawable drawable, Texture2D texture) : base(drawable, texture)
        {
            Initialize();
        }
    }
}
