using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System;

namespace Game1.ProjectileSprites
{
    class SwordExplodeTopLeft : ISprite
    {
        private Texture2D texture;
        private IProjectile projectile;
        private int srcWidth = 8;
        private int srcHeight = 10;
        private int destWidth = 8;
        private int destHeight = 10;
        private int srcX = 119;
        private int srcY = 282;
        private int curFrame = 1;
        private int totalFrames = 4; /*Maybe this*/
        private int delay = 0;
        private int speed;
        private Vector2 position;


        public SwordExplodeTopLeft(IProjectile projectile, Texture2D texture)
        {
            this.texture = texture;
            this.projectile = projectile;
            this.destWidth *= projectile.Size;
            this.destHeight *= projectile.Size;
            this.speed = 5;
            this.position = projectile.GetPosition();
        }
        public void Update()
        {
            delay++;
            if (delay == 2) /*Delay of frame changes*/
            {
                delay = 0;
                srcX += 30;
                curFrame++;
                if (curFrame > totalFrames)
                {
                    srcX = 119;
                    curFrame = 1;
                }
            }


            int projX = (int)position.X;
            int projY = (int)position.Y;
            projX -= speed;
            projY -= speed;
            position.X = projX;
            position.Y = projY;
            
        }

        public void Draw(SpriteBatch spriteBatch)
        { 
            Rectangle arrowSrcRec = new Rectangle(srcX, srcY, srcWidth, srcHeight);
            Rectangle arrowDestRec = new Rectangle((int)position.X, (int)position.Y, destWidth, destHeight);
            spriteBatch.Begin();
            spriteBatch.Draw(texture, arrowDestRec, arrowSrcRec, Color.White);
            spriteBatch.End();
        }
    }
}
