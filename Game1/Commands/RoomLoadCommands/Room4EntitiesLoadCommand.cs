using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System.Collections.Generic;

namespace Game1
{
    class Room4EntitiesLoadCommand : ICommand
    {
		private List<IEnemy> enemies;
		private List<IItem> items;
		private List<ICollidable> collidables;
		private List<Block> blocks;
		private int hudOffset;
		public Room4EntitiesLoadCommand(List<IEnemy> enemies, List<IItem> items, List<ICollidable> collidables, List<Block> blocks, int hudOffset)
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
			enemies.Add(new Stalfos(200, hudOffset + 100));
			enemies.Add(new Stalfos(230, hudOffset + 150));
			enemies.Add(new Stalfos(220, hudOffset + 190));

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
			foreach (Block block in blocks)
			{
				collidables.Add(block);
			}

		}
	}
}
