﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using Game1.Projectiles;
using System.Collections.Generic;

namespace Game1
{
	public class PlayerDefault : IPlayer
	{
		private Vector2 position;
		private Vector2 Boundary;
		private IPlayerState state;
		List<IProjectile> projectiles;
		IInventory inventory;

		public PlayerDefault(int x, int y, int health, int maxHealth, GraphicsDevice window)
		{
			this.inventory = new Inventory(this);
			this.Speed = 5;                /*Changeable*/
			this.Size = 3;                 /************/
			this.position = new Vector2(); 
			this.position.X = x;
			this.position.Y = y;
			this.Boundary = new Vector2();
			this.Boundary.X = window.Viewport.Width;
			this.Boundary.Y = window.Viewport.Height;
			this.state = new PStateIdleDown(this);
			projectiles = new List<IProjectile>();           /*Projectiles*/
		}

        public int Speed { get; set; }
		public int Size { get; set; }

		public List<IProjectile> GetProjectiles()
		{
			return this.projectiles;
		}
		public IInventory GetInventory()
		{
			return inventory;
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
		public void SetState(IPlayerState state)
		{
			this.state = state;
		}

		public IPlayerState GetState()
		{
			return this.state;
		}

		public void MoveUp()
		{
			state.MoveUp();
			inventory.Direction = 0;
		}

		public void MoveDown()
		{
			state.MoveDown();
			inventory.Direction = 1;
		}

		public void MoveLeft()
		{
			state.MoveLeft();
			inventory.Direction = 2;
		}

		public void MoveRight()
		{
			state.MoveRight();
			inventory.Direction = 3;
		}

		public void SlotA()
		{
			state.SlotA();
		}

		public void SlotB()
		{
			state.SlotB();
		}

		public void Stop()
		{
			state.Stop();
		}

		public void TakeDamage(int damage)
		{
			ICommand damageCommand = new TakeDamageCommand(this, damage);
			damageCommand.Execute();
		}

		public void Update()
		{
			foreach (IProjectile projectile in projectiles)
			{
				projectile.Update();
			}
			state.Update();
			inventory.Update();
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			foreach (IProjectile projectile in projectiles)
			{
				projectile.Draw(spriteBatch);
			}
			state.Draw(spriteBatch);
		}


	}
}