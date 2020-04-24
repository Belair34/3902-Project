using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game1
{
    public class Room5 : AbstractRoom
    {
        public Room5(Game1 game, Border border, GraphicsDeviceManager graphics) : base(game, border, graphics)
        {
            entityLoader = new Room5EntitiesLoadCommand(enemies, items, collidables, blocks, game.GetHUD().GetHeight());
            this.backgroundSrcRec = new Rectangle(515, 532, 256, 176);
            entityLoader.Execute();
        }
        public override void ResetCamera()
        {
            this.backgroundSrcRec = new Rectangle(515, 532, 256, 176);
        }

        public override void SetBorders()
        {
            border.SetLeftOpen(true);
            border.SetRightOpen(true);
            border.SetTopOpen(true);
            border.SetBottomOpen(true);
        }

        public override void TransitionUp()
        {
            Transitioning = true;
            //Second parameter is should be replaced by the room above Room1 when it's made. This is just for demonstration.
            transitionHandler = new RoomTransitionCommand(this, 8, 0, game, border, graphics);
        }

        public override void TransitionDown()
        {
            Transitioning = true;
            //Second parameter is should be replaced by the room above Room1 when it's made. This is just for demonstration.
            transitionHandler = new RoomTransitionCommand(this, 4, 1, game, border, graphics);
        }

        public override void TransitionLeft()
        {
            Transitioning = true;
            //Replace second parameter when room is made
            transitionHandler = new RoomTransitionCommand(this, 6, 2, game, border, graphics);
        }

        public override void TransitionRight()
        {
            Transitioning = true;
            //Replace second parameter when room is made
            transitionHandler = new RoomTransitionCommand(this, 7, 3, game, border, graphics);
        }

    }
}
