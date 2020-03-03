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
    class GoriyaMovingUp : ISprite
    {
        private Texture2D texture;
        private IEnemy enemy;
        private int srcWidth = 16;
        private int srcHeight = 16;
        private int destWidth = 16;
        private int destHeight = 16;
        private int srcX = 239; /*Change this*/
        private int srcY = 11;  /*and this*/
        private int curFrame = 1;
        private int totalFrames = 2; /*Maybe this*/
        private int delay = 0;
        private int moveSpeed;

        public GoriyaMovingUp(IEnemy enemy, Texture2D texture)
        {
            this.texture = texture;
            this.enemy = enemy;
            this.destWidth *= enemy.Size;
            this.destHeight *= enemy.Size;
            this.moveSpeed = enemy.Speed;
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
            enemy.SetPosition((int)enemy.GetPosition().X, (int)enemy.GetPosition().Y - moveSpeed); /*Change this*/
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destRec = new Rectangle((int)enemy.GetPosition().X, (int)enemy.GetPosition().Y, destWidth, destHeight);
            Rectangle srcRec;
            srcRec = new Rectangle(srcX, srcY, srcWidth, srcHeight);
            spriteBatch.Begin();
            spriteBatch.Draw(texture, destRec, srcRec, Color.White);
            spriteBatch.End();
        }

        public ICollidable GetCollision()
        {
            throw new System.NotImplementedException();
        }

        public void CheckCollisions(ICollidable collidable, Border border)
        {
            throw new System.NotImplementedException();
        }

        public void PlayerCollision(ICollidable collidable)
        {
            throw new System.NotImplementedException();
        }

        public void EnemyCollision(ICollidable collidable)
        {
            throw new System.NotImplementedException();
        }

        public void ProjectileCollision(ICollidable collidable)
        {
            throw new System.NotImplementedException();
        }

        public void BlockCollision(ICollidable collidable)
        {
            throw new System.NotImplementedException();
        }

        public void BorderCollision()
        {
            throw new System.NotImplementedException();
        }

        public Rectangle GetHitBox()
        {
            throw new System.NotImplementedException();
        }
    }
}
