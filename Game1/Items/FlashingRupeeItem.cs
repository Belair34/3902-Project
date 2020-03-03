using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using Game1.Projectiles;
using System.Collections.Generic;

namespace Game1
{
    public class FlashingRupeeItem : AbstractItem, IItem
    {

        public FlashingRupeeItem(int x, int y, GraphicsDevice window)
        {
            /*Changeable*/
            base.Size = 3;

            base.position = new Vector2();
            base.position.X = x;
            base.position.Y = y;
            base.sprite = SpriteFactoryItems.Instance.GetFlashingRupee(this);

            base.boundary = new Vector2();
            base.boundary.X = window.Viewport.Width;
            base.boundary.Y = window.Viewport.Height;          /*Items*/
        }

        public override void PlayerCollision(ICollidable collidable)
        {
            ((IPlayer)collidable).GetInventory().Rupees++;
        }

        public void CheckCollisions(ICollidable collidable, Border border)
        {
            throw new System.NotImplementedException();
        }

        public void PlayerCollision(ICollidable collidable)
        {
            throw new System.NotImplementedException();
        }

        public void EnemyCollision(ICollidable collidable)
        {
            throw new System.NotImplementedException();
        }

        public void ProjectileCollision(ICollidable collidable)
        {
            throw new System.NotImplementedException();
        }

        public void BlockCollision(ICollidable collidable)
        {
            throw new System.NotImplementedException();
        }

        public void BorderCollision()
        {
            throw new System.NotImplementedException();
        }

        public Rectangle GetHitBox()
        {
            throw new System.NotImplementedException();
        }
    }
}