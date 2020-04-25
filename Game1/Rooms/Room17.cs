using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game1
{
    public class Room17 : AbstractRoom
    {
        public Room17(Game1 game, Border border, GraphicsDeviceManager graphics) : base(game, border, graphics)
        {
            entityLoader = new Room17EntitiesLoadCommand(enemies, items, collidables, blocks, game, game.GetHUD().GetHeight());
            this.backgroundSrcRec = new Rectangle(1029, 178, 256, 176);
            entityLoader.Execute();
        }

        public override void ResetCamera()
        {
            this.backgroundSrcRec = new Rectangle(1029, 178, 256, 176);
        }

        public override void SetBorders()
        {
            border.SetLeftOpen(false);
            border.SetRightOpen(true);
            border.SetTopOpen(false);
            border.SetBottomOpen(true);
        }
        public override void TransitionUp()
        {
           //nothing
        }

        public override void TransitionDown()
        {
            Transitioning = true;
            //Second parameter is should be replaced by the room above Room1 when it's made. This is just for demonstration.
            transitionHandler = new RoomTransitionCommand(this, 16, 1, game, border, graphics);
        }

        public override void TransitionLeft()
        {
            //nothing
        }

        public override void TransitionRight()
        {
            Transitioning = true;
            //Replace second parameter when room is made
            transitionHandler = new RoomTransitionCommand(this, 18, 3, game, border, graphics);
        }

    }
}
