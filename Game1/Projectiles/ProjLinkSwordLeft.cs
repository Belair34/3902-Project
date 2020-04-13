using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class ProjLinkSwordLeft : AbstractProjectile, IProjectile
    {

        public ProjLinkSwordLeft(IPlayer player)
        {
            this.damage = 2;
            shooting = false;
            this.player = player;
            this.Size = player.Size;
            this.position = new Vector2(0);
            this.Speed = 10; /*Changeable */
            sprite = SpriteFactory.Instance.GetLinkSwordBeamLeft(this);
            hitBox = new Rectangle((int)position.X, (int)position.Y, Size * 16, Size * 12);
            IsDone = false;
        }
        
        public override void Shoot()
        { 
            if (!shooting)
            {
                this.ShotDistance = 0;
                this.position = player.GetPosition();
            }
            shooting = true;
        }

        public override void Explode()
        {
            position.Y += 12;
            explodeTimer = 15;
            this.hitBox.Height = 0;
            this.hitBox.Width = 0;
            exploding = true;
            shooting = false;
            sprite = SpriteFactory.Instance.GetLinkSwordExplode(this);
        }

        public override void Update()
        {
            this.hitBox.Location = this.position.ToPoint();
            if (shooting && ShotDistance >= 2000)
            {
                Explode();
            }
            else if (exploding)
            {
                explodeTimer--;
                if (explodeTimer <= 0)
                {
                    exploding = false;
                    IsDone = true;
                }
            }

            if ((shooting || exploding) && !IsDone)
            {
                sprite.Update();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if ((shooting || exploding) && !IsDone)
            {
                sprite.Draw(spriteBatch);
            }
        }

    }
}