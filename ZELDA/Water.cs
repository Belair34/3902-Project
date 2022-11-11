using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public class Water : ICollidable
    {
        private bool visible;
        private Vector2 position;
        private Rectangle hitBox;
        private Rectangle srcRec;
        private Rectangle destRec;
        private Texture2D texture;
        public Water(int x, int y, bool visible)
        {
            this.visible = visible;
            this.position = new Vector2(0);
            this.position.X = x;
            this.position.Y = y;
            srcRec = new Rectangle(643, 789, 15, 15);
            //srcRec = new Rectangle(611, 741, 15, 15);
            destRec = new Rectangle((int)position.X, (int)position.Y, 47, 43);
            hitBox = new Rectangle((int)position.X, (int)position.Y, 49, 43 / 2);
            texture = SpriteFactory.Instance.GetBackgroundTexture();
        }

        public Rectangle GetHitBox()
        {
            return hitBox;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (visible)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(texture, destRec, srcRec, Color.White);
                spriteBatch.End();
            }
        }

        public void CheckCollisions(ICollidable collidable)
        {
            //not applicable
        }

        public void PlayerCollision(ICollidable collidable)
        {
            //not applicable
        }

        public void EnemyCollision(ICollidable collidable)
        {
            //not applicable
        }

        public void ProjectileCollision(ICollidable collidable)
        {
            //not applicable
        }

        public void ItemCollision(ICollidable collidable)
        {
            //not applicable
        }

        public void BlockCollision(ICollidable collidable)
        {
            //not applicable
        }

        public void BorderCollision()
        {
            //not applicable
        }

        public void SetPosition(int x, int y)
        {
            //not applicable
        }

        public void WaterCollision(ICollidable collidable)
        {
            //not applocable
        }
    }
}
