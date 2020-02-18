using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class ProjLinkBoomerangUp : IProjectile
    {
        bool shooting;
        bool exploding;
        ISprite sprite;
        IPlayer player;
        Vector2 position;
        int tolerance;

        public ProjLinkBoomerangUp(IPlayer player)
        {
            shooting = false;
            exploding = false;
            this.player = player;
            this.Size = player.Size;
            this.position = new Vector2(0);
            this.Speed = 7; /*Changeable */
            this.tolerance = 5;
            sprite = SpriteFactory.Instance.GetBoomerangDown(this);
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
                sprite = SpriteFactory.Instance.GetBoomerangUp(this);
                this.ShotDistance = 0;
                this.position = player.GetPosition();
            }
            shooting = true;
        }

        public void Explode()
        {
            shooting = false;
            exploding = true;
        }

        public void Update()
        {
            if (shooting && ShotDistance >= 300)
            {

                Explode();
            }
            else if (exploding && (position.X >= player.GetPosition().X + tolerance || position.X <= player.GetPosition().X - tolerance || position.Y >= player.GetPosition().Y + tolerance || position.Y <= player.GetPosition().Y - tolerance))
            {
                Vector2 movementVector = new Vector2(player.GetPosition().X - position.X, player.GetPosition().Y - position.Y);
                movementVector.Normalize();
                position.X += movementVector.X * Speed;
                position.Y += movementVector.Y * Speed;
            }
            else if (position.X >= player.GetPosition().X - tolerance && position.X <= player.GetPosition().X + tolerance && position.Y >= player.GetPosition().Y - tolerance && position.Y <= player.GetPosition().Y + tolerance)
            {
                exploding = false;
            }

            if (shooting)
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