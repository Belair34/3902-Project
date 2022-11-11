using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game1
{
    public class Room1 : AbstractRoom
    {
        public Room1(Game1 game, Border border, GraphicsDeviceManager graphics) : base(game, border, graphics)
        {
            entityLoader = new Room1EntitiesLoadCommand(enemies, items, collidables, blocks, game.GetHUD().GetHeight());
            this.backgroundSrcRec = new Rectangle(515, 886, 256, 176);
            entityLoader.Execute();
        }

        public override void ResetCamera()
        {
            this.backgroundSrcRec = new Rectangle(515, 886, 256, 176);
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
            transitionHandler = new RoomTransitionCommand(this, 4, 0, game, border, graphics);
            game.GetPlayer().GetInventory().CurrentRoom = 4;
        }

        public override void TransitionDown()
        {
            game.Exit();
        }

        public override void TransitionLeft()
        {
            Transitioning = true;
            transitionHandler = new RoomTransitionCommand(this, 2, 2, game, border, graphics);
            game.GetPlayer().GetInventory().CurrentRoom = 2;
        }

        public override void TransitionRight()
        {
            Transitioning = true;
            transitionHandler = new RoomTransitionCommand(this, 3, 3, game, border, graphics);
            game.GetPlayer().GetInventory().CurrentRoom = 3;
        }

    }
}
