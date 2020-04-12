using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using Game1.Projectiles;

namespace Game1
{
    class TakeDamageCommand : ICommand
    {
        private Game1 game;
        private IInventory inventory;
        int damage;

        public TakeDamageCommand(Game1 game, int damage)
        {
            this.game = game;
            inventory = game.GetPlayer().GetInventory();
        }


        public void Execute()
        {
            
            
            inventory.Health -= damage;
        }
    }
}

