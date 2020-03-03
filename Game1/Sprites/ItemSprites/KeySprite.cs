using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System;

namespace Game1
{
    class KeySprite : AbstractSprite, ISprite
    {
        Texture2D texture;
        IItem item;
        int KeySrcWidth = 11;
        int KeySrcHeight = 20;
        int KeyDestWidth = 11;
        int KeyDestHeight = 20;
        int KeySrcX = 422;
        int KeySrcY = 164;
        internal override void Initialize()
        {
            base.srcWidth = 15;
            base.srcHeight = 15;
            base.destWidth = 15;
            base.destHeight = 15;
            base.srcX = 181;
            base.srcY = 195;
        }

        public KeySprite(IDrawable drawable, Texture2D texture) : base(drawable, texture) { }
    }
}
