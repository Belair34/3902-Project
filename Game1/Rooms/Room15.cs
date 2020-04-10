using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game1
{
    public class Room15 : AbstractRoom
    {
        public Room15(Game1 game, Border border, GraphicsDeviceManager graphics, int spawnDoor) : base(game, border, graphics, spawnDoor)
        {
            entityLoader = new Room15EntitiesLoadCommand(enemies, items, collidables, blocks, game.GetHUD().GetHeight());
            this.backgroundSrcRec = new Rectangle(772, 355, 256, 176);
            border.SetLeftOpen(true);
            border.SetRightOpen(true);
            border.SetTopOpen(false);
            border.SetBottomOpen(true);
            entityLoader.Execute();
        }

        public override void TransitionUp()
        {
           //nothing
        }

        public override void TransitionDown()
        {
            Transitioning = true;
            //Second parameter is should be replaced by the room above Room1 when it's made. This is just for demonstration.
            transitionHandler = new RoomTransitionCommand(this, new Room7(game, border, graphics, 0), 1, game, border, graphics);
        }

        public override void TransitionLeft()
        {
            Transitioning = true;
            //Replace second parameter when room is made
            transitionHandler = new RoomTransitionCommand(this, new Room8(game, border, graphics, 3), 2, game, border, graphics);
        }

        public override void TransitionRight()
        {
            Transitioning = true;
            //Replace second parameter when room is made
            transitionHandler = new RoomTransitionCommand(this, new Room16(game, border, graphics, 2), 3, game, border, graphics);
        }

    }
}
