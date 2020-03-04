using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System.Collections.Generic;

namespace Game1
{
    class CheckAllCollisionsCommand : ICommand
    {
		private Border border;
		private List<ICollidable> collidables;

		public CheckAllCollisionsCommand(List<ICollidable> collidables, Border border)
		{
			this.collidables = collidables;
			this.border = border;
		}

		public void Execute()
		{
			for(int i = 0; i < collidables.Count-1; i++)
			{
				border.CheckCollision(collidables[i]);
				for (int j = i + 1; j < collidables.Count; j++)
				{
					collidables[i].CheckCollisions(collidables[j]);
				}
			}
			border.CheckCollision(collidables[collidables.Count-1]);

		}
	}
}
