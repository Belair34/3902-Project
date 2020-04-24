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
		private int hudOffset;
		public Room7EntitiesLoadCommand(List<IEnemy> enemies, List<IItem> items, List<ICollidable> collidables, List<Block> blocks, int hudOffset)
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
			enemies.Add(new Keese(200, hudOffset + 100));
			enemies.Add(new Keese(630, hudOffset + 150));
			enemies.Add(new Keese(400, hudOffset + 180));
			enemies.Add(new Keese(500, hudOffset + 180));
			enemies.Add(new Keese(700, hudOffset + 250));
			enemies.Add(new Keese(400, hudOffset + 240));
			enemies.Add(new Keese(500, hudOffset + 240));
			enemies.Add(new Keese(600, hudOffset + 450));

			/*Items*/
			items.Add(new CompassItem(600, hudOffset + 250));
			/*Blocks*/
			blocks.Add(new Block(200, hudOffset + 131, false));
			blocks.Add(new Block(200, hudOffset + 303, false));
			blocks.Add(new Block(550, hudOffset + 131, false));
			blocks.Add(new Block(550, hudOffset + 303, false));

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
