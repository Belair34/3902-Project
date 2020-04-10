using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game1
{
    public class Room7 : AbstractRoom
    {
        public Room7(Game1 game, Border border, GraphicsDeviceManager graphics, int spawnDoor) : base(game, border, graphics, spawnDoor)
        {
            entityLoader = new Room7EntitiesLoadCommand(enemies, items, collidables, blocks, game.GetHUD().GetHeight());
            this.backgroundSrcRec = new Rectangle(772, 532, 256, 176);
            border.SetLeftOpen(true);
            border.SetRightOpen(false);
            border.SetTopOpen(true);
            border.SetBottomOpen(false);
            entityLoader.Execute();
        }

        public override void TransitionUp()
        {
            Transitioning = true;
            //Second parameter is should be replaced by the room above Room1 when it's made. This is just for demonstration.
            transitionHandler = new RoomTransitionCommand(this, new Room15(game, border, graphics, 1), 0, game, border, graphics);
        }

        public override void TransitionDown()
        {
            //nothing
        }

        public override void TransitionLeft()
        {
            Transitioning = true;
            //Replace second parameter when room is made
            transitionHandler = new RoomTransitionCommand(this, new Room5(game, border, graphics, 3), 2, game, border, graphics);
        }

        public override void TransitionRight()
        {
            //nothing
        }

    }
}
