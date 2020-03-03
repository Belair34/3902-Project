using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System;

namespace Game1
{
    class FlashingRupeeSprite : AbstractSprite, ISprite
    {


        int curFrame = 1;
        int totalFrames = 2; /*Maybe this*/
        int delay = 0;

        internal override void Initialize()
        {
            base.srcWidth = 15;
            base.srcHeight = 15;
            base.destWidth = 15;
            base.destHeight = 15;
            base.srcX = 181;
            base.srcY = 195;
        }

        public FlashingRupeeSprite(IDrawable drawable, Texture2D texture) : base(drawable, texture) { }

        public override void Update()
        {
            delay++;
            if (delay == 7) /*Delay of frame changes*/
            {
                delay = 0;
                curFrame++;
                if (curFrame > totalFrames)
                {
                    curFrame = 1;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Rectangle RupeeSrcRec;
            Rectangle RupeeDestRec = GetDestRect();

            if (curFrame == 1) /*Change these to correct frames, might need to add/delete else if*/
            {
               base.srcX = 271;
               base.srcY = 224;
            }
            else if (curFrame == 2)
            {
                base.srcX = 241;
                base.srcY = 224;
            }
            RupeeSrcRec = new Rectangle(base.srcX, base.srcY, base.srcWidth, base.srcHeight);
            spriteBatch.Begin();
            spriteBatch.Draw(texture, RupeeDestRec, RupeeSrcRec, Color.White);
            spriteBatch.End();
        }
    }
}
