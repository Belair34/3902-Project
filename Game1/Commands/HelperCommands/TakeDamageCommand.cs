using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using Game1.Projectiles;

namespace Game1
{
    class TakeDamageCommand : ICommand
    {
        private IPlayer player;
        private IInventory inventory;
        int damage;

        public TakeDamageCommand(IPlayer player, int damage)
        {
            Initialize(player);
            this.damage = damage;
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
                    pState = new PStateDamagedUp(player);
                    break; //up
                case 1:
                    pState = new PStateDamagedDown(player);
                    break; //down
                case 2:
                    pState = new PStateDamagedLeft(player);
                    break; //left
                case 3:
                    pState = new PStateDamagedRight(player);
                    break; //right
                default:
                    pState = new PStateDamagedDown(player);
                    break;
            }
            player.SetState(pState);
            inventory.Health -= damage;
        }
    }
}

