using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using Game1.Projectiles;
using System.Collections.Generic;

namespace Game1
{
    public abstract class AbstractProjectile : IProjectile
    {
        internal bool shooting;
        internal bool exploding;
        internal ISprite sprite;
        internal IEnemy enemy;
        internal Vector2 position;
        internal int explodeTimer;
        internal IPlayer player;
        internal Rectangle hitBox;

        public int Size { get; set; }
        public int Speed { get; set; }
        public int ShotDistance { get; set; }
        public void SetPosition(int x, int y)
        {
            this.position.X = x;
            this.position.Y = y;
        }

        /*Not sure how this works with abstract class, we need the item's hitbox rectangle*/
        public Rectangle GetHitBox()
        {
            return hitBox;
        }

        public Vector2 GetPosition()
        {
            return this.position;
        }
        public void Stop()
        {

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
                    System.Console.WriteLine("Here");
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


        public abstract void Explode();
        public abstract void Shoot();
        public void EnemyCollision(ICollidable collidable)
        {
            Explode();
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
            Explode();
        }

        public void BorderCollision()
        {
            Explode();
        }

        public void PlayerCollision(ICollidable collidable)
        {
            Explode();
        }

        public abstract void Update();

        public abstract void Draw(SpriteBatch spriteBatch);
    }
}