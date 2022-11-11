using Game1.Sound;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1.Projectiles
{
    class ProjLinkArrowRight : AbstractProjectile, IProjectile
    {


        public ProjLinkArrowRight(IPlayer player)
        {
            this.damage = 2;
            base.shooting = false;
            base.exploding = false;
            base.player = player;
            base.Size = player.Size;
            this.position = player.GetPosition();
            base.Speed = 10; /*Changeable */
            base.sprite = SpriteFactory.Instance.GetLinkArrowRight(this);
            hitBox = new Rectangle((int)position.X, (int)position.Y, Size * 15, Size * 7);
        }
        
        public override void Shoot()
        { 
            if (!shooting)
            {
                ZeldaSound.Instance.ShootArrow();
                base.sprite = SpriteFactory.Instance.GetLinkArrowRight(this);
                base.ShotDistance = 0;
                base.position = player.GetPosition();
                base.position.X += 8;
                base.position.Y += 15;
            }
            base.shooting = true;
        }

        public override void Explode()
        {
            base.explodeTimer = 5;
            this.hitBox.Height = 0;
            this.hitBox.Width = 0;
            this.position.X += 8;
            this.position.Y -= 8;
            base.shooting = false;
            base.exploding = true;
            base.sprite = SpriteFactory.Instance.GetLinkArrowExplode(this);
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
            if (exploding && explodeTimer <= 0)
            {
                exploding = false;
                this.IsDone = true;
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
