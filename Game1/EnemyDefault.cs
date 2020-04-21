using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using Game1.Projectiles;
using System.Collections.Generic;

namespace Game1
{
	public class EnemyDefault : IEnemy
	{
		private Vector2 position;
		private Vector2 Boundary;
		public Rectangle hitBox;
		private IEnemyState state;
		List<IProjectile> projectiles;
		int maxHealth;
		int health;
		Game1 game;
		public EnemyDefault(int x, int y, int health, int maxHealth, Game1 game)
		{
			this.Speed = 1;                /*Changeable*/
			this.Size = 3;                 /************/
			this.position = new Vector2(); 
			this.position.X = x;
			this.position.Y = y;
			this.state = new EStateGelMovingRight(this);
			projectiles = new List<IProjectile>();           /*Projectiles*/
			this.hitBox = new Rectangle(x, y, 16 * Size, 16 * Size);
			this.game = game;
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
		public void TakeDamage(int damage)
		{
			
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

		}

		public void PlayerCollision(ICollidable collidable)
		{
			Rectangle intersection = Rectangle.Intersect(hitBox, collidable.GetHitBox());
			if (intersection.Width > intersection.Height)
			{
				if (position.Y < collidable.GetHitBox().Top)
				{
					SetPosition((int)position.X, (int)position.Y - 50);
				}
				else
				{
					SetPosition((int)position.X, (int)position.Y + 50);
				}
			}
			else
			{
				if (position.X < collidable.GetHitBox().Left)
				{
					SetPosition((int)position.X - 50, (int)position.Y);
				}
				else
				{
					SetPosition((int)position.X + 50, (int)position.Y);
				}
			}
			TakeDamage(1);
		}

		public void EnemyCollision(ICollidable collidable)
		{

		}

		public void ProjectileCollision(ICollidable collidable)
		{
			Rectangle intersection = Rectangle.Intersect(hitBox, collidable.GetHitBox());
			if (intersection.Width > intersection.Height)
			{
				if (position.Y < collidable.GetHitBox().Top)
				{
					SetPosition((int)position.X, (int)position.Y - 50);
				}
				else
				{
					SetPosition((int)position.X, (int)position.Y + 50);
				}
			}
			else
			{
				if (position.X < collidable.GetHitBox().Left)
				{
					SetPosition((int)position.X - 50, (int)position.Y);
				}
				else
				{
					SetPosition((int)position.X + 50, (int)position.Y);
				}
			}
			TakeDamage(1);
		}

		public void ItemCollision(ICollidable collidable)
		{

		}

		public void BlockCollision(ICollidable collidable)
		{

		}

		public void BorderCollision()
		{

		}

		public Rectangle GetHitBox()
		{
			return this.hitBox;
		}

		public void WaterCollision(ICollidable collidable)
		{
			
		}
	}
}