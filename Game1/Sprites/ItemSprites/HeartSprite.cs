using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System;

namespace Game1
{
    class HeartSprite : ISprite
    {
        Texture2D texture;
        IItem item;
        int HeartSrcWidth = 15;
        int HeartSrcHeight = 15;
        int HeartDestWidth = 15;
        int HeartDestHeight = 15;
        int HeartSrcX = 300;
        int HeartSrcY = 195;

        public HeartSprite(IItem item, Texture2D texture)
        {
            this.texture = texture;
            this.item = item;
            this.HeartDestWidth *= item.Size;
            this.HeartDestHeight *= item.Size;
        }
        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle arrowSrcRec = new Rectangle(HeartSrcX, HeartSrcY, HeartSrcWidth, HeartSrcHeight);
            Rectangle arrowDestRec = new Rectangle((int)item.GetPosition().X, (int)item.GetPosition().Y, HeartDestWidth, HeartDestHeight);
            spriteBatch.Begin();
            spriteBatch.Draw(texture, arrowDestRec, arrowSrcRec, Color.White);
            spriteBatch.End();
        }
    }
}
