using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using Game1.Projectiles;
using System.Collections.Generic;

namespace Game1
{
	public class PlayerDamaged : IPlayer
	{
		Game1 game;
		private IPlayer decoratedLink;
		int timer;
		
		public PlayerDamaged(IPlayer decoratedLink, Game1 game)
		{
			this.decoratedLink = decoratedLink;
			this.game = game;
			this.timer = 1000;
			game.SetPlayer(this);
		}
		public void TakeDamage(int damage)
		{
            // no damage taken
		}
		public void Update()
		{
			timer--;
			if(timer < 0)
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
		public bool IsRangActive { get; set; }
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
			decoratedLink.SetPosition(x, y);
		}

		public Vector2 GetPosition()
		{
			return decoratedLink.GetPosition();
		}
		public void SetState(IPlayerState state)
		{
			decoratedLink.SetState(state);
		}

		public IPlayerState GetState()
		{
			return decoratedLink.GetState();
		}

		public void MoveUp()
		{
			decoratedLink.GetState().MoveUp();
		}

		public void MoveDown()
		{
			decoratedLink.GetState().MoveDown();
		}

		public void MoveLeft()
		{
			decoratedLink.GetState().MoveLeft();
		}

		public void MoveRight()
		{
			decoratedLink.GetState().MoveRight();
		}

		public void SlotA()
		{
			decoratedLink.GetState().SlotA();
		}

		public void SlotB()
		{
			decoratedLink.GetState().SlotB();
		}

		public void Stop()
		{
			decoratedLink.GetState().Stop();
		}
		
		public void CheckCollisions(ICollidable collidable)
		{
			decoratedLink.CheckCollisions(collidable);
		}

		public void PlayerCollision(ICollidable collidable)
		{
			decoratedLink.PlayerCollision(collidable);
		}

		public void EnemyCollision(ICollidable collidable)
		{
			decoratedLink.EnemyCollision(collidable);
		}

		public void ProjectileCollision(ICollidable collidable)
		{
			decoratedLink.PlayerCollision(collidable);
		}
		public void ItemCollision(ICollidable collidable)
		{
			decoratedLink.ItemCollision(collidable);
		}
		public void BlockCollision(ICollidable collidable)
		{
			decoratedLink.BlockCollision(collidable);
		}
		public void WaterCollision(ICollidable collidable)
		{
			decoratedLink.WaterCollision(collidable);
		}
		public void BorderCollision()
		{
			decoratedLink.BorderCollision();
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			decoratedLink.Draw(spriteBatch);
		}

		
	}
}