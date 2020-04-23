using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1.PlayerStates
{
    class PStateDead : IPlayerState
    {
        ISprite playerSprite;
        //ISprite TextSprite;
        IPlayer player;
        int coolDown;
        public PStateDead(IPlayer player, int coolDown = 0)
        {
            this.player = player;
            playerSprite = SpriteFactory.Instance.GetLinkDead(player);
            //TextSprite = SpriteFactory.Instance.GetGameOver();
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
            playerSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            playerSprite.Draw(spriteBatch);
        }

    }
}
