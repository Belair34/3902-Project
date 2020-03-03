using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using Game1.Projectiles;
using System.Collections.Generic;

namespace Game1
{
	public class Keese : IEnemy
	{
		private Vector2 position;
		private Vector2 Boundary;
		private IEnemyState state;
		List<IProjectile> projectiles;
		int maxHealth;
		int health;

		public Keese(int x, int y, int health, int maxHealth, GraphicsDevice window)
		{
			this.Speed = 1;                /*Changeable*/
			this.Size = 3;                 /************/
			this.position = new Vector2(); 
			this.position.X = x;
			this.position.Y = y;
			this.Boundary = new Vector2();
			this.Boundary.X = window.Viewport.Width;
			this.Boundary.Y = window.Viewport.Height;
			this.state = new EStateKeeseIdleAnimated(this);
			projectiles = new List<IProjectile>();           /*Projectiles*/
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
		public Vector2 GetBoundary()
		{
			return Boundary;
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

		public ICollidable GetCollision()
		{
			throw new System.NotImplementedException();
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