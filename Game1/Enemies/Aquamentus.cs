﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using Game1.Projectiles;
using System.Collections.Generic;
using System;

namespace Game1
{
	public class Aquamentus : IEnemy
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

		public Aquamentus(int x, int y, int health, int maxHealth)
		{
			this.Speed = 2;                /*Changeable*/
			this.Size = 3;                 /************/
			this.position = new Vector2();
			this.position.X = x;
			this.position.Y = y;
			this.state = new EStateAquamentusMovingLeft(this);
			projectiles = new List<IProjectile>();           /*Projectiles*/
			hitBox = new Rectangle(x, y, 24 * Size, 32 * Size);
			numberGenerator = new Random();
			maxTimer = 100;
			movementTimer = numberGenerator.NextDouble()*maxTimer;
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

		}

		public void PlayerCollision(ICollidable collidable)
		{

		}

		public void EnemyCollision(ICollidable collidable)
		{

		}

		public void ProjectileCollision(ICollidable collidable)
		{

		}

		public void ItemCollision(ICollidable collidable)
		{

		}

		public void BlockCollision(ICollidable collidable)
		{

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