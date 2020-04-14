using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System;

namespace Game1
{
    class KeySprite : AbstractSprite, ISprite
    {
        IItem item;
        int KeySrcWidth = 11;
        int KeySrcHeight = 20;
        int KeyDestWidth = 11;
        int KeyDestHeight = 20;
        int KeySrcX = 422;
        int KeySrcY = 164;
        internal override void Initialize()
        {
            base.srcWidth = 8;
            base.srcHeight = 16;
            base.destWidth = 8;
            base.destHeight = 16;
            base.srcX = 364;
            base.srcY = 255;
        }

        public KeySprite(IDrawable drawable, Texture2D texture) : base(drawable, texture) { }
    }
}
