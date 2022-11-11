using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class MoveRightCommand : ICommand
    {
		private Game1 myGame;

		public MoveRightCommand(Game1 game)
		{
			myGame = game;
		}

		public void Execute()
		{
			myGame.GetPlayer().MoveRight();
		}
	}
}
