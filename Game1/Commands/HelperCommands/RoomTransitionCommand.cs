using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System.Collections.Generic;

namespace Game1
{
    class RoomTransitionCommand : ICommand
	{
        private Game1 game;
		private IRoom startRoom;
		private IRoom endRoom;
        private Border border;
        private GraphicsDeviceManager graphics;
		private int direction;
        private int counter;
		
        //First three parameters are important, other three are just to pass
		public RoomTransitionCommand(IRoom startRoom, IRoom endRoom, int direction, Game1 game, Border border, GraphicsDeviceManager graphics)
		{
			this.startRoom = startRoom;
			this.endRoom = endRoom;
            this.game = game;
            this.border = border;
            this.graphics = graphics;
			this.direction = direction;
            this.counter = 0;
		}

		public void Execute()
		{
            switch (direction)
            {
                case 0: //up
                    if(counter < 176/2)
                    {
                        startRoom.IncrementSourcePosition(-2, true);
                        counter++;
                    }
                    else
                    {
                        game.SetRoom(endRoom);
                    }
                    break;
                case 1: //down
                    if (counter < 176 / 2)
                    {
                        startRoom.IncrementSourcePosition(2, true);
                        counter++;
                    }
                    else
                    {
                        game.SetRoom(endRoom);
                    }
                    break;
                case 2: //left
                    if (counter < 256 / 2)
                    {
                        startRoom.IncrementSourcePosition(-2, false);
                        counter++;
                    }
                    else
                    {
                        game.SetRoom(endRoom);
                    }
                    break;
                case 3: //right
                    if (counter < 256 / 2)
                    {
                        startRoom.IncrementSourcePosition(2, false);
                        counter++;
                    }
                    else
                    {
                        game.SetRoom(endRoom);
                    }
                    break;
                default:

                    break;
            }

        }
	}
}
