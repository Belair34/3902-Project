using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System;

namespace Game1
{
    class RupeeSprite : AbstractSprite, ISprite
    {
        Texture2D texture;
        IItem item;
        int RupeeSrcWidth = 12;
        int RupeeSrcHeight = 20;
        int RupeeDestWidth = 12;
        int RupeeDestHeight = 20;
        int RupeeSrcX = 271;
        int RupeeSrcY = 224;
        internal override void Initialize()
        {
            base.srcWidth = 12;
            base.srcHeight = 20;
            base.destWidth = 12;
            base.destHeight = 20;
            base.srcX = 271;
            base.srcY = 224;
        }

        public RupeeSprite(IDrawable drawable, Texture2D texture) : base(drawable, texture) { }
    }
}
