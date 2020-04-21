using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game1
{
    public class Room11 : AbstractRoom
    {
        public Room11(Game1 game, Border border, GraphicsDeviceManager graphics, int spawnDoor) : base(game, border, graphics, spawnDoor)
        {
            entityLoader = new Room11EntitiesLoadCommand(enemies, items, collidables, waters, game.GetHUD().GetHeight());
            this.backgroundSrcRec = new Rectangle(515, 178, 256, 176);
            border.SetLeftOpen(false);
            border.SetRightOpen(false);
            border.SetTopOpen(true);
            border.SetBottomOpen(true);
            entityLoader.Execute();
        }

        public override void TransitionUp()
        {
            Transitioning = true;
            //Second parameter is should be replaced by the room above Room1 when it's made. This is just for demonstration.
            transitionHandler = new RoomTransitionCommand(this, new Room12(game, border, graphics, 1), 0, game, border, graphics);
        }

        public override void TransitionDown()
        {
            Transitioning = true;
            //Second parameter is should be replaced by the room above Room1 when it's made. This is just for demonstration.
            transitionHandler = new RoomTransitionCommand(this, new Room8(game, border, graphics, 0), 1, game, border, graphics);
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
