using Game1.Sound;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class ProjLinkWandUp : AbstractProjectile, IProjectile
    {

        public ProjLinkWandUp(IPlayer player)
        {
            this.damage = 2;
            shooting = false;
            exploding = false;
            this.player = player;
            this.Size = player.Size;
            this.position = new Vector2(0);
            this.Speed = 5; /*Changeable */
            sprite = SpriteFactory.Instance.GetWandWaveUp(this);
            hitBox = new Rectangle((int)position.X, (int)position.Y-50, 0, 0);
            IsDone = false;
        }
       
        public override void Shoot()
        { 
            if (!shooting)
            {
                ZeldaSound.Instance.SwordBeam();
                sprite = SpriteFactory.Instance.GetWandWaveUp(this);
                this.ShotDistance = 0;
                this.position = player.GetPosition();
                this.hitBox.Width = Size*15;
                this.hitBox.Height = Size*15;
            }
            shooting = true;
        }

        public override void Explode()
        {
            shooting = false;
            IsDone = true;
            hitBox.Width = 0;
            hitBox.Height = 0;
        }

        public override void Update()
        {
            this.hitBox.Location = this.position.ToPoint();
            this.hitBox.Y -= 50;
            if (shooting && ShotDistance >= 300)
            {
                Explode();
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
