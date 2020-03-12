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

        public bool IsDone { get; set; }
        public int Size { get; set; }
        public int Speed { get; set; }
        public int ShotDistance { get; set; }
        public void SetPosition(int x, int y)
        {
            this.position.X = x;
            this.position.Y = y;
        }

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
                    EnemyCollision(collidable);
                }
                else if (collidable is IItem)
                {
                    ItemCollision(collidable);
                }
                else if (collidable is Block)
				{
                    BlockCollision(collidable);
				}
            }
        }


        public abstract void Explode();
        public abstract void Shoot();
        public void EnemyCollision(ICollidable collidable)
        {
            if (!exploding)
            {
                Explode();
            }
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
            Rectangle intersection = Rectangle.Intersect(hitBox, collidable.GetHitBox());
            if (intersection.Height > intersection.Width && hitBox.X < collidable.GetHitBox().Left)
            {
                SetPosition(collidable.GetHitBox().Left - hitBox.Width, hitBox.Y);
                Explode();
            }
            else if (intersection.Width > intersection.Height && hitBox.Y < collidable.GetHitBox().Top)
            {
                SetPosition(hitBox.X, collidable.GetHitBox().Top - hitBox.Height);
                Explode();
            }
            else if (intersection.Width > intersection.Height && hitBox.Y > collidable.GetHitBox().Top)
            {
                SetPosition(hitBox.X, collidable.GetHitBox().Bottom);
                Explode();
            }
            else if (intersection.Height > intersection.Width && hitBox.X > collidable.GetHitBox().Left)
            {
                SetPosition(collidable.GetHitBox().Right, hitBox.Y);
                Explode();
            }
        }

        public virtual void BorderCollision()
        {
            if (!exploding && shooting)
            {
                Explode();
            }
        }

        public void PlayerCollision(ICollidable collidable)
        {
            
        }

        public abstract void Update();

        public abstract void Draw(SpriteBatch spriteBatch);
    }
}