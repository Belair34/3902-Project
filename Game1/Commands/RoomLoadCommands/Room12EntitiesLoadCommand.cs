﻿using Microsoft.Xna.Framework;
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
		private int hudOffset;

		public Room12EntitiesLoadCommand(List<IEnemy> enemies, List<IItem> items, List<ICollidable> collidables, List<Block> blocks, int hudOffset)
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
			enemies.Add(new Goriya(500, hudOffset + 100, 5, 5));
			enemies.Add(new Goriya(400, hudOffset + 180, 5, 5));
			enemies.Add(new Goriya(550, hudOffset + 260, 5, 5));

			/*Items*/
			items.Add(new KeyItem(400, hudOffset + 120));
			/*Blocks*/
			blocks.Add(new Block(250, hudOffset + 131, false));
			blocks.Add(new Block(200, hudOffset + 131, false));
			blocks.Add(new Block(150, hudOffset + 131, false));
			blocks.Add(new Block(150, hudOffset + 174, false));
			blocks.Add(new Block(150, hudOffset + 217, false));
			blocks.Add(new Block(150, hudOffset + 260, false));
			blocks.Add(new Block(150, hudOffset + 303, false));
			blocks.Add(new Block(200, hudOffset + 303, false));
			blocks.Add(new Block(250, hudOffset + 303, false));

			blocks.Add(new Block(250, hudOffset + 217, false));
			blocks.Add(new Block(300, hudOffset + 217, false));
			blocks.Add(new Block(350, hudOffset + 217, false));
			blocks.Add(new Block(400, hudOffset + 217, false));
			blocks.Add(new Block(450, hudOffset + 217, false));
			blocks.Add(new Block(500, hudOffset + 217, false));

			blocks.Add(new Block(500, hudOffset + 131, false));
			blocks.Add(new Block(550, hudOffset + 131, false));
			blocks.Add(new Block(600, hudOffset + 131, false));
			blocks.Add(new Block(600, hudOffset + 174, false));
			blocks.Add(new Block(600, hudOffset + 217, false));
			blocks.Add(new Block(600, hudOffset + 260, false));
			blocks.Add(new Block(600, hudOffset + 303, false));
			blocks.Add(new Block(550, hudOffset + 303, false));
			blocks.Add(new Block(500, hudOffset + 303, false));


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
