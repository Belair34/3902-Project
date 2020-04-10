using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System.Collections.Generic;

namespace Game1
{
    class Room16EntitiesLoadCommand : ICommand
    {
		private List<IEnemy> enemies;
		private List<IItem> items;
		private List<ICollidable> collidables;
		private List<Block> blocks;
		private int hudOffset;

		public Room16EntitiesLoadCommand(List<IEnemy> enemies, List<IItem> items, List<ICollidable> collidables, List<Block> blocks, int hudOffset)
		{
			this.enemies = enemies;
			this.items = items;
			this.collidables = collidables;
			this.blocks = blocks;
			this.hudOffset = hudOffset;
		}

		public void Execute()
		{
			/*Enemies*/
			enemies.Add(new WallMaster(200, hudOffset + 80, 5, 5));
			enemies.Add(new WallMaster(260, hudOffset + 80, 5, 5));
			enemies.Add(new WallMaster(600, hudOffset + 80, 5, 5));
			enemies.Add(new WallMaster(660, hudOffset + 80, 5, 5));
			enemies.Add(new WallMaster(100, hudOffset + 270, 5, 5));
			enemies.Add(new WallMaster(100, hudOffset + 330, 5, 5));
			enemies.Add(new WallMaster(650, hudOffset + 270, 5, 5));
			enemies.Add(new WallMaster(650, hudOffset + 360, 5, 5));

			/*Items*/

			/*Blocks*/
			blocks.Add(new Block(150, hudOffset + 131, false));
			blocks.Add(new Block(250, hudOffset + 131, false));
			blocks.Add(new Block(350, hudOffset + 131, false));
			blocks.Add(new Block(400, hudOffset + 131, false));
			blocks.Add(new Block(500, hudOffset + 131, false));
			blocks.Add(new Block(600, hudOffset + 131, false));

			blocks.Add(new Block(150, hudOffset + 217, false));
			blocks.Add(new Block(250, hudOffset + 217, false));
			blocks.Add(new Block(350, hudOffset + 217, false));
			blocks.Add(new Block(400, hudOffset + 217, false));
			blocks.Add(new Block(500, hudOffset + 217, false));
			blocks.Add(new Block(600, hudOffset + 217, false));

			blocks.Add(new Block(150, hudOffset + 303, false));
			blocks.Add(new Block(250, hudOffset + 303, false));
			blocks.Add(new Block(350, hudOffset + 303, false));
			blocks.Add(new Block(400, hudOffset + 303, false));
			blocks.Add(new Block(500, hudOffset + 303, false));
			blocks.Add(new Block(600, hudOffset + 303, false));

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
