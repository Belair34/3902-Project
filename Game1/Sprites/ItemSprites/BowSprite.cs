using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System;

namespace Game1
{
    class BowSprite : ISprite
    {
        Texture2D texture;
        IItem item;
        int BowSrcWidth = 11;
        int BowSrcHeight = 20;
        int BowDestWidth = 11;
        int BowDestHeight = 20;
        int BowSrcX = 421;
        int BowSrcY = 253;

        public BowSprite(IItem item, Texture2D texture)
        {
            this.texture = texture;
            this.item = item;
            this.BowDestWidth *= item.Size;
            this.BowDestHeight *= item.Size;
        }
        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle arrowSrcRec = new Rectangle(BowSrcX, BowSrcY, BowSrcWidth, BowSrcHeight);
            Rectangle arrowDestRec = new Rectangle((int)item.GetPosition().X, (int)item.GetPosition().Y, BowDestWidth, BowDestHeight);
            spriteBatch.Begin();
            spriteBatch.Draw(texture, arrowDestRec, arrowSrcRec, Color.White);
            spriteBatch.End();
        }
    }
}
