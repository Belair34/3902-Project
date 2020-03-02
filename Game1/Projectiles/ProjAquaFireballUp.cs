using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class ProjAquaFireballUp : IProjectile
    {
        bool shooting;
        bool exploding;
        ISprite sprite;
        IEnemy enemy;
        Vector2 position;
        int explodeTimer;

        public ProjAquaFireballUp(IEnemy enemy)
        {
            this.enemy = enemy;
            shooting = false;
            exploding = false;
            this.Size = enemy.Size;
            this.position = new Vector2(0);
            this.Speed = 6; /*Changeable */
            sprite = SpriteFactory.Instance.GetAquaFireballUp(this);
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
                sprite = SpriteFactory.Instance.GetAquaFireballUp(this);
                this.ShotDistance = 0;
                this.position = enemy.GetPosition();
            }
            shooting = true;
        }

        public void Explode()
        {
            explodeTimer = 5;
            shooting = false;
            exploding = true;
            sprite = SpriteFactory.Instance.GetAquaFireballExplode(this);
        }

        public void Update()
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

        public void Draw(SpriteBatch spriteBatch)
        {
            if (shooting || exploding)
            {
                sprite.Draw(spriteBatch);
            }
        }

    }
}
