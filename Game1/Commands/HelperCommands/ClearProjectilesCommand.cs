using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System.Collections.Generic;

namespace Game1
{
    class ClearProjectilesCommand : ICommand
    {
		private List<IProjectile> projectiles;
		private List<ICollidable> collidables;

		public ClearProjectilesCommand(List<ICollidable> collidables, List<IProjectile> projectiles)
		{
			this.collidables = collidables;
			this.projectiles = projectiles;
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
			if (collidables.Count > 0)
			{
				for (int i = 0; i < collidables.Count; i++)
				{
					if (collidables[i] is IProjectile && ((IProjectile)collidables[i]).IsDone)
					{
						collidables.RemoveAt(i);
						i--;
					}
				}
			}

		}
	}
}
