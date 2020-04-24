using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System.Collections.Generic;

namespace Game1
{
    class Room6EntitiesLoadCommand : ICommand
    {
		private List<IEnemy> enemies;
		private List<IItem> items;
		private List<ICollidable> collidables;
		private List<Block> blocks;
		private int hudOffset;
		public Room6EntitiesLoadCommand(List<IEnemy> enemies, List<IItem> items, List<ICollidable> collidables, List<Block> blocks, int hudOffset)
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
			enemies.Add(new Keese(500, hudOffset + 100));
			enemies.Add(new Keese(200, hudOffset + 150));
			enemies.Add(new Keese(120, hudOffset + 220));
			enemies.Add(new Keese(250, hudOffset + 300));
			enemies.Add(new Keese(160, hudOffset + 400));
			enemies.Add(new Keese(500, hudOffset + 500));
			/*Items*/

			/*Blocks*/
			blocks.Add(new Block(350, hudOffset + 174, true));
			blocks.Add(new Block(350, hudOffset + 217, true));
			blocks.Add(new Block(350, hudOffset + 260, true));
			blocks.Add(new Block(400, hudOffset + 174, true));
			blocks.Add(new Block(400, hudOffset + 217, true));
			blocks.Add(new Block(400, hudOffset + 260, true));

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
