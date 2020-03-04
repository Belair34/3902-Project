using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System.Collections.Generic;

namespace Game1
{
    class L1EntitiesLoadCommand : ICommand
    {
		private List<IEnemy> enemies;
		private List<IItem> items;
		private List<ICollidable> collidables;

		public L1EntitiesLoadCommand(List<IEnemy> enemies, List<IItem> items, List<ICollidable> collidables)
		{
			this.enemies = enemies;
			this.items = items;
			this.collidables = collidables;
		}

		public void Execute()
		{
			/*Enemies*/
			enemies.Add(new Aquamentus(600, 200, 10, 10));
			enemies.Add(new Gel(300, 350, 5, 5));
			
			/*Items*/
			items.Add(new ArrowItem(200, 150));

			/*Add all to collidables*/
			foreach(IEnemy enemy in enemies)
			{
				collidables.Add(enemy);
			}
			foreach(IItem item in items)
			{
				collidables.Add(item);
			}


		}
	}
}
