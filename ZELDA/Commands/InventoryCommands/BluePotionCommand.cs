using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class BluePotionCommand : ICommand
    {
		private IPlayer player;
		private IInventory inventory;

		public BluePotionCommand(Game1 game)
		{
			Initialize(player);
		}

		public void Initialize(IPlayer player)
		{
			this.player = player;
			inventory = player.GetInventory();
		}

		public void Execute()
		{
			inventory.Health = inventory.MaxHealth;
			//remove potion from inventory
		}
	}
}
