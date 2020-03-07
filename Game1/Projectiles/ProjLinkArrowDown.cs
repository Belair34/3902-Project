using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class ProjLinkArrowDown : AbstractProjectile, IProjectile
    {

        public ProjLinkArrowDown(IPlayer player)
        {
            shooting = false;
            exploding = false;
            this.player = player;
            this.Size = player.Size;
            this.position = new Vector2(100,100);
            this.Speed = 10; /*Changeable */
            sprite = SpriteFactory.Instance.GetLinkArrowDown(this);
            hitBox = new Rectangle((int)position.X, (int)position.Y, Size * 15, Size * 15);
            IsDone = false;
        }
      
        public override void Shoot()
        { 
            if (!shooting)
            {
                sprite = SpriteFactory.Instance.GetLinkArrowDown(this);
                this.ShotDistance = 0;
                this.position = player.GetPosition();
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
