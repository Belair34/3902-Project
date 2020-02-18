using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System;

namespace Game1
{
    class BoomerangSprite : ISprite
    {
        Texture2D texture;
        IItems item;
        int BoomerangSrcWidth = 5;
        int BoomerangSrcHeight = 10;
        int BoomerangDestWidth = 5;
        int BoomerangDestHeight = 10;
        int BoomerangSrcX = 0;
        int BoomerangSrcY = 111;

        public BoomerangSprite(IItems item, Texture2D texture)
        {
            this.texture = texture;
            this.item = item;
            this.BoomerangDestWidth *= item.Size;
            this.BoomerangDestHeight *= item.Size;
        }
        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle arrowSrcRec = new Rectangle(BoomerangSrcX, BoomerangSrcY, BoomerangSrcWidth, BoomerangSrcHeight);
            Rectangle arrowDestRec = new Rectangle((int)item.GetPosition().X, (int)item.GetPosition().Y, BoomerangDestWidth, BoomerangDestHeight);
            spriteBatch.Begin();
            spriteBatch.Draw(texture, arrowDestRec, arrowSrcRec, Color.White);
            spriteBatch.End();
        }
    }
}
