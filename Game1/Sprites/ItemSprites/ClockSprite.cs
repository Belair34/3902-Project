using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System;

namespace Game1
{
    class ClockSprite : AbstractSprite, ISprite
    {

        internal override void Initialize()
        {
            base.srcWidth = 12;
            base.srcHeight = 20;
            base.destWidth = 12;
            base.destHeight = 20;
            base.srcX = 391;
            base.srcY = 163;
        }

        public ClockSprite(IDrawable drawable, Texture2D texture) : base(drawable, texture) { }

    }
}
