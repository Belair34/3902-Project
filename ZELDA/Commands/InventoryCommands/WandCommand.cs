using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using Game1.Projectiles;

namespace Game1
{
    class WandCommand : ICommand
    {
		private IPlayer player;
		private IInventory inventory;

		public WandCommand(IPlayer player)
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

				IPlayerState pState;
				switch (inventory.Direction)
				{
					case 0:
						pState = new PStateShootingUp(player, new ProjLinkWandUp(player));
						break; //up
					case 1:
						pState = new PStateShootingDown(player, new ProjLinkWandDown(player));
						break; //down
					case 2:
						pState = new PStateShootingLeft(player, new ProjLinkWandLeft(player));
						break; //left
					case 3:
						pState = new PStateShootingRight(player, new ProjLinkWandRight(player));
						break; //right
					default:
						pState = new PStateShootingDown(player, new ProjLinkWandDown(player));
						break;
				}
				player.SetState(pState);
			
			
		}
	}
}
