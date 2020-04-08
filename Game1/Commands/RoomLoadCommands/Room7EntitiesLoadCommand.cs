using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System.Collections.Generic;

namespace Game1
{
    class Room7EntitiesLoadCommand : ICommand
    {
		private List<IEnemy> enemies;
		private List<IItem> items;
		private List<ICollidable> collidables;
		private List<Block> blocks;

		public Room7EntitiesLoadCommand(List<IEnemy> enemies, List<IItem> items, List<ICollidable> collidables, List<Block> blocks)
		{
			this.enemies = enemies;
			this.items = items;
			this.collidables = collidables;
			this.blocks = blocks;
		}

		public void Execute()
		{
			/*Enemies*/
			enemies.Add(new Keese(200, 100, 5, 5));
			enemies.Add(new Keese(630, 150, 5, 5));
			enemies.Add(new Keese(400, 180, 5, 5));
			enemies.Add(new Keese(500, 180, 5, 5));
			enemies.Add(new Keese(700, 250, 5, 5));
			enemies.Add(new Keese(400, 240, 5, 5));
			enemies.Add(new Keese(500, 240, 5, 5));
			enemies.Add(new Keese(600, 450, 5, 5));

			/*Items*/

			/*Blocks*/
			blocks.Add(new Block(200, 131, false));
			blocks.Add(new Block(200, 303, false));
			blocks.Add(new Block(550, 131, false));
			blocks.Add(new Block(550, 303, false));

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
