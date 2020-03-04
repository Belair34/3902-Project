using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1.Projectiles
{
    class ProjLinkArrowUp : AbstractProjectile, IProjectile
    {
        public ProjLinkArrowUp(IPlayer player)
        {
            shooting = false;
            exploding = false;
            this.player = player;
            this.Size = player.Size;
            this.position = new Vector2(0);
            this.Speed = 10; /*Changeable */
            sprite = SpriteFactory.Instance.GetLinkArrowUp(this);
            hitBox = new Rectangle((int)position.X, (int)position.Y, Size * 15, Size * 15);
        }
     
        public override void Shoot()
        { 
            if (!shooting)
            {
                sprite = SpriteFactory.Instance.GetLinkArrowUp(this);
                this.ShotDistance = 0;
                this.position = player.GetPosition();
                this.position.Y -= 5;
            }
            shooting = true;
        }

        public override void Explode()
        {
            explodeTimer = 5;
            shooting = false;
            exploding = true;
            this.sprite = SpriteFactory.Instance.GetLinkArrowExplode(this);
        }

        public override void Update()
        {
            this.hitBox.Location = this.position.ToPoint();
            if (shooting && ShotDistance >= 2000)
            {
                Explode();
            }
            else if (exploding && explodeTimer > 0)
            {
                explodeTimer--;
            }
            if (explodeTimer <= 0)
            {
                exploding = false;
            }
            if (shooting || exploding)
            {
                sprite.Update();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (shooting || exploding)
            {
                sprite.Draw(spriteBatch);
            }
        }

    }
}
