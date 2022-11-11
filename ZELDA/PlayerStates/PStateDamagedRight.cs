using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1.PlayerStates
{
    class PStateDamagedRight: IPlayerState
    {
        ISprite sprite;
        IPlayer player;
        int coolDown;
        private int moveSpeed;
        public PStateDamagedRight(IPlayer player, int coolDown = 0)
        {
            this.player = player;
            moveSpeed = player.Speed;
            this.sprite = SpriteFactory.Instance.GetLinkDamagedRight(player);
            this.coolDown = coolDown;
        }
        public void MoveUp()
        {
            if (coolDown <= 0)
            {
                player.SetState(new PStateMovingUp(player, coolDown));
            }
        }

        public void MoveDown()
        {
            if (coolDown <= 0)
            {
                player.SetState(new PStateMovingDown(player, coolDown));
            }
        }
        public void MoveLeft()
        {
            if (coolDown <= 0)
            {
                player.SetState(new PStateMovingLeft(player, coolDown));
            }
        }

        public void MoveRight()
        {
            if (coolDown <= 0)
            {
                player.SetState(new PStateMovingRight(player, coolDown));
                
            }
        }

        public void SlotA()
        {
            if (coolDown <= 0)
            {
                player.SetState(new PStateStabbingRight(player));
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
            if (coolDown <= 0)
            {
                player.SetState(new PStateIdleRight(player));
            }
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
