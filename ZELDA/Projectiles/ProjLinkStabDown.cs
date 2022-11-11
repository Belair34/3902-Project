using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class ProjLinkStabDown : AbstractProjectile, IProjectile
    {

        public ProjLinkStabDown(IPlayer player)
        {
            this.damage = 2;
            exploding = false;
            shooting = false;
            this.player = player;
            this.Size = player.Size;
            this.position = player.GetPosition();
            this.Speed = 0; /*Changeable */
            sprite = null;
            hitBox = new Rectangle((int)position.X, (int)position.Y, Size * 0, Size * 0);
            IsDone = false;
        }
        
        public override void Shoot()
        {
            Explode();
        }

        public override void Explode()
        {
            this.position = player.GetPosition();
            this.position.X += 13;
            this.position.Y += 30;
            explodeTimer = 8;
            this.hitBox.Height = 16*Size;
            this.hitBox.Width = 7*Size;
            exploding = true;
            shooting = false;
        }

        public override void BorderCollision()
        {
            
        }

        public override void BlockCollision(ICollidable collidable)
        {

        }
        public override void Update()
        {
            this.hitBox.Location = this.position.ToPoint();
            if (exploding)
            {
                explodeTimer--;
                if(explodeTimer <= 0)
                {
                    this.hitBox.Height = 0;
                    this.hitBox.Width = 0;
                    exploding = false;
                    IsDone = true;
                }
            }
          
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
          /*  Rectangle srcRec = new Rectangle(0, 0, 10, 10);

            spriteBatch.Begin();
            spriteBatch.Draw(SpriteFactory.Instance.GetBackgroundTexture(), hitBox, srcRec, Color.White);
            spriteBatch.End();*/
        }

    }
}
