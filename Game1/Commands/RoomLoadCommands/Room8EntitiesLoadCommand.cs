﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System.Collections.Generic;

namespace Game1
{
    class Room8EntitiesLoadCommand : ICommand
    {
		private List<IEnemy> enemies;
		private List<IItem> items;
		private List<ICollidable> collidables;
		private List<Block> blocks;

		public Room8EntitiesLoadCommand(List<IEnemy> enemies, List<IItem> items, List<ICollidable> collidables, List<Block> blocks)
		{
			this.enemies = enemies;
			this.items = items;
			this.collidables = collidables;
			this.blocks = blocks;
		}

		public void Execute()
		{
			/*Enemies*/
			enemies.Add(new Gel(200, 80, 5, 5));
			enemies.Add(new Gel(250, 130, 5, 5));
			enemies.Add(new Gel(240, 300, 5, 5));
			enemies.Add(new Gel(500, 80, 5, 5));
			enemies.Add(new Gel(500, 130, 5, 5));

			/*Items*/

			/*Blocks*/
			blocks.Add(new Block(150, 131, false));
			blocks.Add(new Block(200, 131, false));
			
			blocks.Add(new Block(150, 303, false));			
			blocks.Add(new Block(200, 303, false));

			blocks.Add(new Block(350, 217, false));
			blocks.Add(new Block(400, 217, false));

			blocks.Add(new Block(550, 131, false));
			blocks.Add(new Block(600, 131, false));

			blocks.Add(new Block(550, 303, false));
			blocks.Add(new Block(600, 303, false));

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
