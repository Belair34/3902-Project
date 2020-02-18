using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System;

namespace Game1
{
    class ClockSprite : ISprite
    {
        Texture2D texture;
        IItems item;
        int ClockSrcWidth = 12;
        int ClockSrcHeight = 20;
        int ClockDestWidth = 12;
        int ClockDestHeight = 20;
        int ClockSrcX = 391;
        int ClockSrcY = 163;

        public ClockSprite(IItems item, Texture2D texture)
        {
            this.texture = texture;
            this.item = item;
            this.ClockDestWidth *= item.Size;
            this.ClockDestHeight *= item.Size;
        }
        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle arrowSrcRec = new Rectangle(ClockSrcX, ClockSrcY, ClockSrcWidth, ClockSrcHeight);
            Rectangle arrowDestRec = new Rectangle((int)item.GetPosition().X, (int)item.GetPosition().Y, ClockDestWidth, ClockDestHeight);
            spriteBatch.Begin();
            spriteBatch.Draw(texture, arrowDestRec, arrowSrcRec, Color.White);
            spriteBatch.End();
        }
    }
}
