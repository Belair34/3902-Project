using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System.Collections.Generic;

namespace Game1
{
    class Room1EntitiesLoadCommand : ICommand
    {
		private List<IEnemy> enemies;
		private List<IItem> items;
		private List<ICollidable> collidables;
		private List<Block> blocks;

		public Room1EntitiesLoadCommand(List<IEnemy> enemies, List<IItem> items, List<ICollidable> collidables, List<Block> blocks)
		{
			this.enemies = enemies;
			this.items = items;
			this.collidables = collidables;
			this.blocks = blocks;
		}

		public void Execute()
		{
			/*Enemies*/


			/*Items*/

			/*Blocks*/
			blocks.Add(new Block(150, 129, false));
			blocks.Add(new Block(300, 129, false));

			blocks.Add(new Block(450, 129, false));
			blocks.Add(new Block(600, 129, false));

			blocks.Add(new Block(150, 217, false));
			blocks.Add(new Block(300, 217, false));

			blocks.Add(new Block(450, 217, false));
			blocks.Add(new Block(600, 217, false));

			blocks.Add(new Block(150, 303, false));
			blocks.Add(new Block(300, 303, false));

			blocks.Add(new Block(450, 303, false));
			blocks.Add(new Block(600, 303, false));

			/*Add all to collidables*/
			foreach (IEnemy enemy in enemies)
			{
				collidables.Add(enemy);
			}
			foreach(IItem item in items)
			{
				collidables.Add(item);
			}
			foreach(Block block in blocks)
			{
				collidables.Add(block);
			}


		}
	}
}
