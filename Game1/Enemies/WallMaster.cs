﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using Game1.Projectiles;
using System.Collections.Generic;

namespace Game1
{
	public class WallMaster : IEnemy
	{
		private Vector2 position;
		private IEnemyState state;
		List<IProjectile> projectiles;
		int maxHealth;
		int health;
		private Rectangle hitBox;

		public WallMaster(int x, int y)
		{
			this.health = 6;
			this.maxHealth = 6;
			this.Speed = 1;                /*Changeable*/
			this.Size = 3;                 /************/
			this.position = new Vector2(); 
			this.position.X = x;
			this.position.Y = y;
			this.state = new EStateWallMasterIdleAnimated(this);
			projectiles = new List<IProjectile>();           /*Projectiles*/
			hitBox = new Rectangle(x, y, 16 * Size, 16 * Size);
			hitBox = new Rectangle(x, y, 16 * Size, 16 * Size);
			this.IsDone = false;
		}

		public bool IsDone { get; set; }
		public int Speed { get; set; }
		public int Size { get; set; }

		public List<IProjectile> GetProjectiles()
		{
			return this.projectiles;
		}
		public void SetPosition(int x, int y)
		{
			this.position.X = x;
			this.position.Y = y;
		}

		public Vector2 GetPosition()
		{
			return this.position;
		}

		public void SetState(IEnemyState state)
		{
			this.state = state;
		}

		public IEnemyState GetState()
		{
			return this.state;
		}

		public void TakeDamage(int damage)
		{
			health -= damage;
			if (health <= 0)
			{
				Die();
			}
		}
		public void Die()
		{
			//any death details here
			IsDone = true;
		}
		public void MoveUp()
		{
			state.MoveUp();
		}

		public void MoveDown()
		{
			state.MoveDown();
		}

		public void MoveLeft()
		{
			state.MoveLeft();
		}

		public void MoveRight()
		{
			state.MoveRight();
		}
		public void MoveHorizontal()
		{
			state.MoveHorizontal();
		}

		public void MoveVertical()
		{
			state.MoveVertical();
		}
		public void MoveToPlayer()
		{
			state.MoveToPlayer();
		}

		public void Stop()
		{
			state.Stop();
		}

		public void Update()
		{
			foreach (IProjectile projectile in projectiles)
			{
				projectile.Update();
			}
			state.Update();
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			foreach (IProjectile projectile in projectiles)
			{
				projectile.Draw(spriteBatch);
			}
			state.Draw(spriteBatch);
		}

		public void CheckCollisions(ICollidable collidable)
		{
			if (collidable.GetHitBox().Intersects(hitBox))
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
				else if (collidable is Block)
				{
					BlockCollision(collidable);
				}
				else if (collidable is Water)
				{
					WaterCollision(collidable);
				}
			}
		}

		public void PlayerCollision(ICollidable collidable)
		{
			
		}

		public void EnemyCollision(ICollidable collidable)
		{
			
		}

		public void ProjectileCollision(ICollidable collidable)
		{
			TakeDamage(((IProjectile)collidable).GetDamage());
		}

		public void ItemCollision(ICollidable collidable)
		{
			
		}

		public void BlockCollision(ICollidable collidable)
		{
			Rectangle intersection = Rectangle.Intersect(hitBox, collidable.GetHitBox());
			if (intersection.Height > intersection.Width && hitBox.X < collidable.GetHitBox().Left)
			{
				SetPosition(collidable.GetHitBox().Left - hitBox.Width, hitBox.Y);
			}
			else if (intersection.Width > intersection.Height && hitBox.Y < collidable.GetHitBox().Top)
			{
				SetPosition(hitBox.X, collidable.GetHitBox().Top - hitBox.Height);
			}
			else if (intersection.Width > intersection.Height && hitBox.Y > collidable.GetHitBox().Top)
			{
				SetPosition(hitBox.X, collidable.GetHitBox().Bottom);
			}
			else if (intersection.Height > intersection.Width && hitBox.X > collidable.GetHitBox().Left)
			{
				SetPosition(collidable.GetHitBox().Right, hitBox.Y);
			}
		}

		public void WaterCollision(ICollidable collidable)
		{
			Rectangle intersection = Rectangle.Intersect(hitBox, collidable.GetHitBox());
			if (intersection.Height > intersection.Width && hitBox.X < collidable.GetHitBox().Left)
			{
				SetPosition(collidable.GetHitBox().Left - hitBox.Width, hitBox.Y);
				BorderCollision();
			}
			else if (intersection.Width > intersection.Height && hitBox.Y < collidable.GetHitBox().Top)
			{
				SetPosition(hitBox.X, collidable.GetHitBox().Top - hitBox.Height);
				BorderCollision();
			}
			else if (intersection.Width > intersection.Height && hitBox.Y > collidable.GetHitBox().Top)
			{
				SetPosition(hitBox.X, collidable.GetHitBox().Bottom);
				BorderCollision();
			}
			else if (intersection.Height > intersection.Width && hitBox.X > collidable.GetHitBox().Left)
			{
				SetPosition(collidable.GetHitBox().Right, hitBox.Y);
				BorderCollision();
			}
		}

		public void BorderCollision()
		{
			
		}

		public Rectangle GetHitBox()
		{
			return this.hitBox;
		}
	}
}