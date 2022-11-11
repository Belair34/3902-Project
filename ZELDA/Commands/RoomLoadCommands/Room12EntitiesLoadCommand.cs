using Microsoft.Xna.Framework;
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
		private List<Water> waters;
		private int hudOffset;
		public Room12EntitiesLoadCommand(List<IEnemy> enemies, List<IItem> items, List<ICollidable> collidables, List<Water> waters, int hudOffset)
		{
			this.enemies = enemies;
			this.items = items;
			this.collidables = collidables;
			this.waters = waters;
			this.hudOffset = hudOffset;
		}

		public void Execute()
		{
			/*Enemies*/
			enemies.Add(new Goriya(500, hudOffset + 100));
			enemies.Add(new Goriya(400, hudOffset + 180));
			enemies.Add(new Goriya(550, hudOffset + 260));

			/*Items*/
			items.Add(new KeyItem(400, hudOffset + 120));
			/*waters*/
			waters.Add(new Water(250, hudOffset + 131, false));
			waters.Add(new Water(200, hudOffset + 131, false));
			waters.Add(new Water(150, hudOffset + 131, false));
			waters.Add(new Water(150, hudOffset + 174, false));
			waters.Add(new Water(150, hudOffset + 217, false));
			waters.Add(new Water(150, hudOffset + 260, false));
			waters.Add(new Water(150, hudOffset + 303, false));
			waters.Add(new Water(200, hudOffset + 303, false));
			waters.Add(new Water(250, hudOffset + 303, false));

			waters.Add(new Water(250, hudOffset + 217, false));
			waters.Add(new Water(300, hudOffset + 217, false));
			waters.Add(new Water(350, hudOffset + 217, false));
			waters.Add(new Water(400, hudOffset + 217, false));
			waters.Add(new Water(450, hudOffset + 217, false));
			waters.Add(new Water(500, hudOffset + 217, false));

			waters.Add(new Water(500, hudOffset + 131, false));
			waters.Add(new Water(550, hudOffset + 131, false));
			waters.Add(new Water(600, hudOffset + 131, false));
			waters.Add(new Water(600, hudOffset + 174, false));
			waters.Add(new Water(600, hudOffset + 217, false));
			waters.Add(new Water(600, hudOffset + 260, false));
			waters.Add(new Water(600, hudOffset + 303, false));
			waters.Add(new Water(550, hudOffset + 303, false));
			waters.Add(new Water(500, hudOffset + 303, false));


			/*Add all to collidables*/
			foreach (IEnemy enemy in enemies)
			{
				collidables.Add(enemy);
			}
			foreach(IItem item in items)
			{
				collidables.Add(item);
			}
			foreach(Water Water in waters)
			{
				collidables.Add(Water);
			}
		}
	}
}
