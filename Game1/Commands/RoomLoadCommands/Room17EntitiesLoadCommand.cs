using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System.Collections.Generic;

namespace Game1
{
    class Room17EntitiesLoadCommand : ICommand
    {
		private List<IEnemy> enemies;
		private List<IItem> items;
		private List<ICollidable> collidables;
		private List<Block> blocks;

		public Room17EntitiesLoadCommand(List<IEnemy> enemies, List<IItem> items, List<ICollidable> collidables, List<Block> blocks)
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
			blocks.Add(new Block(450, 88, false));
			blocks.Add(new Block(500, 88, false));
			blocks.Add(new Block(550, 88, false));
			blocks.Add(new Block(600, 88, false));
			blocks.Add(new Block(650, 88, false));

			blocks.Add(new Block(550, 131, false));
			blocks.Add(new Block(600, 131, false));
			blocks.Add(new Block(650, 131, false));

			blocks.Add(new Block(600, 174, false));
			blocks.Add(new Block(650, 174, false));

			blocks.Add(new Block(600, 260, false));
			blocks.Add(new Block(650, 260, false));

			blocks.Add(new Block(550, 303, false));
			blocks.Add(new Block(600, 303, false));
			blocks.Add(new Block(650, 303, false));

			blocks.Add(new Block(450, 346, false));
			blocks.Add(new Block(500, 346, false));
			blocks.Add(new Block(550, 346, false));
			blocks.Add(new Block(600, 346, false));
			blocks.Add(new Block(650, 346, false));

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
