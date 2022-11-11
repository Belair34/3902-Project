using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.Projectiles;

namespace Game1.PlayerStates
{
    class PStateMovingUp : IPlayerState
    {
        ISprite sprite;
        IPlayer player;
        int coolDown;
        public PStateMovingUp(IPlayer player, int coolDown = 0)
        {
            this.player = player;
            this.sprite = SpriteFactory.Instance.GetLinkMovingUp(player);
            this.coolDown = coolDown;

        }
        public void MoveUp()
        {
           
        }

        public void MoveDown()
        {
            player.SetState(new PStateMovingDown(player));
        }
        public void MoveLeft()
        {
            player.SetState(new PStateMovingLeft(player));
        }

        public void MoveRight()
        {
            player.SetState(new PStateMovingRight(player));
        }

        public void SlotA()
        {
            if (coolDown <= 0)
            {
                player.SetState(new PStateStabbingUp(player));
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
            player.SetState(new PStateIdleUp(player));
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
