using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System.Collections.Generic;

namespace Game1
{
    class Room17EntitiesLoadCommand : ICommand
    {
		private List<IEnemy> enemies;
		private List<IItem> items;
		private List<ICollidable> collidables;
		private List<Block> blocks;
		private int hudOffset;
		Game1 game;

		public Room17EntitiesLoadCommand(List<IEnemy> enemies, List<IItem> items, List<ICollidable> collidables, List<Block> blocks, Game1 game, int hudOffset)
		{
			this.enemies = enemies;
			this.items = items;
			this.collidables = collidables;
			this.blocks = blocks;
			this.game = game;
			this.hudOffset = hudOffset;
		}

		public void Execute()
		{
			/*Enemies*/
			enemies.Add(new Aquamentus(500, hudOffset + 200, game));

			/*Items*/
			items.Add(new HeartItem(600, hudOffset + 220));
			/*Blocks*/
			blocks.Add(new Block(450, hudOffset + 88, false));
			blocks.Add(new Block(500, hudOffset + 88, false));
			blocks.Add(new Block(550, hudOffset + 88, false));
			blocks.Add(new Block(600, hudOffset + 88, false));
			blocks.Add(new Block(650, hudOffset + 88, false));

			blocks.Add(new Block(550, hudOffset + 131, false));
			blocks.Add(new Block(600, hudOffset + 131, false));
			blocks.Add(new Block(650, hudOffset + 131, false));

			blocks.Add(new Block(600, hudOffset + 174, false));
			blocks.Add(new Block(650, hudOffset + 174, false));

			blocks.Add(new Block(600, hudOffset + 260, false));
			blocks.Add(new Block(650, hudOffset + 260, false));

			blocks.Add(new Block(550, hudOffset + 303, false));
			blocks.Add(new Block(600, hudOffset + 303, false));
			blocks.Add(new Block(650, hudOffset + 303, false));

			blocks.Add(new Block(450, hudOffset + 346, false));
			blocks.Add(new Block(500, hudOffset + 346, false));
			blocks.Add(new Block(550, hudOffset + 346, false));
			blocks.Add(new Block(600, hudOffset + 346, false));
			blocks.Add(new Block(650, hudOffset + 346, false));

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
