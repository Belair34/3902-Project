using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using Game1.Projectiles;
using System.Collections.Generic;

namespace Game1
{
    public abstract class AbstractItem : IItem
    {
        internal Vector2 position;
        internal Vector2 boundary;
        internal ISprite sprite;


        public int Size { get; set; }

        public void SetPosition(int x, int y)
        {
            this.position.X = x;
            this.position.Y = y;
        }

        /*Not sure how this works with abstract class, we need the item's hitbox rectangle*/
        public Rectangle GetHitBox()
        {
            return new Rectangle(); //delete and replace with actual call once all sprites have been refactored
            //return sprite.GetDestRect();
        }

        public Vector2 GetPosition()
        {
            return this.position;
        }
        public Vector2 GetBoundary()
        {
            return boundary;
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

        }

        public void EnemyCollision(ICollidable collidable)
        {
            //default implentation: do nothing
        }

        public void ProjectileCollision(ICollidable collidable)
        {
            //default implentation: do nothing
        }

        public void ItemCollision(ICollidable collidable)
        {
            //default implentation: do nothing
        }

        public void BlockCollision(ICollidable collidable)
        {
            //default implentation: do nothing
        }

        public void BorderCollision()
        {
            //default implentation: do nothing
        }

        public abstract void PlayerCollision(ICollidable collidable);
    }
}