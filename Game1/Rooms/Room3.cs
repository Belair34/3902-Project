using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game1
{
    public class Room3 : AbstractRoom
    {
        public Room3(Game1 game, Border border, GraphicsDeviceManager graphics, int spawnDoor) : base(game, border, graphics, spawnDoor)
        {
            entityLoader = new Room3EntitiesLoadCommand(enemies, items, collidables, blocks);
            this.backgroundSrcRec = new Rectangle(772, 886, 256, 176);
            this.backgroundDestRec = new Rectangle(0, 0, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height);
            border.SetLeftOpen(true);
            border.SetRightOpen(false);
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
            //Nothing here, this would exit dungeon
        }

        public override void TransitionLeft()
        {
            Transitioning = true;
            //Replace second parameter when room is made
            transitionHandler = new RoomTransitionCommand(this, new Room1(game, border, graphics, 3), 2, game, border, graphics);
        }

        public override void TransitionRight()
        {
            
        }

    }
}
