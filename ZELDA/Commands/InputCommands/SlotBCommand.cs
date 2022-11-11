using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class SlotBCommand : ICommand
    {
		private Game1 myGame;

		public SlotBCommand(Game1 game)
		{
			myGame = game;
		}

		public void Execute()
		{
			myGame.GetPlayer().SlotB();
		}
	}
}
