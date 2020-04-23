using Game1.PlayerStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1.PlayerSprites
{
    class LinkDead : ISprite
    {
        Texture2D texture;
        Texture2D gameOver;
        IPlayer player;
        int srcWidth = 15;
        int srcHeight = 16;
        int destWidth = 15;
        int destHeight = 16;
        int srcX = 0; /*Change this*/
        int srcY = 0;  /*and this*/
        int curFrame = 1;
        int totalFrame = 2;
        int tick = 0;
        int delay = 150;
        int hudOffset;
        SpriteEffects s = SpriteEffects.FlipVertically;
        public LinkDead(IPlayer player, Texture2D texture)
        {
            this.texture = texture;
            gameOver = SpriteFactory.Instance.GetGameOver();
            hudOffset = 200;
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
                if(curFrame == 1)
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
            spriteBatch.Draw(texture, destRec, srcRec, Color.White, 0.0f, new Vector2(0, 0), s, 0.0f);
            if (delay <= 0)
            {
                spriteBatch.Draw(gameOver, new Vector2(0, hudOffset), Color.White);
            }
            delay--;
            spriteBatch.End();
        }
    }
}

