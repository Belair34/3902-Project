using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System;

namespace Game1
{
    class KeySprite : ISprite
    {
        Texture2D texture;
        IItems item;
        int KeySrcWidth = 11;
        int KeySrcHeight = 20;
        int KeyDestWidth = 11;
        int KeyDestHeight = 20;
        int KeySrcX = 422;
        int KeySrcY = 164;

        public KeySprite(IItems item, Texture2D texture)
        {
            this.texture = texture;
            this.item = item;
            this.KeyDestWidth *= item.Size;
            this.KeyDestHeight *= item.Size;
        }
        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle arrowSrcRec = new Rectangle(KeySrcX, KeySrcY, KeySrcWidth, KeySrcHeight);
            Rectangle arrowDestRec = new Rectangle((int)item.GetPosition().X, (int)item.GetPosition().Y, KeyDestWidth, KeyDestHeight);
            spriteBatch.Begin();
            spriteBatch.Draw(texture, arrowDestRec, arrowSrcRec, Color.White);
            spriteBatch.End();
        }
    }
}
