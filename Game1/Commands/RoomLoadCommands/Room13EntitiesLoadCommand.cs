﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System.Collections.Generic;

namespace Game1
{
    class Room13EntitiesLoadCommand : ICommand
    {
		private List<IEnemy> enemies;
		private List<IItem> items;
		private List<ICollidable> collidables;
		private List<Block> blocks;
		private int hudOffset;

		public Room13EntitiesLoadCommand(List<IEnemy> enemies, List<IItem> items, List<ICollidable> collidables, List<Block> blocks, int hudOffset)
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
			enemies.Add(new BladeTrap(80, hudOffset + 80, 5, 5));
			enemies.Add(new BladeTrap(650, hudOffset + 80, 5, 5));
			enemies.Add(new BladeTrap(80, hudOffset + 360, 5, 5));
			enemies.Add(new BladeTrap(660, hudOffset + 360, 5, 5));

			/*Items*/

			/*Blocks*/
			blocks.Add(new Block(500, hudOffset + 217, false));
			blocks.Add(new Block(450, hudOffset + 174, false));
			blocks.Add(new Block(400, hudOffset + 131, false));
			blocks.Add(new Block(350, hudOffset + 174, false));
			blocks.Add(new Block(300, hudOffset + 217, false));
			blocks.Add(new Block(350, hudOffset + 260, false));
			blocks.Add(new Block(400, hudOffset + 303, false));
			blocks.Add(new Block(450, hudOffset + 260, false));

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
