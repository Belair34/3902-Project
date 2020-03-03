using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System;

namespace Game1
{
    class SwordSprite : AbstractSprite, ISprite
    {
        Texture2D texture;
        IItem item;
        int SwordSrcWidth = 10;
        int SwordSrcHeight = 20;
        int SwordDestWidth = 10;
        int SwordDestHeight = 20;
        int SwordSrcX = 63;
        int SwordSrcY = 195;
        internal override void Initialize()
        {
            base.srcWidth = 10;
            base.srcHeight = 20;
            base.destWidth = 10;
            base.destHeight = 20;
            base.srcX = 63;
            base.srcY = 195;
        }

        public SwordSprite(IDrawable drawable, Texture2D texture) : base(drawable, texture) { }

    }
}
