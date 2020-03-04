using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Game1
{
    class ProjLinkBombDown : AbstractProjectile, IProjectile
    {

        public ProjLinkBombDown(IPlayer player)
        {
            shooting = false;
            exploding = false;
            this.player = player;
            this.Size = player.Size;
            this.position = new Vector2(0);
            this.Speed = 0; /*Changeable */
            sprite = SpriteFactory.Instance.GetLinkBomb(this);
        }
       
        public override void Shoot()
        { 
            if (!shooting)
            { 
                this.ShotDistance = 0;
                this.position = player.GetPosition();
                this.position.Y += 15 * Size;
            }
            shooting = true;
        }

        public override void Explode()
        {
            explodeTimer = 30;
            shooting = false;
            exploding = true;
            this.sprite = SpriteFactory.Instance.GetLinkBombExplode(this);
        }

        public override void Update()
        {
            if(exploding && explodeTimer > 0)
            {
                explodeTimer--;
            }
            else if(explodeTimer <= 0)
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
