﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1.PlayerSprites
{
    class LinkMovingUp :ISprite
    {
        private Texture2D texture;
        private IPlayer player;
        private int backgroundHeight = 176;
        private float backgroundVerticalRatio;
        private int srcWidth = 15;
        private int srcHeight = 16;
        private int destWidth = 15;
        private int destHeight = 16;
        private int srcX = 60; /*Change this*/
        private int srcY = 30;  /*and this*/
        private int spriteX;
        private int spriteY;
        private int curFrame = 1;
        private int totalFrames = 2; /*Maybe this*/
        private int delay = 0;
        private int moveSpeed;

        public LinkMovingUp(IPlayer player, Texture2D texture)
        {
            this.texture = texture;
            this.player = player;
            this.moveSpeed = player.Speed;
            this.destWidth *= player.Size;
            this.destHeight *= player.Size;
            this.backgroundVerticalRatio = (int)player.GetBoundary().Y / backgroundHeight;
        }
        public void calcPosition()
        {
            spriteX = (int)player.GetPosition().X;
            spriteY = (int)player.GetPosition().Y - moveSpeed;
            if(spriteY < 33 * backgroundVerticalRatio)
            {
                spriteY = (int)(33 * backgroundVerticalRatio);
            }
        }
        public void Update()
        {
            delay++;
            if(delay == 7) /*Delay of frame changes*/
            {
                delay = 0;
                curFrame++;
                if(curFrame > totalFrames)
                {
                    curFrame = 1;
                }
            }
            calcPosition();
            player.SetPosition(spriteX, spriteY); /*Change this*/
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destRec = new Rectangle((int)player.GetPosition().X, (int)player.GetPosition().Y, destWidth, destHeight);
            Rectangle srcRec;
            if (curFrame == 1) /*Change these to correct frames, might need to add/delete else if*/
            {
                srcX = 60;
                srcY = 30;
            }
            else if(curFrame == 2)
            {
                srcX = 60;
                srcY = 0;
            }
            srcRec = new Rectangle(srcX, srcY, srcWidth, srcHeight);
            spriteBatch.Begin();
            spriteBatch.Draw(texture, destRec, srcRec, Color.White);
            spriteBatch.End();
        }
    }
}