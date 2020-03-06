using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game1
{
    public class Room1 : AbstractRoom
    {
        public Room1(Game1 game, Border border, GraphicsDeviceManager graphics, int spawnDoor) : base(game, border, graphics, spawnDoor)
        {
            entityLoader = new Room1EntitiesLoadCommand(enemies, items, collidables);
            this.backgroundSrcRec = new Rectangle(515, 886, 256, 176);
            this.backgroundDestRec = new Rectangle(0, 0, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height);
            border.SetLeftOpen(true);
            border.SetRightOpen(true);
            border.SetTopOpen(true);
            entityLoader.Execute();
        }

        public override void TransitionUp()
        {
            Transitioning = true;
            //Second parameter is should be replaced by the room above Room1 when it's made. This is just for demonstration.
            transitionHandler = new RoomTransitionCommand(this, new Room1(game, border, graphics, 1), 0, border, graphics, game);
        }

        public override void TransitionDown()
        {
            //Nothing here, this would exit dungeon
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
