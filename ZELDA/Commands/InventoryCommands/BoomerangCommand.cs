using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using Game1.Projectiles;

namespace Game1
{
    class BoomerangCommand : ICommand
    {
		private IPlayer player;
		private IInventory inventory;

		public BoomerangCommand(IPlayer player)
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
						pState = new PStateShootingUp(player, new ProjLinkBoomerangUp(player));
						break; //up
					case 1:
						pState = new PStateShootingDown(player, new ProjLinkBoomerangDown(player));
						break; //down
					case 2:
						pState = new PStateShootingLeft(player, new ProjLinkBoomerangLeft(player));
						break; //left
					case 3:
						pState = new PStateShootingRight(player, new ProjLinkBoomerangRight(player));
						break; //right
					default:
						pState = new PStateShootingDown(player, new ProjLinkBoomerangDown(player));
						break;
				}
				player.SetState(pState);
			
			
		}
	}
}
