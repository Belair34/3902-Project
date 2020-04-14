using Microsoft.Xna.Framework;

namespace Game1
{
    public class HeartItem : AbstractItem, IItem
    {

        public HeartItem(int x, int y)
        {
            /*Changeable*/
            this.Size = 3;

            base.position = new Vector2();
            base.position.X = x;
            base.position.Y = y;
            base.sprite = SpriteFactoryItems.Instance.GetHeart(this);
        }

        public override void PlayerCollision(ICollidable collidable)
        {
            IPlayer player = (IPlayer)collidable;
            IInventory inventory = player.GetInventory();
            if (inventory.Health < inventory.MaxHealth)
            {
                inventory.Health += 2;
            }
        }
    }
}