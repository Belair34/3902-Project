using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game1
{
    public class Room4 : AbstractRoom
    {
        public Room4(Game1 game, Border border, GraphicsDeviceManager graphics) : base(game, border, graphics)
        {
            entityLoader = new Room4EntitiesLoadCommand(enemies, items, collidables, blocks, game.GetHUD().GetHeight());
            this.backgroundSrcRec = new Rectangle(515, 709, 256, 176);
            entityLoader.Execute();
        }

        public override void ResetCamera()
        {
            this.backgroundSrcRec = new Rectangle(515, 709, 256, 176);
        }
        public override void SetBorders()
        {
            border.SetLeftOpen(false);
            border.SetRightOpen(false);
            border.SetTopOpen(true);
            border.SetTopOpen(true);
        }

        public override void TransitionUp()
        {
            Transitioning = true;
            transitionHandler = new RoomTransitionCommand(this, 5, 0, game, border, graphics);
        }

        public override void TransitionDown()
        {
            Transitioning = true;
            transitionHandler = new RoomTransitionCommand(this, 1, 1, game, border, graphics);
        }

        public override void TransitionLeft()
        {
           //Fill in once left room is made
        }

        public override void TransitionRight()
        {
            //Fill in once right room is made
        }

    }
}
