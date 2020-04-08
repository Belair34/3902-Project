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

		public Room5EntitiesLoadCommand(List<IEnemy> enemies, List<IItem> items, List<ICollidable> collidables, List<Block> blocks)
		{
			this.enemies = enemies;
			this.items = items;
			this.collidables = collidables;
			this.blocks = blocks;
		}

		public void Execute()
		{
			/*Enemies*/
			enemies.Add(new Stalfos(200, 400, 5, 5));
			enemies.Add(new Stalfos(230, 150, 5, 5));
			enemies.Add(new Stalfos(280, 250, 5, 5));
			enemies.Add(new Stalfos(350, 230, 5, 5));
			enemies.Add(new Stalfos(400, 100, 5, 5));
			/*Items*/

			/*Blocks*/
			blocks.Add(new Block(200, 174, false));
			blocks.Add(new Block(200, 260, false));
			blocks.Add(new Block(550, 174, false));
			blocks.Add(new Block(550, 260, false));


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
