using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1.EnemySprites
{
    class GoriyaMovingLeft : ISprite
    {
        private Vector2 position; /* for draw method that support flip sprite */
        private Texture2D texture;
        private IEnemy enemy;
        private int srcWidth = 16;
        private int srcHeight = 16;
        private int destWidth = 16;
        private int destHeight = 16;
        private int srcX = 256; /*Change this*/
        private int srcY = 11;  /*and this*/
        private int curFrame = 1;
        private int totalFrames = 2; /*Maybe this*/
        private int delay = 0;
        private int moveSpeed;
        SpriteEffects s = SpriteEffects.FlipHorizontally;


        public GoriyaMovingLeft(IEnemy enemy, Texture2D texture)
        {
            this.texture = texture;
            this.enemy = enemy;
            moveSpeed = enemy.Speed;
            destWidth *= enemy.Size;
            destHeight *= enemy.Size;
            s = SpriteEffects.FlipHorizontally;
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
            enemy.SetPosition((int)enemy.GetPosition().X - moveSpeed, (int)enemy.GetPosition().Y); /*Change this*/
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destRec = new Rectangle((int)enemy.GetPosition().X, (int)enemy.GetPosition().Y, destWidth, destHeight);
            Rectangle srcRec;
            position.X = (int)enemy.GetPosition().X;
            position.Y = (int)enemy.GetPosition().Y;
            srcRec = new Rectangle(srcX, srcY, srcWidth, srcHeight);
            spriteBatch.Begin();
            spriteBatch.Draw(texture, position, destRec, Color.White, 0.0f, new Vector2(0, 0), 1.0f, this.s, 0.0f);

            spriteBatch.End();
        }
    }
}
