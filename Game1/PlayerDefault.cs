using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using Game1.Projectiles;
using System.Collections.Generic;

namespace Game1
{
	public class PlayerDefault : IPlayer
	{
		public Rectangle hitBox;
		private Vector2 position;
		private IPlayerState state;
		List<IProjectile> projectiles;
		IInventory inventory;

		public PlayerDefault(int x, int y)
		{
			this.inventory = new Inventory(this);
			this.Speed = 5;                /*Changeable*/
			this.Size = 3;                 /************/
			this.position = new Vector2();
			this.position.X = x;
			this.position.Y = y;
			this.state = new PStateIdleDown(this);
			projectiles = new List<IProjectile>();
			this.hitBox = new Rectangle(x, y, 15 * Size, 16 * Size);
		}

		public int Speed { get; set; }
		public int Size { get; set; }
		public Rectangle GetHitBox()
		{
			return this.hitBox;
		}

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
				/*else if (collidable is Block)
				{

				}*/
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
		public void Update()
		{
			foreach (IProjectile projectile in projectiles)
			{
				projectile.Update();
			}
			state.Update();
			this.hitBox.Location = this.position.ToPoint();
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