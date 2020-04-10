using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game1
{
    public class Room17 : AbstractRoom
    {
        public Room17(Game1 game, Border border, GraphicsDeviceManager graphics, int spawnDoor) : base(game, border, graphics, spawnDoor)
        {
            entityLoader = new Room17EntitiesLoadCommand(enemies, items, collidables, blocks, game.GetHUD().GetHeight());
            this.backgroundSrcRec = new Rectangle(1029, 178, 256, 176);
            border.SetLeftOpen(false);
            border.SetRightOpen(true);
            border.SetTopOpen(false);
            border.SetBottomOpen(true);
            entityLoader.Execute();
        }

        public override void TransitionUp()
        {
           //nothing
        }

        public override void TransitionDown()
        {
            Transitioning = true;
            //Second parameter is should be replaced by the room above Room1 when it's made. This is just for demonstration.
            transitionHandler = new RoomTransitionCommand(this, new Room16(game, border, graphics, 0), 1, game, border, graphics);
        }

        public override void TransitionLeft()
        {
            //nothing
        }

        public override void TransitionRight()
        {
            Transitioning = true;
            //Replace second parameter when room is made
            transitionHandler = new RoomTransitionCommand(this, new Room18(game, border, graphics, 2), 3, game, border, graphics);
        }

    }
}
