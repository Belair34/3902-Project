using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using Game1.Projectiles;
using System.Collections.Generic;

namespace Game1
{
    public class MapItem : AbstractItem, IItem
    {
        public MapItem(int x, int y, GraphicsDevice window)
        {
            /*Changeable*/
            base.Size = 3;

            base.position = new Vector2();
            base.position.X = x;
            base.position.Y = y;
            base.sprite = SpriteFactoryItems.Instance.GetMap(this);

            base.boundary = new Vector2();
            base.boundary.X = window.Viewport.Width;
            base.boundary.Y = window.Viewport.Height;          /*Items*/
        }

        public void PlayerCollision(ICollidable collidable)
        {
            ((IPlayer)collidable).GetInventory().HaveMap = 1;
        }
    }
}