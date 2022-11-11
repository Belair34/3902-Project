using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System;

namespace Game1
{
    class CompassSprite : AbstractSprite, ISprite
    {
        IItem item;
        int CompassSrcWidth = 11;
        int CompassSrcHeight = 12;
        int CompassSrcX = 392;
        int CompassSrcY = 257;
        internal override void Initialize()
        {
            base.srcWidth = CompassSrcWidth;
            base.srcHeight = CompassSrcHeight;
            base.destWidth = srcWidth;
            base.destHeight = srcHeight;
            base.srcX = CompassSrcX;
            base.srcY = CompassSrcY;
        }

        public CompassSprite(IDrawable drawable, Texture2D texture) : base(drawable, texture) { }
    }
}
