using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Design;

namespace Game1
{
    public class PauseController : IController
    {
        private KeyboardState keyboardState;

        ICommand currentCommand;
        Dictionary<Keys, ICommand> commandLibrary;

        public PauseController()
        {
            commandLibrary = new Dictionary<Keys, ICommand>();
            commandLibrary.Add(Keys.Enter, currentCommand = new PauseCommand());
            commandLibrary.Add(Keys.Q, currentCommand = new QuitCommand());
        }

        public void Update()
        {
            currentCommand = new NothingCommand();
            GamePadState gamepadState = GamePad.GetState(PlayerIndex.One);
            keyboardState = Keyboard.GetState();
            foreach (Keys key in keyboardState.GetPressedKeys())
            {
                if (commandLibrary.ContainsKey(key))
                {
                    currentCommand = commandLibrary[key];
                    currentCommand.Execute();
                }
            }
        }
    }
}
