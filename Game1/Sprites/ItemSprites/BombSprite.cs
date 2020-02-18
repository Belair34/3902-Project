using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System;

namespace Game1
{
    class BombSprite : ISprite
    {
        Texture2D texture;
        IItems item;
        int bombSrcWidth = 12;
        int bombSrcHeight = 15;
        int bombDestWidth = 12;
        int bombDestHeight = 15;
        int bombSrcX = 360;
        int bombSrcY = 225;

        public BombSprite(IItems item, Texture2D texture)
        {
            this.texture = texture;
            this.item = item;
            this.bombDestWidth *= item.Size;
            this.bombDestHeight *= item.Size;
        }
        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle arrowSrcRec = new Rectangle(bombSrcX, bombSrcY, bombSrcWidth, bombSrcHeight);
            Rectangle arrowDestRec = new Rectangle((int)item.GetPosition().X, (int)item.GetPosition().Y, bombDestWidth, bombDestHeight);
            spriteBatch.Begin();
            spriteBatch.Draw(texture, arrowDestRec, arrowSrcRec, Color.White);
            spriteBatch.End();
        }
    }
}
