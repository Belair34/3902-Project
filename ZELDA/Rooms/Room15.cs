using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game1
{
    public class Room15 : AbstractRoom
    {
        public Room15(Game1 game, Border border, GraphicsDeviceManager graphics) : base(game, border, graphics)
        {
            entityLoader = new Room15EntitiesLoadCommand(enemies, items, collidables, blocks, game.GetHUD().GetHeight());
            this.backgroundSrcRec = new Rectangle(772, 355, 256, 176);
            entityLoader.Execute();
        }

        public override void ResetCamera()
        {
            this.backgroundSrcRec = new Rectangle(772, 355, 256, 176);
        }
        public override void SetBorders()
        {
            border.SetLeftOpen(true);
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
            transitionHandler = new RoomTransitionCommand(this, 7, 1, game, border, graphics);
            game.GetPlayer().GetInventory().CurrentRoom = 7;
        }

        public override void TransitionLeft()
        {
            Transitioning = true;
            //Replace second parameter when room is made
            transitionHandler = new RoomTransitionCommand(this, 8, 2, game, border, graphics);
            game.GetPlayer().GetInventory().CurrentRoom = 8;
        }

        public override void TransitionRight()
        {
            Transitioning = true;
            //Replace second parameter when room is made
            transitionHandler = new RoomTransitionCommand(this, 16, 3, game, border, graphics);
            game.GetPlayer().GetInventory().CurrentRoom = 16;
        }

    }
}
