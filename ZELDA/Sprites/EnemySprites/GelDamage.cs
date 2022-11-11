using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1.EnemySprites
{
    class GelDamage :ISprite
    {
        Texture2D texture;
        IEnemy enemy;
        int srcWidth = 8;
        int srcHeight = 16;
        int destWidth = 8;
        int destHeight = 16;
        int srcX = 55; /*Change this*/
        int srcY = 33;  /*and this*/
        int curFrame = 1;
        int totalFrames = 2; /*Maybe this*/
        int delay = 0;

        public GelDamage(IEnemy enemy, Texture2D texture)
        {
            this.texture = texture;
            this.enemy = enemy;
            this.destWidth *= enemy.Size;
            this.destHeight *= enemy.Size;
        }

        public void Update()
        {
            delay++;
            if (delay == 7) /*Delay of frame changes*/
            {
                delay = 0;
                curFrame++;
                if (curFrame > totalFrames)
                {
                    curFrame = 1;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destRec = new Rectangle((int)enemy.GetPosition().X, (int)enemy.GetPosition().Y, destWidth, destHeight);
            Rectangle srcRec;
            if (curFrame == 1) /*Change these to correct frames, might need to add/delete else if*/
            {
                srcX = 55;
                srcY = 33;
            }
            else if (curFrame == 2)
            {
                srcX = 10;
                srcY = 15;
            }
            srcRec = new Rectangle(srcX, srcY, srcWidth, srcHeight);
            spriteBatch.Begin();
            spriteBatch.Draw(texture, destRec, srcRec, Color.White);
            spriteBatch.End();
        }
    }
}
