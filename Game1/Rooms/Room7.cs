using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game1
{
    public class Room7 : AbstractRoom
    {
        public Room7(Game1 game, Border border, GraphicsDeviceManager graphics) : base(game, border, graphics)
        {
            entityLoader = new Room7EntitiesLoadCommand(enemies, items, collidables, blocks, game.GetHUD().GetHeight());
            this.backgroundSrcRec = new Rectangle(772, 532, 256, 176);
            entityLoader.Execute();
        }

        public override void ResetCamera()
        {
            this.backgroundSrcRec = new Rectangle(772, 532, 256, 176);
        }
        public override void SetBorders()
        {
            border.SetLeftOpen(true);
            border.SetRightOpen(false);
            border.SetTopOpen(true);
            border.SetBottomOpen(false);
        }
        public override void TransitionUp()
        {
            Transitioning = true;
            //Second parameter is should be replaced by the room above Room1 when it's made. This is just for demonstration.
            transitionHandler = new RoomTransitionCommand(this, 15, 0, game, border, graphics);
        }

        public override void TransitionDown()
        {
            //nothing
        }

        public override void TransitionLeft()
        {
            Transitioning = true;
            //Replace second parameter when room is made
            transitionHandler = new RoomTransitionCommand(this, 5, 2, game, border, graphics);
        }

        public override void TransitionRight()
        {
            //nothing
        }

    }
}
