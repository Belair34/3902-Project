using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System;

namespace Game1.ProjectileSprites
{
    class SwordBeamLeft : ISprite
    {
        private Texture2D texture;
        private IProjectile projectile;
        private int srcWidth = 16;
        private int srcHeight = 12;
        private int destWidth = 16;
        private int destHeight = 12;
        private int srcX = 30;
        private int srcY = 194;
        private int curFrame = 1;
        private int totalFrames = 4; /*Maybe this*/
        private int delay = 0;
        private int speed;


        public SwordBeamLeft(IProjectile projectile, Texture2D texture)
        {
            this.texture = texture;
            this.projectile = projectile;
            this.destWidth *= projectile.Size;
            this.destHeight *= projectile.Size;
            this.speed = projectile.Speed;
        }
        public void Update()
        {
            delay++;
            if (delay == 2) /*Delay of frame changes*/
            {
                delay = 0;
                srcY += 30;
                curFrame++;
                if (curFrame > totalFrames)
                {
                    srcY = 194;
                    curFrame = 1;
                }
            }


            int projX = (int)projectile.GetPosition().X;
            int projY = (int)projectile.GetPosition().Y;
            projX -= speed;
            projectile.SetPosition(projX, projY);
            projectile.ShotDistance += speed;
        }

        public void Draw(SpriteBatch spriteBatch)
        { 
            Rectangle arrowSrcRec = new Rectangle(srcX, srcY, srcWidth, srcHeight);
            Rectangle arrowDestRec = new Rectangle((int)projectile.GetPosition().X, (int)projectile.GetPosition().Y, destWidth, destHeight);
            spriteBatch.Begin();
            spriteBatch.Draw(texture, arrowDestRec, arrowSrcRec, Color.White);
            spriteBatch.End();
        }
    }
}
