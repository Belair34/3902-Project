using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System;

namespace Game1
{
    class ArrowSprite : ISprite
    {
        Texture2D texture;
        IItem item;
        int arrowSrcWidth = 15;
        int arrowSrcHeight = 15;
        int arrowDestWidth = 15;
        int arrowDestHeight = 15;
        int arrowSrcX = 181;
        int arrowSrcY = 195;

        public ArrowSprite(IItem item, Texture2D texture)
        {
            this.texture = texture;
            this.item = item;
            this.arrowDestWidth *= item.Size;
            this.arrowDestHeight *= item.Size;
        }
        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle arrowSrcRec = new Rectangle(arrowSrcX, arrowSrcY, arrowSrcWidth, arrowSrcHeight);
            Rectangle arrowDestRec = new Rectangle((int)item.GetPosition().X, (int)item.GetPosition().Y, arrowDestWidth, arrowDestHeight);
            spriteBatch.Begin();
            spriteBatch.Draw(texture, arrowDestRec, arrowSrcRec, Color.White);
            spriteBatch.End();
        }
    }
}
