using Microsoft.Xna.Framework;

namespace Game1
{
    public class TriangleItem : AbstractItem, IItem
    {
        public TriangleItem(int x, int y)
        {
            /*Changeable*/
            base.Size = 3;

            base.position = new Vector2();
            base.position.X = x;
            base.position.Y = y;
            base.sprite = SpriteFactoryItems.Instance.GetTriangle(this);
        }

        public override void PlayerCollision(ICollidable collidable)
        {
            ((IPlayer)collidable).GetInventory().Keys++;
        }
    }
}