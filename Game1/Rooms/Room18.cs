using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game1
{
    public class Room18 : AbstractRoom
    {
        public Room18(Game1 game, Border border, GraphicsDeviceManager graphics) : base(game, border, graphics)
        {
            entityLoader = new Room18EntitiesLoadCommand(enemies, items, collidables, blocks, game.GetHUD().GetHeight());
            this.backgroundSrcRec = new Rectangle(1286, 178, 256, 176);
            entityLoader.Execute();
        }

        public override void ResetCamera()
        {
            this.backgroundSrcRec = new Rectangle(1286, 178, 256, 176);
        }

        public override void SetBorders()
        {
            border.SetLeftOpen(true);
            border.SetRightOpen(false);
            border.SetTopOpen(false);
            border.SetBottomOpen(false);
        }
        public override void TransitionUp()
        {
           //nothing
        }

        public override void TransitionDown()
        {
            //nothing
        }

        public override void TransitionLeft()
        {
            Transitioning = true;
            //Replace second parameter when room is made
            transitionHandler = new RoomTransitionCommand(this, 17, 2, game, border, graphics);
            game.GetPlayer().GetInventory().CurrentRoom = 17;
        }

        public override void TransitionRight()
        {
            //nothing
        }

    }
}
