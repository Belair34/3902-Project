using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1.EnemySprites
{
    class AquamentusMovingRight : ISprite
    {
        private Texture2D texture;
        private IEnemy enemy;
        private int srcWidth = 23;
        private int srcHeight = 32;
        private int destWidth = 23;
        private int destHeight = 32;
        private int srcX = 1; /*Change this*/
        private int srcY = 11;  /*and this*/
        private int curFrame = 1;
        private int totalFrames = 4; /*Maybe this*/
        private int delay = 0;
        private int moveSpeed;
        SpriteEffects s = SpriteEffects.FlipHorizontally;
        public AquamentusMovingRight(IEnemy enemy, Texture2D texture)
        {
            this.texture = texture;
            this.enemy = enemy;
            moveSpeed = enemy.Speed;
            destWidth *= enemy.Size;
            destHeight *= enemy.Size;

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
            enemy.SetPosition((int)enemy.GetPosition().X + moveSpeed, (int)enemy.GetPosition().Y);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destRec = new Rectangle((int)enemy.GetPosition().X, (int)enemy.GetPosition().Y, destWidth, destHeight);
            if (curFrame == 1)
            {
                srcX = 1;
                srcY = 11;
            }
            else if (curFrame == 2)
            {
                srcX = 26;
                srcY = 11;
            }
            else if (curFrame == 3)
            {
                srcX = 51;
                srcY = 11;
            }
            else if (curFrame == 4)
            {
                srcX = 76;
                srcY = 11;
            }
            Rectangle srcRec;
            srcRec = new Rectangle(srcX, srcY, srcWidth, srcHeight);
            spriteBatch.Begin();
            spriteBatch.Draw(texture, destRec, srcRec, Color.White, 0.0f, new Vector2(0, 0), s, 0.0f);
            spriteBatch.End();
        }
    }
}
