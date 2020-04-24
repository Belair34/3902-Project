using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using Game1.Projectiles;
using System.Collections.Generic;

namespace Game1
{
    public class ClockItem : AbstractItem, IItem
    {
        public ClockItem(int x, int y, GraphicsDevice window) : base(x, y)
        {
            /*Changeable*/
            base.Size = 3;

            base.position = new Vector2();
            base.position.X = x;
            base.position.Y = y;
            base.sprite = SpriteFactoryItems.Instance.GetClock(this);
        }

        public override void PlayerCollision(ICollidable collidable)
        {
            //freeze all enemies on a cooldown timer. How to do this?
            Consume();
        }
    }
}