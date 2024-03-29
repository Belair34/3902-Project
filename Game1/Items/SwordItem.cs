﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using Game1.Projectiles;
using System.Collections.Generic;

namespace Game1
{
    public class SwordItem : AbstractItem, IItem
    {

        public SwordItem(int x, int y, GraphicsDevice window) : base(x, y)
        {
            /*Changeable*/
            base.Size = 3;

            base.position = new Vector2();
            base.position.X = x;
            base.position.Y = y;
            base.sprite = SpriteFactoryItems.Instance.GetSword(this);
        }

        public override void PlayerCollision(ICollidable collidable)
        {
            ((IPlayer)collidable).GetInventory().HaveSword = 1;
            Consume();
        }
    }
}