using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System;

namespace Game1
{
    class SwordSprite : ISprite
    {
        Texture2D texture;
        IItems item;
        int SwordSrcWidth = 10;
        int SwordSrcHeight = 20;
        int SwordDestWidth = 10;
        int SwordDestHeight = 20;
        int SwordSrcX = 63;
        int SwordSrcY = 195;

        public SwordSprite(IItems item, Texture2D texture)
        {
            this.texture = texture;
            this.item = item;
            this.SwordDestWidth *= item.Size;
            this.SwordDestHeight *= item.Size;
        }
        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle arrowSrcRec = new Rectangle(SwordSrcX, SwordSrcY, SwordSrcWidth, SwordSrcHeight);
            Rectangle arrowDestRec = new Rectangle((int)item.GetPosition().X, (int)item.GetPosition().Y, SwordDestWidth, SwordDestHeight);
            spriteBatch.Begin();
            spriteBatch.Draw(texture, arrowDestRec, arrowSrcRec, Color.White);
            spriteBatch.End();
        }
    }
}
