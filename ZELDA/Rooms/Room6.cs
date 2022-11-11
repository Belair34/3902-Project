using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game1
{
    public class Room6 : AbstractRoom
    {
        public Room6(Game1 game, Border border, GraphicsDeviceManager graphics) : base(game, border, graphics)
        {
            entityLoader = new Room6EntitiesLoadCommand(enemies, items, collidables, blocks, game.GetHUD().GetHeight());
            this.backgroundSrcRec = new Rectangle(258, 532, 256, 176);
            entityLoader.Execute();
        }

        public override void ResetCamera()
        {
            this.backgroundSrcRec = new Rectangle(258, 532, 256, 176);
        }

        public override void SetBorders()
        {
            border.SetLeftOpen(false);
            border.SetRightOpen(true);
            border.SetTopOpen(true);
            border.SetBottomOpen(false);
        }

        public override void TransitionUp()
        {
            Transitioning = true;
            //Second parameter is should be replaced by the room above Room1 when it's made. This is just for demonstration.
            transitionHandler = new RoomTransitionCommand(this, 9, 0, game, border, graphics);
            game.GetPlayer().GetInventory().CurrentRoom = 9;
        }

        public override void TransitionDown()
        {
            //nothing
        }

        public override void TransitionLeft()
        {
           //nothing
        }

        public override void TransitionRight()
        {
            Transitioning = true;
            //Replace second parameter when room is made
            transitionHandler = new RoomTransitionCommand(this, 5, 3, game, border, graphics);
            game.GetPlayer().GetInventory().CurrentRoom = 5;
        }

    }
}
