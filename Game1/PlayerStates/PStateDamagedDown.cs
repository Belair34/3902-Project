﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1.PlayerStates
{
    class PStateDamagedDown : IPlayerState
    {
        ISprite sprite;
        IPlayer player;
        public PStateDamagedDown(IPlayer player)
        {
            this.player = player;
            this.sprite = SpriteFactory.Instance.GetLinkDamagedDown(player);
        }
        public void MoveUp()
        {
           
        }

        public void MoveDown()
        {

        }
        public void MoveLeft()
        {

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
