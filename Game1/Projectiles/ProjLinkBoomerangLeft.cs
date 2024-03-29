﻿using Game1.Sound;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class ProjLinkBoomerangLeft : AbstractProjectile, IProjectile
    {
        int tolerance;

        public ProjLinkBoomerangLeft(IPlayer player)
        {
            this.damage = 1;
            shooting = false;
            exploding = false;
            this.player = player;
            this.Size = player.Size;
            this.position = player.GetPosition();
            this.Speed = 7; /*Changeable */
            this.tolerance = 5;
            sprite = SpriteFactory.Instance.GetBoomerangLeft(this);
            hitBox = new Rectangle((int)position.X, (int)position.Y, Size * 15, Size * 15);
            IsDone = false;
        }
        
        public override void Shoot()
        {
            if (!shooting && !player.IsRangActive)
            {
                player.IsRangActive = true;
                ZeldaSound.Instance.BoomerangThrow();
                sprite = SpriteFactory.Instance.GetBoomerangLeft(this);
                this.ShotDistance = 0;
                this.position = player.GetPosition();
                shooting = true;
            }
            else
            {
                IsDone = true;
            }
        }

        public override void Explode()
        {
            shooting = false;
            exploding = true;
        }

        public override void Update()
        {
            this.hitBox.Location = this.position.ToPoint();
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
            else if (exploding && position.X >= player.GetPosition().X - tolerance && position.X <= player.GetPosition().X + tolerance && position.Y >= player.GetPosition().Y - tolerance && position.Y <= player.GetPosition().Y + tolerance)
            {
                exploding = false;
                IsDone = true;
                player.IsRangActive = false;
            }

            if (shooting)
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
