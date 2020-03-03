using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1.PlayerSprites
{
    class LinkIdleDown : AbstractSprite, ISprite
    {
        internal override void Initialize()
        {
            base.srcWidth = 15;
            base.srcHeight = 16;
            base.destWidth = 15;
            base.destHeight = 16;
            base.srcX = 0; /*Change this*/
            base.srcY = 0;  /*and this*/
        }


        public LinkIdleDown(IDrawable drawable, Texture2D texture) : base(drawable, texture)
        {

        }
    }
}
