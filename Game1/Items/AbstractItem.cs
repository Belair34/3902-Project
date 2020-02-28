using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using Game1.Projectiles;
using System.Collections.Generic;

namespace Game1
{
    public abstract class AbstractItem : IItems
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
            throw new System.NotImplementedException();
        }

        public void PlayerCollision(ICollidable collidable)
        {
            //default implentation: do nothing
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
    }
}