using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game1
{
    public class Room12 : AbstractRoom
    {
        public Room12(Game1 game, Border border, GraphicsDeviceManager graphics) : base(game, border, graphics)
        {
            entityLoader = new Room12EntitiesLoadCommand(enemies, items, collidables, waters, game.GetHUD().GetHeight());
            this.backgroundSrcRec = new Rectangle(515, 1, 256, 176);
            entityLoader.Execute();
        }

        public override void ResetCamera()
        {
            this.backgroundSrcRec = new Rectangle(515, 1, 256, 176);
        }
        public override void SetBorders()
        {
            border.SetLeftOpen(true);
            border.SetRightOpen(false);
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
            transitionHandler = new RoomTransitionCommand(this, 11, 1, game, border, graphics);
        }

        public override void TransitionLeft()
        {
            Transitioning = true;
            //Replace second parameter when room is made
            transitionHandler = new RoomTransitionCommand(this, 13, 2, game, border, graphics);
        }

        public override void TransitionRight()
        {
           //nothing
        }

    }
}
