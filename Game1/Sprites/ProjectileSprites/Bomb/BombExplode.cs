using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System;

namespace Game1.ProjectileSprites
{
    class BombExplode : ISprite
    {
        private Texture2D texture;
        private IProjectile projectile;
        private int srcWidth = 16;
        private int srcHeight = 16;
        private int destWidth = 16;
        private int destHeight = 16;
        private int srcX = 138;
        private int srcY = 185;
        private int curFrame = 1;
        private int delay = 0;

        public BombExplode(IProjectile projectile, Texture2D texture)
        {
            this.texture = texture;
            this.projectile = projectile;
            this.destWidth *= projectile.Size;
            this.destHeight *= projectile.Size;
        }
        public void Update()
        {
            delay++;
            if (delay == 3) /*Delay of frame changes*/
            {
                delay = 0;
                curFrame++;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (curFrame == 1)
            {
                srcX = 138;
                srcY = 185;
            }
            else if(curFrame == 7)
            {
                srcX = 155;
            }
            else if(curFrame == 10)
            {
                srcX = 170;
            }
            Rectangle srcRec = new Rectangle(srcX, srcY, srcWidth, srcHeight);
            Rectangle middle = new Rectangle((int)projectile.GetPosition().X, (int)projectile.GetPosition().Y, destWidth, destHeight);
            Rectangle left = new Rectangle((int)projectile.GetPosition().X-destWidth, (int)projectile.GetPosition().Y, destWidth, destHeight);
            Rectangle right = new Rectangle((int)projectile.GetPosition().X+destWidth, (int)projectile.GetPosition().Y, destWidth, destHeight);
            Rectangle topLeft = new Rectangle((int)projectile.GetPosition().X - destWidth / 2, (int)projectile.GetPosition().Y-destHeight, destWidth, destHeight);
            Rectangle topRight = new Rectangle((int)projectile.GetPosition().X + destWidth / 2, (int)projectile.GetPosition().Y-destHeight, destWidth, destHeight);
            Rectangle botLeft = new Rectangle((int)projectile.GetPosition().X - destWidth / 2, (int)projectile.GetPosition().Y + destHeight, destWidth, destHeight);
            Rectangle botRight = new Rectangle((int)projectile.GetPosition().X + destWidth / 2, (int)projectile.GetPosition().Y + destHeight, destWidth, destHeight);

            spriteBatch.Begin();
            spriteBatch.Draw(texture, middle, srcRec, Color.White);
            spriteBatch.Draw(texture, left, srcRec, Color.White);
            spriteBatch.Draw(texture, right, srcRec, Color.White);
            spriteBatch.Draw(texture, topLeft, srcRec, Color.White);
            spriteBatch.Draw(texture, topRight, srcRec, Color.White);
            spriteBatch.Draw(texture, botLeft, srcRec, Color.White);
            spriteBatch.Draw(texture, botRight, srcRec, Color.White);

            spriteBatch.End();
        }
    }
}
