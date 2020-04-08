using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System.Collections.Generic;

namespace Game1
{
    class Room11EntitiesLoadCommand : ICommand
    {
		private List<IEnemy> enemies;
		private List<IItem> items;
		private List<ICollidable> collidables;
		private List<Block> blocks;

		public Room11EntitiesLoadCommand(List<IEnemy> enemies, List<IItem> items, List<ICollidable> collidables, List<Block> blocks)
		{
			this.enemies = enemies;
			this.items = items;
			this.collidables = collidables;
			this.blocks = blocks;
		}

		public void Execute()
		{
			/*Enemies*/
			enemies.Add(new Stalfos(150, 150, 5, 5));
			enemies.Add(new Stalfos(200, 200, 5, 5));
			enemies.Add(new Stalfos(600, 150, 5, 5));

			/*Items*/

			/*Blocks*/
			blocks.Add(new Block(100, 346, false));
			blocks.Add(new Block(150, 346, false));
			blocks.Add(new Block(200, 346, false));
			blocks.Add(new Block(250, 346, false));
			blocks.Add(new Block(300, 346, false));
			blocks.Add(new Block(450, 346, false));
			blocks.Add(new Block(500, 346, false));
			blocks.Add(new Block(550, 346, false));
			blocks.Add(new Block(600, 346, false));
			blocks.Add(new Block(650, 346, false));

			blocks.Add(new Block(650, 303, false));
			blocks.Add(new Block(650, 260, false));

			blocks.Add(new Block(450, 303, false));
			blocks.Add(new Block(450, 260, false));
			blocks.Add(new Block(450, 217, false));
			blocks.Add(new Block(450, 174, false));
			blocks.Add(new Block(400, 174, false));

			blocks.Add(new Block(200, 303, false));
			blocks.Add(new Block(200, 260, false));
			blocks.Add(new Block(200, 217, false));
			blocks.Add(new Block(200, 174, false));

			blocks.Add(new Block(100, 303, false));
			blocks.Add(new Block(100, 260, false));

			blocks.Add(new Block(100, 88, false));
			blocks.Add(new Block(150, 88, false));
			blocks.Add(new Block(200, 88, false));
			blocks.Add(new Block(250, 88, false));
			blocks.Add(new Block(300, 88, false));
			blocks.Add(new Block(450, 88, false));
			blocks.Add(new Block(500, 88, false));
			blocks.Add(new Block(550, 88, false));
			blocks.Add(new Block(600, 88, false));
			blocks.Add(new Block(650, 88, false));

			blocks.Add(new Block(650, 131, false));
			blocks.Add(new Block(650, 174, false));

			blocks.Add(new Block(550, 131, false));
			blocks.Add(new Block(550, 174, false));
			blocks.Add(new Block(550, 217, false));
			blocks.Add(new Block(550, 260, false));

			blocks.Add(new Block(300, 131, false));
			blocks.Add(new Block(300, 174, false));
			blocks.Add(new Block(300, 217, false));
			blocks.Add(new Block(300, 260, false));
			blocks.Add(new Block(350, 260, false));

			blocks.Add(new Block(100, 174, false));
			blocks.Add(new Block(100, 131, false));


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
