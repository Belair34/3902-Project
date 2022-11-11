using Game1.PlayerStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1.PlayerSprites
{
    class LinkDamagedRight :ISprite
    {
        Texture2D texture;
        IPlayer player;
        int srcWidth = 15;
        int srcHeight = 16;
        int destWidth = 15;
        int destHeight = 16;
        int srcX = 90; /*Change this*/
        int srcY = 30;  /*and this*/
        int curFrame = 1;
        int totalFrame = 2;
        int coolDown = 20;
        int tick = 0;

        public LinkDamagedRight(IPlayer player, Texture2D texture)
        {
            this.texture = texture;
            this.player = player;
            this.destWidth *= player.Size;
            this.destHeight *= player.Size;
        }
        public void Update()
        {
            tick++;
            if (tick == 7)
            {
                tick = 0;
                curFrame++;
                if (curFrame > totalFrame)
                {
                    curFrame = 1;
                }
                if (curFrame == 1)
                {
                    srcX -= 230;
                }
                else
                {
                    srcX += 230;
                }
            }
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
