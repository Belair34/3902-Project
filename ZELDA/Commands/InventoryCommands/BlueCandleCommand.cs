using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class BlueCandleCommand : ICommand
    {
		private IPlayer player;
		private IInventory inventory;

		public BlueCandleCommand(Game1 game)
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
			if (inventory.CandleUsed == 1)
			{
				//do nothing
			} else
			{
				//create fire projectile
				//if room is dark, light room
			}
		}
	}
}
