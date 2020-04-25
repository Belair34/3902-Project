using Microsoft.Xna.Framework;
using Game1.Sound;

namespace Game1
{
    public class HeartItem : AbstractItem, IItem
    {

        public HeartItem(int x, int y) : base(x, y)
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
                ZeldaSound.Instance.PickupHeart();
                inventory.Health += 2;
                if(inventory.Health > inventory.MaxHealth)
                {
                    inventory.Health = inventory.MaxHealth;
                }
                Consume();
            }
        }
    }
}