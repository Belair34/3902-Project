using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System;

namespace Game1
{
    class RupeeSprite : ISprite
    {
        Texture2D texture;
        IItem item;
        int RupeeSrcWidth = 12;
        int RupeeSrcHeight = 20;
        int RupeeDestWidth = 12;
        int RupeeDestHeight = 20;
        int RupeeSrcX = 271;
        int RupeeSrcY = 224;

        public RupeeSprite(IItem item, Texture2D texture)
        {
            this.texture = texture;
            this.item = item;
            this.RupeeDestWidth *= item.Size;
            this.RupeeDestHeight *= item.Size;
        }
        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle arrowSrcRec = new Rectangle(RupeeSrcX, RupeeSrcY, RupeeSrcWidth, RupeeSrcHeight);
            Rectangle arrowDestRec = new Rectangle((int)item.GetPosition().X, (int)item.GetPosition().Y, RupeeDestWidth, RupeeDestHeight);
            spriteBatch.Begin();
            spriteBatch.Draw(texture, arrowDestRec, arrowSrcRec, Color.White);
            spriteBatch.End();
        }
    }
}
