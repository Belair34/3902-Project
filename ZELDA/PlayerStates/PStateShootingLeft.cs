using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1.PlayerStates
{
    class PStateShootingLeft : IPlayerState
    {
        ISprite sprite;
        IPlayer player;
        public PStateShootingLeft(IPlayer player, IProjectile projectile)
        {
            this.player = player;
            this.sprite = SpriteFactory.Instance.GetLinkShootingLeft(player, projectile);
            player.GetProjectiles().Add(projectile);

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
