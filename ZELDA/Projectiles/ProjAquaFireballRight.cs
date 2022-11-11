using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class ProjAquaFireballRight : AbstractProjectile, IProjectile
    {

        public ProjAquaFireballRight(IEnemy enemy)
        {
            this.enemy = enemy;
            shooting = false;
            exploding = false;
            this.Size = enemy.Size;
            this.position = new Vector2(0);
            this.Speed = 6; /*Changeable */
            sprite = SpriteFactory.Instance.GetAquaFireballRight(this);
        }
        
        public override void Shoot()
        { 
            if (!shooting)
            {
                sprite = SpriteFactory.Instance.GetAquaFireballRight(this);
                this.ShotDistance = 0;
                this.position = enemy.GetPosition();
            }
            shooting = true;
        }

        public override void Explode()
        {
            explodeTimer = 5;
            shooting = false;
            exploding = true;
            sprite = SpriteFactory.Instance.GetAquaFireballExplode(this);
        }

        public override void Update()
        {
            if(shooting && ShotDistance >= 300)
            {
                Explode();
            }
            else if(exploding && explodeTimer > 0)
            {
                explodeTimer--;
            }
            if(explodeTimer <= 0)
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
