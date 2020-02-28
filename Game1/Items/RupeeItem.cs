using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using Game1.Projectiles;
using System.Collections.Generic;

namespace Game1
{
    public class RupeeItem : IItems
    {
        private Vector2 position;
        private Vector2 Boundary;
        ISprite sprite;

        public RupeeItem(int x, int y, GraphicsDevice window)
        {
            /*Changeable*/
            this.Size = 3;

            this.position = new Vector2();
            this.position.X = x;
            this.position.Y = y;
            this.sprite = SpriteFactoryItems.Instance.GetRupee(this);

            this.Boundary = new Vector2();
            this.Boundary.X = window.Viewport.Width;
            this.Boundary.Y = window.Viewport.Height;          /*Items*/
        }

        public int Size { get; set; }

        public void SetPosition(int x, int y)
        {
            this.position.X = x;
            this.position.Y = y;
        }

        public Vector2 GetPosition()
        {
            return this.position;
        }
        public Vector2 GetBoundary()
        {
            return Boundary;
        }
        public void Stop()
        {

        }
        public void Update()
        {
            sprite.Update();

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            sprite.Draw(spriteBatch);
        }

        public void CheckCollisions(ICollidable collidable)
        {
            throw new System.NotImplementedException();
        }

        public void PlayerCollision(ICollidable collidable)
        {
            ((IPlayer)collidable).GetInventory().Rupees += 5;
        }

        public void EnemyCollision(ICollidable collidable)
        {
            throw new System.NotImplementedException();
        }

        public void ProjectileCollision(ICollidable collidable)
        {
            throw new System.NotImplementedException();
        }

        public void ItemCollision(ICollidable collidable)
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
    }
}