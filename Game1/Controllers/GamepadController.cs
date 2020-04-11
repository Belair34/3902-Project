using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{

    public class GamepadController : IController
    {
        Game1 myGame;
        int delay;
        private GamePadState state;
        public GamepadController(Game1 game)
        {
            myGame = game;
            delay = 0;
        }

        public void Update()
        {/*
            state = GamePad.GetState(PlayerIndex.One);
            if (state.Buttons.LeftShoulder.Equals(ButtonState.Pressed))
            {
                myGame.GetPlayer().TakeDamage(2);
            }
            else if (state.Buttons.Back.Equals(ButtonState.Pressed))
            {
                myGame.Exit();
            }
            else if (state.Buttons.Start.Equals(ButtonState.Pressed))
            {
                myGame.Reset();
            }
            else if (state.Buttons.A.Equals(ButtonState.Pressed))
            {
                myGame.GetPlayer().SlotA();
            }
            else if (state.Buttons.B.Equals(ButtonState.Pressed))
            {
                myGame.GetPlayer().SlotB();
            }
            else if (state.Buttons.X.Equals(ButtonState.Pressed))
            {
                myGame.GetPlayer().GetInventory().SetSlotBCommand(new BowCommand(myGame.GetPlayer()));
                myGame.GetPlayer().SlotB();
            }
            else if (state.Buttons.Y.Equals(ButtonState.Pressed))
            {
                myGame.GetPlayer().GetInventory().SetSlotBCommand(new WandCommand(myGame.GetPlayer()));
                myGame.GetPlayer().SlotB();
            }
            else if (state.Buttons.RightShoulder.Equals(ButtonState.Pressed))
            {
                myGame.GetPlayer().GetInventory().SetSlotBCommand(new BoomerangCommand(myGame.GetPlayer()));
                myGame.GetPlayer().SlotB();
            }
            else if (state.ThumbSticks.Left.Equals(ButtonState.Pressed))
            {
                myGame.GetPlayer().GetInventory().SetSlotBCommand(new BombCommand(myGame.GetPlayer()));
                myGame.GetPlayer().SlotB();
            }
            else if (state.ThumbSticks.Right.Equals(ButtonState.Pressed))
            {
                myGame.GetPlayer().GetInventory().SetSlotBCommand(new EmptyCommand(myGame.GetPlayer()));
                myGame.GetPlayer().SlotB();
            }
            else if (state.DPad.Up.Equals(ButtonState.Pressed))
            {
                myGame.GetPlayer().MoveUp();
            }
            else if(state.DPad.Down.Equals(ButtonState.Pressed))
            {
                myGame.GetPlayer().MoveDown();
            }
            else if (state.DPad.Left.Equals(ButtonState.Pressed))
            {
                myGame.GetPlayer().MoveLeft();
            }
            else if (state.DPad.Right.Equals(ButtonState.Pressed))
            {
                myGame.GetPlayer().MoveRight();
            }
            else
            {
                myGame.GetPlayer().Stop();
            }

            if(delay > 0)
            {
                delay--;
            }

       */}
       
    }
}

