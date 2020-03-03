using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System;

namespace Game1
{
    class MapSprite : AbstractSprite, ISprite
    {
        Texture2D texture;
        IItem item;
        int MapSrcWidth = 10;
        int MapSrcHeight = 20;
        int MapDestWidth = 10;
        int MapDestHeight = 20;
        int MapSrcX = 272;
        int MapSrcY = 253;
        internal override void Initialize()
        {
            base.srcWidth = 10;
            base.srcHeight = 20;
            base.destWidth = 10;
            base.destHeight = 20;
            base.srcX = 272;
            base.srcY = 253;
        }

        public MapSprite(IDrawable drawable, Texture2D texture) : base(drawable, texture) { }
    }
}
