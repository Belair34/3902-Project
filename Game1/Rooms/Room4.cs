using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game1
{
    public class Room4 : AbstractRoom
    {
        public Room4(Game1 game, Border border, GraphicsDeviceManager graphics, int spawnDoor) : base(game, border, graphics, spawnDoor)
        {
            entityLoader = new Room4EntitiesLoadCommand(enemies, items, collidables, blocks);
            this.backgroundSrcRec = new Rectangle(515, 709, 256, 176);
            this.backgroundDestRec = new Rectangle(0, 0, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height);
            border.SetLeftOpen(false);
            border.SetRightOpen(false);
            border.SetTopOpen(true);
            border.SetTopOpen(true);
            entityLoader.Execute();
        }

        public override void TransitionUp()
        {
            Transitioning = true;
            transitionHandler = new RoomTransitionCommand(this, new Room4(game, border, graphics, 1), 0, game, border, graphics);
        }

        public override void TransitionDown()
        {
            Transitioning = true;
            transitionHandler = new RoomTransitionCommand(this, new Room1(game, border, graphics, 0), 1, game, border, graphics);
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
