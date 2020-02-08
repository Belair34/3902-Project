﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1.PlayerStates
{
    class PStateMovingRight : IPlayerState
    {
        ISprite sprite;
        IPlayer player;
        public PStateMovingRight(IPlayer player)
        {
            this.player = player;
            this.sprite = SpriteFactory.Instance.GetLinkMovingRight(player);
        }
        public void MoveUp()
        {
            player.SetState(new PStateMovingUp(player));
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
            
        }

        public void SlotA()
        {

        }

        public void SlotB()
        {

        }

        public void Stop()
        {
            player.SetState(new PStateIdleRight(player));
        }

        public void Update()
        {
            sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }

    }
}
