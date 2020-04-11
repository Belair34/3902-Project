using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System.Collections.Generic;

namespace Game1
{
    class Room5EntitiesLoadCommand : ICommand
    {
		private List<IEnemy> enemies;
		private List<IItem> items;
		private List<ICollidable> collidables;
		private List<Block> blocks;
		private int hudOffset;
		public Room5EntitiesLoadCommand(List<IEnemy> enemies, List<IItem> items, List<ICollidable> collidables, List<Block> blocks, int hudOffset)
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
			enemies.Add(new Stalfos(200, hudOffset + 300, 5, 5));
			enemies.Add(new Stalfos(230, hudOffset + 150, 5, 5));
			enemies.Add(new Stalfos(280, hudOffset + 250, 5, 5));
			enemies.Add(new Stalfos(350, hudOffset + 230, 5, 5));
			enemies.Add(new Stalfos(400, hudOffset + 100, 5, 5));
			/*Items*/

			/*Blocks*/
			blocks.Add(new Block(200, hudOffset + 174, false));
			blocks.Add(new Block(200, hudOffset + 260, false));
			blocks.Add(new Block(550, hudOffset + 174, false));
			blocks.Add(new Block(550, hudOffset + 260, false));


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
