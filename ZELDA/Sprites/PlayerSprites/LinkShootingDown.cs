using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using Game1.Projectiles;

namespace Game1.PlayerSprites
{
    class LinkShootingDown : ISprite
    {
        Texture2D texture;
        IPlayer player;
        IProjectile projectile;
        int linkSrcWidth = 15;
        int linkSrcHeight = 16;
        int linkDestWidth = 15;
        int linkDestHeight = 16;
        int linkSrcX = 0; /*Change this*/
        int linkSrcY = 60;  /*and this*/
        int curFrame = 1;
        int totalFrames = 5; /*Maybe this*/
        int delay = 0;
        int coolDown = 20;

        public LinkShootingDown(IPlayer player, Texture2D texture, IProjectile projectile)
        {
            this.texture = texture;
            this.player = player;
            this.linkDestWidth *= player.Size;
            this.linkDestHeight *= player.Size;
            this.projectile = projectile;
        }
        public void Update()
        {
            delay++;
            if (delay == 3) /*Delay of frame changes*/
            {
                delay = 0;
                curFrame++;
                if (curFrame == 3)
                {
                    foreach (IProjectile projectile in player.GetProjectiles())
                    {
                        if(projectile == this.projectile)
                        {
                            projectile.Shoot();
                        }
                    }
                }
                if (curFrame > totalFrames)
                {
                    player.SetState(new PStateIdleDown(player,coolDown));
                }
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle linkDestRec = new Rectangle((int)player.GetPosition().X, (int)player.GetPosition().Y, linkDestWidth, linkDestHeight);
            Rectangle linkSrcRec = new Rectangle(linkSrcX, linkSrcY, linkSrcWidth, linkSrcHeight);
            spriteBatch.Begin();
            spriteBatch.Draw(texture, linkDestRec, linkSrcRec, Color.White);
            spriteBatch.End();
        }
    }
}
