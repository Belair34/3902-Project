using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class MoveDownCommand : ICommand
    {
		private Game1 myGame;

		public MoveDownCommand(IPlayer player)
		{
			Initialize(player);
		}

		public void Initialize(IPlayer player)
		{
			//this.player = player;
		}

		public void Execute()
		{
			myGame.GetPlayer().MoveDown();
		}
	}
}
