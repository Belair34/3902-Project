using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using Game1.Projectiles;
using System.Collections.Generic;

namespace Game1
{
	public class PlayerDamage : IPlayer
	{
		public Rectangle hitBox;
		private Vector2 position;
		private IPlayerState state;
		private IPlayer player;
		List<IProjectile> projectiles;
		IInventory inventory;
		Game game;

		public PlayerDamage(IPlayer player)
		{
			this.player = player;
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
		public void takeEnemyDamage()
		{
			this.player.TakeDamage(1);
		}
		public void takeBossDamage()
		{
			player.TakeDamage(2);
		}
		public int getHealth(IInventory inventory)
		{
			int health = inventory.Health;
			return health;
		}
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
			
		}

		public Vector2 GetPosition()
		{
			return this.position;
		}
		public void SetState(IPlayerState state)
		{
		}

		public IPlayerState GetState()
		{
			return this.state;
		}

		public void MoveUp()
		{

		}

		public void MoveDown()
		{

		}

		public void MoveLeft()
		{

		}

		public void MoveRight()
		{

		}

		public void SlotA()
		{

		}

		public void SlotB()
		{

		}

		public void Stop()
		{

		}

		public void TakeDamage(int damage)
		{
			
		}
		
		public void CheckCollisions(ICollidable collidable)
		{
			
		}

		public void PlayerCollision(ICollidable collidable)
		{

		}

		public void EnemyCollision(ICollidable collidable)
		{
			/*if (!(state is PStateDamagedDown || state is PStateDamagedLeft || state is PStateDamagedRight || state is PStateDamagedUp))
			{
				Rectangle intersection = Rectangle.Intersect(hitBox, collidable.GetHitBox());
				if (intersection.Width > intersection.Height)
				{
					if (position.Y < collidable.GetHitBox().Top)
					{
						SetPosition((int)position.X, (int)position.Y - 100);
					}
					else
					{
						SetPosition((int)position.X, (int)position.Y + 100);
					}
				}
				else
				{
					if (position.X < collidable.GetHitBox().Left)
					{
						SetPosition((int)position.X - 100, (int)position.Y);
					}
					else
					{
						SetPosition((int)position.X + 100, (int)position.Y);
					}
				}
				TakeDamage(2);
			}*/
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