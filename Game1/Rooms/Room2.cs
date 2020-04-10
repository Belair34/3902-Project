using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game1
{
    public class Room2 : AbstractRoom
    {
        public Room2(Game1 game, Border border, GraphicsDeviceManager graphics, int spawnDoor) : base(game, border, graphics, spawnDoor)
        {
            entityLoader = new Room2EntitiesLoadCommand(enemies, items, collidables, blocks, game.GetHUD().GetHeight());
            this.backgroundSrcRec = new Rectangle(258, 886, 256, 176);
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
            transitionHandler = new RoomTransitionCommand(this, new Room1(game, border, graphics, 2), 3, game, border, graphics);
        }

    }
}
