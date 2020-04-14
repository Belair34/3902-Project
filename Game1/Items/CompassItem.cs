using Microsoft.Xna.Framework;
namespace Game1
{
    public class CompassItem : AbstractItem, IItem
    {
        public CompassItem(int x, int y)
        {
            /*Changeable*/
            base.Size = 3;

            base.position = new Vector2();
            base.position.X = x;
            base.position.Y = y;
            base.sprite = SpriteFactoryItems.Instance.GetCompass(this);
        }

        public override void PlayerCollision(ICollidable collidable)
        {
            //((IPlayer)collidable).GetInventory().Keys++;
        }
    }
}