using Game1.Sound;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class ProjLinkArrowDown : AbstractProjectile, IProjectile
    {

        public ProjLinkArrowDown(IPlayer player)
        {
            this.Damage = 2;
            shooting = false;
            exploding = false;
            this.player = player;
            this.Size = player.Size;
            this.position = player.GetPosition();
            this.Speed = 10; /*Changeable */
            sprite = SpriteFactory.Instance.GetLinkArrowDown(this);
            hitBox = new Rectangle((int)position.X, (int)position.Y, Size * 7, Size * 15);
        }
      
        public override void Shoot()
        { 
            if (!shooting)
            {
                ZeldaSound.Instance.ShootArrow();
                sprite = SpriteFactory.Instance.GetLinkArrowDown(this);
                this.ShotDistance = 0;
                this.position = player.GetPosition();
                this.position.X += 12;
            }
            shooting = true;
        }

        public override void Explode()
        {
            explodeTimer = 5;
            this.position.Y += 25;
            this.hitBox.Height = 0;
            this.hitBox.Width = 0;
            this.position.X -= 10;
            shooting = false;
            exploding = true;
            this.sprite = SpriteFactory.Instance.GetLinkArrowExplode(this);
        }

        public override void Update()
        {
            hitBox.Location = position.ToPoint();
            if (shooting && ShotDistance >= 2000)
            {
                Explode();
            }
            else if(exploding && explodeTimer > 0)
            {
                explodeTimer--;
            }
            if(exploding && explodeTimer <= 0)
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
