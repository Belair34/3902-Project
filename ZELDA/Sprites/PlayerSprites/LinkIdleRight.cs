using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1.PlayerSprites
{
    class LinkIdleRight :ISprite
    {
        Texture2D texture;
        IPlayer player;
        int srcWidth = 15;
        int srcHeight = 16;
        int destWidth = 15;
        int destHeight = 16;
        int srcX = 90; /*Change this*/
        int srcY = 30;  /*and this*/

        public LinkIdleRight(IPlayer player, Texture2D texture)
        {
            this.texture = texture;
            this.player = player;
            this.destWidth *= player.Size;
            this.destHeight *= player.Size;
        }
        public void Update()
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destRec = new Rectangle((int)player.GetPosition().X, (int)player.GetPosition().Y, destWidth, destHeight);
            Rectangle srcRec;
            srcRec = new Rectangle(srcX, srcY, srcWidth, srcHeight);
            spriteBatch.Begin();
            spriteBatch.Draw(texture, destRec, srcRec, Color.White);
            spriteBatch.End();
        }
    }
}
