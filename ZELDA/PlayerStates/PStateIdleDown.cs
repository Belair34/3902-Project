using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.Projectiles;

namespace Game1.PlayerStates
{
    class PStateIdleDown : IPlayerState
    {
        ISprite sprite;
        IPlayer player;
        int coolDown;
        public PStateIdleDown(IPlayer player, int coolDown = 0)
        {
            this.player = player;
            this.sprite = SpriteFactory.Instance.GetLinkIdleDown(player);
            this.coolDown = coolDown;
        }
        public void MoveUp()
        {
           player.SetState(new PStateMovingUp(player, coolDown));
        }

        public void MoveDown()
        {
            player.SetState(new PStateMovingDown(player, coolDown));
        }
        public void MoveLeft()
        {
            player.SetState(new PStateMovingLeft(player, coolDown));
        }

        public void MoveRight()
        {
            player.SetState(new PStateMovingRight(player, coolDown));
        }

        public void SlotA()
        {
            if (coolDown <= 0)
            {
                player.SetState(new PStateStabbingDown(player));
            }
        }

        public void SlotB()
        {
            if (coolDown <= 0)
            {
                player.GetInventory().GetSlotBCommand().Execute();
            }
        }

        public void Stop()
        {

        }

        public void Update()
        {
            if (coolDown > 0)
            {
                coolDown--;
            }
            sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }

    }
}
