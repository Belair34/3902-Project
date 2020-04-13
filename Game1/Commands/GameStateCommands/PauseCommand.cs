using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game1
{
    public class PauseCommand : ICommand
    {
        public PauseCommand()
        {
        }
        public void Execute()
        {
            if (Game1.getInstance().paused)
            {
                Game1.getInstance().gameState = new ZeldaGameState();
                Game1.getInstance().paused = false;
            }
            else
            {
                Game1.getInstance().gameState = new PauseState();
            }
        }
    }
}