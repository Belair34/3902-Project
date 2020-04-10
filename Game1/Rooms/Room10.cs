using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game1
{
    public class Room10 : AbstractRoom
    {
        public Room10(Game1 game, Border border, GraphicsDeviceManager graphics, int spawnDoor) : base(game, border, graphics, spawnDoor)
        {
            entityLoader = new Room10EntitiesLoadCommand(enemies, items, collidables, blocks, game.GetHUD().GetHeight());
            this.backgroundSrcRec = new Rectangle(1, 355, 256, 176);
            border.SetLeftOpen(false);
            border.SetRightOpen(true);
            border.SetTopOpen(false);
            border.SetBottomOpen(false);
            entityLoader.Execute();
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
          //nothing
        }

        public override void TransitionRight()
        {
            Transitioning = true;
            //Replace second parameter when room is made
            transitionHandler = new RoomTransitionCommand(this, new Room9(game, border, graphics, 2), 3, game, border, graphics);
        }

    }
}
