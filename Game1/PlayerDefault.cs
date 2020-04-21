using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using Game1.Projectiles;
using System.Collections.Generic;
using Game1.Sound;

namespace Game1
{
	public class PlayerDefault : IPlayer
	{
		public Rectangle hitBox;
		private Vector2 position;
		private IPlayerState state;
		List<IProjectile> projectiles;
		IInventory inventory;
		Game1 game;

		public PlayerDefault(int x, int y, Game1 game)
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
			this.game = game;
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
            ZeldaSound.Instance.TakeDamage();
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
			if (!(state is PStateDamagedDown || state is PStateDamagedLeft || state is PStateDamagedRight || state is PStateDamagedUp))
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
		}

		public void ProjectileCollision(ICollidable collidable)
		{

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