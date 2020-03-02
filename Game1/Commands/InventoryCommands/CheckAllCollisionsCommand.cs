using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System.Collections;

namespace Game1
{
    class CheckAllCollisionsCommand : ICommand
    {
		private Border border;
		private ArrayList collidables;

		public CheckAllCollisionsCommand(ArrayList collidables, Border border)
		{
			this.collidables = collidables;
			this.border = border;
		}

		public void Execute()
		{
			foreach (ICollidable collidable in collidables)
			{

			}
			
		}
	}
}
