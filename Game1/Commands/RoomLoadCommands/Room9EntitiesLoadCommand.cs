using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System.Collections.Generic;

namespace Game1
{
    class Room9EntitiesLoadCommand : ICommand
    {
		private List<IEnemy> enemies;
		private List<IItem> items;
		private List<ICollidable> collidables;
		private List<Block> blocks;

		public Room9EntitiesLoadCommand(List<IEnemy> enemies, List<IItem> items, List<ICollidable> collidables, List<Block> blocks)
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
			blocks.Add(new Block(350, 217, true));

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
