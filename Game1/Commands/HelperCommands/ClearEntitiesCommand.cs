using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System.Collections.Generic;

namespace Game1
{
    class ClearEntitiesCommand : ICommand
    {
		private List<IProjectile> projectiles;
		private List<ICollidable> collidables;
		private List<IItem> items;
		private List<IEnemy> enemies;

		public ClearEntitiesCommand(List<ICollidable> collidables, List<IProjectile> projectiles, List<IItem> items, List<IEnemy> enemies)
		{
			this.collidables = collidables;
			this.projectiles = projectiles;
			this.items = items;
			this.enemies = enemies;
		}

		public void Execute()
		{
			for(int i = 0; i < projectiles.Count; i++)
			{
				if (projectiles[i].IsDone)
				{
					projectiles.RemoveAt(i);
					i--;
				}
			}

			for (int i = 0; i < items.Count; i++)
			{
				if (items[i].IsDone)
				{
					items.RemoveAt(i);
					i--;
				}
			}

			for (int i = 0; i < enemies.Count; i++)
			{
				if (enemies[i].IsDone)
				{
					enemies.RemoveAt(i);
					i--;
				}
			}

			if (collidables.Count > 0)
			{
				for (int i = 0; i < collidables.Count; i++)
				{
					if ((collidables[i] is IProjectile && ((IProjectile)collidables[i]).IsDone) || (collidables[i] is IItem && ((IItem)collidables[i]).IsDone) || (collidables[i] is IEnemy && ((IEnemy)collidables[i]).IsDone))
					{
						collidables.RemoveAt(i);
						i--;
					}
				}
			}

		}
	}
}
