﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1.EnemySprites
{
    class AnimatedWallMaster : ISprite
    {
        Texture2D texture;
        IEnemy enemy;
        int srcWidth = 16;
        int srcHeight = 16;
        int destWidth = 13;
        int destHeight = 13;
        int srcX = 393; /*Change this*/
        int srcY = 11;  /*and this*/

        int curFrame = 1;
        int totalFrames = 2; 
        int delay = 0;

        public AnimatedWallMaster(IEnemy enemy, Texture2D texture)
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
                srcX = 393;
                srcY = 11;
            }
            else if (curFrame == 2)
            {
                srcX = 410;
                srcY = 11;
            }
            srcRec = new Rectangle(srcX, srcY, srcWidth, srcHeight);
            spriteBatch.Begin();
            spriteBatch.Draw(texture, destRec, srcRec, Color.White);
            spriteBatch.End();
        }
    }
}
