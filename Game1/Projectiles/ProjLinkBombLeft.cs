using Game1.Sound;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Game1
{
    class ProjLinkBombLeft : AbstractProjectile, IProjectile
    {

        public ProjLinkBombLeft(IPlayer player)
        {
            this.damage = 0;
            shooting = false;
            exploding = false;
            this.player = player;
            this.Size = player.Size;
            this.position = player.GetPosition();
            this.Speed = 0; /*Changeable */
            sprite = SpriteFactory.Instance.GetLinkBomb(this);
            IsDone = false;
            hitBox = new Rectangle((int)position.X-75, (int)position.Y-45, 0, 0);
        }

        public override void Shoot()
        {
            if (!shooting)
            {
                ZeldaSound.Instance.DropBomb();
                this.ShotDistance = 0;
                this.position = player.GetPosition();
                this.position.X -= 15 * Size;
                shooting = true;
                explodeTimer = 30;
            }
        }

        public override void Explode()
        {
            if (shooting && explodeTimer <= 0)
            {
                this.damage = 5;
                ZeldaSound.Instance.BombExplode();
                explodeTimer = 30;
                shooting = false;
                exploding = true;
                this.sprite = SpriteFactory.Instance.GetLinkBombExplode(this);
                hitBox.Width = 120;
                hitBox.Height = 135;
            }
        }

        public override int GetDamage()
        {
            return damage;
        }

        public override void Update()
        {
            if(explodeTimer > 0)
            {
                explodeTimer--;
            }
            else if(exploding && explodeTimer <= 0)
            {
                exploding = false;
                IsDone = true;
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
        public override void BorderCollision()
        {

        }

        public override void BlockCollision(ICollidable collidable)
        {
            
        }

    }
}
