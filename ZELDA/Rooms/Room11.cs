using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game1
{
    public class Room11 : AbstractRoom
    {
        public Room11(Game1 game, Border border, GraphicsDeviceManager graphics) : base(game, border, graphics)
        {
            entityLoader = new Room11EntitiesLoadCommand(enemies, items, collidables, waters, game.GetHUD().GetHeight());
            this.backgroundSrcRec = new Rectangle(515, 178, 256, 176);
            entityLoader.Execute();
        }

        public override void ResetCamera()
        {
            this.backgroundSrcRec = new Rectangle(515, 178, 256, 176);
        }
        public override void SetBorders()
        {
            border.SetLeftOpen(false);
            border.SetRightOpen(false);
            border.SetTopOpen(true);
            border.SetBottomOpen(true);
        }

        public override void TransitionUp()
        {
            Transitioning = true;
            //Second parameter is should be replaced by the room above Room1 when it's made. This is just for demonstration.
            transitionHandler = new RoomTransitionCommand(this, 12, 0, game, border, graphics);
            game.GetPlayer().GetInventory().CurrentRoom = 12;
        }

        public override void TransitionDown()
        {
            Transitioning = true;
            //Second parameter is should be replaced by the room above Room1 when it's made. This is just for demonstration.
            transitionHandler = new RoomTransitionCommand(this, 8, 1, game, border, graphics);
            game.GetPlayer().GetInventory().CurrentRoom = 8;
        }

        public override void TransitionLeft()
        {
           //nothing
        }

        public override void TransitionRight()
        {
           //nothing
        }

    }
}
