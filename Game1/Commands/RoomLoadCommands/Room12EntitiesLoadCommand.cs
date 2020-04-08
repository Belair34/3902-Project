using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System.Collections.Generic;

namespace Game1
{
    class Room12EntitiesLoadCommand : ICommand
    {
		private List<IEnemy> enemies;
		private List<IItem> items;
		private List<ICollidable> collidables;
		private List<Block> blocks;

		public Room12EntitiesLoadCommand(List<IEnemy> enemies, List<IItem> items, List<ICollidable> collidables, List<Block> blocks)
		{
			this.enemies = enemies;
			this.items = items;
			this.collidables = collidables;
			this.blocks = blocks;
		}

		public void Execute()
		{
			/*Enemies*/
			enemies.Add(new Goriya(500, 100, 5, 5));
			enemies.Add(new Goriya(400, 180, 5, 5));
			enemies.Add(new Goriya(550, 260, 5, 5));

			/*Items*/

			/*Blocks*/
			blocks.Add(new Block(250, 131, false));
			blocks.Add(new Block(200, 131, false));
			blocks.Add(new Block(150, 131, false));
			blocks.Add(new Block(150, 174, false));
			blocks.Add(new Block(150, 217, false));
			blocks.Add(new Block(150, 260, false));
			blocks.Add(new Block(150, 303, false));
			blocks.Add(new Block(200, 303, false));
			blocks.Add(new Block(250, 303, false));

			blocks.Add(new Block(250, 217, false));
			blocks.Add(new Block(300, 217, false));
			blocks.Add(new Block(350, 217, false));
			blocks.Add(new Block(400, 217, false));
			blocks.Add(new Block(450, 217, false));
			blocks.Add(new Block(500, 217, false));

			blocks.Add(new Block(500, 131, false));
			blocks.Add(new Block(550, 131, false));
			blocks.Add(new Block(600, 131, false));
			blocks.Add(new Block(600, 174, false));
			blocks.Add(new Block(600, 217, false));
			blocks.Add(new Block(600, 260, false));
			blocks.Add(new Block(600, 303, false));
			blocks.Add(new Block(550, 303, false));
			blocks.Add(new Block(500, 303, false));


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
