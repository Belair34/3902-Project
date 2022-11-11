using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System;

namespace Game1
{
    class MapSprite : AbstractSprite, ISprite
    {
        IItem item;
        int MapSrcWidth = 8;
        int MapSrcHeight = 16;
        int MapSrcX = 274;
        int MapSrcY = 253;
        internal override void Initialize()
        {
            base.srcWidth = MapSrcWidth;
            base.srcHeight = MapSrcHeight;
            base.destWidth = srcWidth;
            base.destHeight = srcHeight;
            base.srcX = MapSrcX;
            base.srcY = MapSrcY;
        }

        public MapSprite(IDrawable drawable, Texture2D texture) : base(drawable, texture) { }
    }
}
