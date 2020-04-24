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
        internal ISprite sprite;

        public AbstractItem(int x, int y)
        {
            this.IsDone = false;
        }
        public bool IsDone { get; set; }
        public int Size { get; set; }

        public void SetPosition(int x, int y)
        {
            this.position.X = x;
            this.position.Y = y;
        }

        /*Not sure how this works with abstract class, we need the item's hitbox rectangle*/
        public Rectangle GetHitBox()
        {
            return new Rectangle((int)position.X, (int)position.Y, Size*10, Size*12); //delete and replace with actual call once all sprites have been refactored
            //return sprite.GetDestRect();
        }

        public Vector2 GetPosition()
        {
            return this.position;
        }
        public void Consume()
        {
            this.IsDone = true;
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
            if (collidable.GetHitBox().Intersects(GetHitBox()))
            {
                if (collidable is IProjectile)
                {
                    ProjectileCollision(collidable);
                }
                else if (collidable is IEnemy)
                {
                    EnemyCollision(collidable);
                }
                else if (collidable is IItem)
                {
                    ItemCollision(collidable);
                }
                else if (collidable is IPlayer)
                {
                    PlayerCollision(collidable);
                }
                /*else if (collidable is Block)
				{

				}*/
            }
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

        public void WaterCollision(ICollidable collidable)
        {
            //do nothing, item won't spawn on water
        }
    }
}