using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System;

namespace Game1
{
    class BombCommand : ICommand
    {
		private IPlayer player;
		private IInventory inventory;

		public BombCommand(IPlayer player)
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
			if (inventory.Bombs != 0)
			{
				IPlayerState pState;
				switch (inventory.Direction)
				{
					case 0:
						pState = new PStateShootingUp(player, new ProjLinkBombUp(player));
						break; //up
					case 1:
						pState = new PStateShootingDown(player, new ProjLinkBombDown(player));
						break; //down
					case 2:
						pState = new PStateShootingLeft(player, new ProjLinkBombLeft(player));
						break; //left
					case 3:
						pState = new PStateShootingRight(player, new ProjLinkBombRight(player));
						break; //right
					default:
						pState = new PStateShootingDown(player, new ProjLinkBombDown(player));
						break;
				}
				player.SetState(pState);
				inventory.Bombs--;
			}
		}
	}
}
