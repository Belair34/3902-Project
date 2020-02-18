using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System;

namespace Game1
{
    class FlashingRupeeSprite : ISprite
    {
        Texture2D texture;
        IItems item;
        int RupeeSrcWidth = 12;
        int RupeeSrcHeight = 20;
        int RupeeDestWidth = 12;
        int RupeeDestHeight = 20;
        int RupeeSrcX = 271;
        int RupeeSrcY = 224;
        int curFrame = 1;
        int totalFrames = 2; /*Maybe this*/
        int delay = 0;

        public FlashingRupeeSprite(IItems item, Texture2D texture)
        {
            this.texture = texture;
            this.item = item;
            this.RupeeDestWidth *= item.Size;
            this.RupeeDestHeight *= item.Size;
        }
        public void Update()
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

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle RupeeSrcRec;
            Rectangle RupeeDestRec = new Rectangle((int)item.GetPosition().X, (int)item.GetPosition().Y, RupeeDestWidth, RupeeDestHeight);

            if (curFrame == 1) /*Change these to correct frames, might need to add/delete else if*/
            {
               RupeeSrcX = 271;
               RupeeSrcY = 224;
            }
            else if (curFrame == 2)
            {
                RupeeSrcX = 241;
                RupeeSrcY = 224;
            }
            RupeeSrcRec = new Rectangle(RupeeSrcX, RupeeSrcY, RupeeSrcWidth, RupeeSrcHeight);
            spriteBatch.Begin();
            spriteBatch.Draw(texture, RupeeDestRec, RupeeSrcRec, Color.White);
            spriteBatch.End();
        }
    }
}
