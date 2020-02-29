using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Game1
{
    class ProjLinkBombUp : IProjectile
    {
        bool shooting;
        bool exploding;
        ISprite sprite;
        IPlayer player;
        Vector2 position;
        int explodeTimer;

        public ProjLinkBombUp(IPlayer player)
        {
            shooting = false;
            exploding = false;
            this.player = player;
            this.Size = player.Size;
            this.position = new Vector2(0);
            this.Speed = 0; /*Changeable */
            sprite = SpriteFactory.Instance.GetLinkBomb(this);
        }
        public int Size { get; set; }
        public int Speed { get; set; }
        public int ShotDistance { get; set; }
        public void SetPosition(int x, int y)
        {
            this.position.X = x;
            this.position.Y = y;
        }
        public Vector2 GetPosition()
        {
            return this.position;
        }
        public void Shoot()
        { 
            if (!shooting)
            { 
                this.ShotDistance = 0;
                this.position = player.GetPosition();
                this.position.Y -= 15 * Size;
            }
            shooting = true;
        }

        public void Explode()
        {
            explodeTimer = 30;
            shooting = false;
            exploding = true;
            this.sprite = SpriteFactory.Instance.GetLinkBombExplode(this);
        }

        public void Update()
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

        public void Draw(SpriteBatch spriteBatch)
        {
            if (shooting || exploding)
            {
                sprite.Draw(spriteBatch);
            }
        }

    }
}
