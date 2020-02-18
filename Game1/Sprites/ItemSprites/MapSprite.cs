using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System;

namespace Game1
{
    class MapSprite : ISprite
    {
        Texture2D texture;
        IItems item;
        int MapSrcWidth = 10;
        int MapSrcHeight = 20;
        int MapDestWidth = 10;
        int MapDestHeight = 20;
        int MapSrcX = 272;
        int MapSrcY = 253;

        public MapSprite(IItems item, Texture2D texture)
        {
            this.texture = texture;
            this.item = item;
            this.MapDestWidth *= item.Size;
            this.MapDestHeight *= item.Size;
        }
        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle arrowSrcRec = new Rectangle(MapSrcX, MapSrcY, MapSrcWidth, MapSrcHeight);
            Rectangle arrowDestRec = new Rectangle((int)item.GetPosition().X, (int)item.GetPosition().Y, MapDestWidth, MapDestHeight);
            spriteBatch.Begin();
            spriteBatch.Draw(texture, arrowDestRec, arrowSrcRec, Color.White);
            spriteBatch.End();
        }
    }
}
