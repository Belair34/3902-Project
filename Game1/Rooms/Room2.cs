using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game1
{
    public class Room2 : AbstractRoom
    {
        public Room2(Game1 game, Border border, GraphicsDeviceManager graphics) : base(game, border, graphics)
        {
            entityLoader = new Room2EntitiesLoadCommand(enemies, items, collidables, blocks, game.GetHUD().GetHeight());
            this.backgroundSrcRec = new Rectangle(258, 886, 256, 176);
            entityLoader.Execute();
        }

        public override void ResetCamera()
        {
            this.backgroundSrcRec = new Rectangle(258, 886, 256, 176);
        }
        public override void SetBorders()
        {
            border.SetLeftOpen(false);
            border.SetRightOpen(true);
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
            //nothing
        }

        public override void TransitionRight()
        {
            Transitioning = true;
            //Replace second parameter when room is made
            transitionHandler = new RoomTransitionCommand(this, 1, 3, game, border, graphics);
        }

    }
}
