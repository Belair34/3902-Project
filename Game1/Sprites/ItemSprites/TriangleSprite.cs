using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System;

namespace Game1
{
    class TriangleSprite : AbstractSprite, ISprite
    {
        IItem item;
        int SrcWidth = 10;
        int SrcHeight = 10;
        int SrcX = 363;
        int SrcY = 288;
        internal override void Initialize()
        {
            base.srcWidth = SrcWidth;
            base.srcHeight = SrcHeight;
            base.destWidth = srcWidth;
            base.destHeight = destHeight;
            base.srcX = SrcX;
            base.srcY = SrcY;
        }

        public TriangleSprite(IDrawable drawable, Texture2D texture) : base(drawable, texture) { }
    }
}
