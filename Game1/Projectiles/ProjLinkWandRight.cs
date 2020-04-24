using Game1.Sound;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class ProjLinkWandRight : AbstractProjectile, IProjectile
    {

        public ProjLinkWandRight(IPlayer player)
        {
            this.Damage = 2;
            shooting = false;
            exploding = false;
            this.player = player;
            this.Size = player.Size;
            this.position = new Vector2(0);
            this.Speed = 5; /*Changeable */
            sprite = SpriteFactory.Instance.GetWandWaveRight(this);
            hitBox = new Rectangle((int)position.X, (int)position.Y, Size * 15, Size * 15);
            IsDone = false;
        }
        
        public override void Shoot()
        { 
            if (!shooting)
            {
                ZeldaSound.Instance.SwordBeam();
                sprite = SpriteFactory.Instance.GetWandWaveRight(this);
                this.ShotDistance = 0;
                this.position = player.GetPosition();
            }
            shooting = true;
        }

        public override void Explode()
        {
            shooting = false;
        }

        public override void Update()
        {
            this.hitBox.Location = this.position.ToPoint();
            if (shooting && ShotDistance >= 300)
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

    }
}
