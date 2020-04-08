using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using Game1.Projectiles;
using System.Collections.Generic;
using System;

namespace Game1
{
	public class Stalfos : IEnemy
	{
		private Vector2 position;
		private IEnemyState state;
		private Rectangle hitBox;
		List<IProjectile> projectiles;
		int maxHealth;
		int health;
		Random numberGenerator;
		double movementTimer;
		int maxTimer;
		int minTimer;

		public Stalfos(int x, int y, int health, int maxHealth)
		{
			this.Speed = 2;                /*Changeable*/
			this.Size = 3;                 /************/
			this.position = new Vector2();
			this.position.X = x;
			this.position.Y = y;
			this.state = new EStateStalfosMovingLeft(this);
			projectiles = new List<IProjectile>();           /*Projectiles*/
			hitBox = new Rectangle(x, y, 16 * Size, 16 * Size);
			numberGenerator = new Random();
			maxTimer = 100;
			minTimer = 20;
			movementTimer = numberGenerator.NextDouble()*maxTimer+minTimer;
		}

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
			movementTimer--;
			if(movementTimer < 0)
			{
				BorderCollision();
				movementTimer = numberGenerator.NextDouble() * maxTimer; 
			}
			foreach (IProjectile projectile in projectiles)
			{
				projectile.Update();
			}
			state.Update();
			this.hitBox.Location = this.position.ToPoint();
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
			}
		}

		public void PlayerCollision(ICollidable collidable)
		{
			BlockCollision(collidable);
		}

		public void EnemyCollision(ICollidable collidable)
		{
			BlockCollision(collidable);
		}

		public void ProjectileCollision(ICollidable collidable)
		{
			BlockCollision(collidable);
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
			int randomNumber = numberGenerator.Next();
			if(randomNumber % 4 == 0)
			{
				MoveUp();
			}
			else if(randomNumber % 4 == 1)
			{
				MoveDown();
			}
			else if(randomNumber % 4 == 2)
			{
				MoveLeft();
			}
			else if(randomNumber % 4 == 3)
			{
				MoveRight();
			}
		}


		public Rectangle GetHitBox()
		{
			return this.hitBox;
		}
	}
}