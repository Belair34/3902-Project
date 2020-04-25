using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game1
{
    public class Room3 : AbstractRoom
    {
        public Room3(Game1 game, Border border, GraphicsDeviceManager graphics) : base(game, border, graphics)
        {
            entityLoader = new Room3EntitiesLoadCommand(enemies, items, collidables, blocks, game.GetHUD().GetHeight());
            this.backgroundSrcRec = new Rectangle(772, 886, 256, 176);
            entityLoader.Execute();
        }
        public override void ResetCamera()
        {
            this.backgroundSrcRec = new Rectangle(772, 886, 256, 176);
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
            //Nothing here, this would exit dungeon
        }

        public override void TransitionLeft()
        {
            Transitioning = true;
            //Replace second parameter when room is made
            transitionHandler = new RoomTransitionCommand(this, 1, 2, game, border, graphics);
            game.GetPlayer().GetInventory().CurrentRoom = 1;
        }

        public override void TransitionRight()
        {
            
        }

    }
}
