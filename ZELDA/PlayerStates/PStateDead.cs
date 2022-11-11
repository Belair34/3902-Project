using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1.PlayerStates
{
    class PStateDead : IPlayerState
    {
        ISprite playerSprite;
        Game1 game;
        IPlayer player;
        int coolDown;
        public PStateDead(Game1 game, IPlayer player, int coolDown = 0)
        {
            this.game = game;
            this.player = player;
            playerSprite = SpriteFactory.Instance.GetLinkDead(player);
            this.coolDown = coolDown;
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
            if (coolDown > 0)
            {
                coolDown--;
            }
            else if(coolDown <= 0)
            {
                game.SetState(1);
            }
            playerSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            playerSprite.Draw(spriteBatch);
        }

    }
}
