using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using Game1.Projectiles;
using System.Collections.Generic;

namespace Game1
{
	public class DamagedLink : IPlayer
	{
		Game1 game;
		private IPlayer decoratedLink;
		int timer = 1000;
		
		public DamagedLink(IPlayer decoratedLink, Game1 game)
		{
			this.decoratedLink = decoratedLink;
			this.game = game;
			game.SetPlayer(this);
		}
		public void TakeDamage()
		{
			// no damage taken
		}
		public void Update()
		{
			timer--;
			if(timer == 0)
			{
				RemoveDecorator();
			}
			decoratedLink.Update();
		}
		public void RemoveDecorator()
		{
			game.SetPlayer(decoratedLink);
		}
		public int Speed { get; set; }
		public int Size { get; set; }
		public Rectangle GetHitBox()
		{
			return decoratedLink.GetHitBox();
		}

		public List<IProjectile> GetProjectiles()
		{
			return decoratedLink.GetProjectiles();
		}
		public IInventory GetInventory()
		{
			return decoratedLink.GetInventory();
		}
		
		public void SetPosition(int x, int y)
		{
			
		}

		public Vector2 GetPosition()
		{
			return decoratedLink.GetPosition();
		}
		public void SetState(IPlayerState state)
		{
		}

		public IPlayerState GetState()
		{
			return decoratedLink.GetState();
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

		public void Draw(SpriteBatch spriteBatch)
		{
			decoratedLink.Draw(spriteBatch);
		}

	}
}