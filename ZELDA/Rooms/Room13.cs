﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game1
{
    public class Room13 : AbstractRoom
    {
        public Room13(Game1 game, Border border, GraphicsDeviceManager graphics) : base(game, border, graphics)
        {
            entityLoader = new Room13EntitiesLoadCommand(enemies, items, collidables, blocks, game.GetHUD().GetHeight());
            this.backgroundSrcRec = new Rectangle(258, 1, 256, 176);
            entityLoader.Execute();
        }

        public override void ResetCamera()
        {
            this.backgroundSrcRec = new Rectangle(258, 1, 256, 176);
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
            transitionHandler = new RoomTransitionCommand(this, 12, 3, game, border, graphics);
            game.GetPlayer().GetInventory().CurrentRoom = 12;
        }

    }
}