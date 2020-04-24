using Microsoft.Xna.Framework;

namespace Game1
{
    public class BoomerangItem : AbstractItem, IItem
    {

        public BoomerangItem(int x, int y) : base(x, y)
        {
            /*Changeable*/
            base.Size = 4;

            base.position = new Vector2();
            base.position.X = x;
            base.position.Y = y;
            base.sprite = SpriteFactoryItems.Instance.GetBoomerang(this);
        }

        public override void PlayerCollision(ICollidable collidable)
        {
            ((IPlayer)collidable).GetInventory().HaveWoodRang = 1;
            Consume();
        }
    }
}