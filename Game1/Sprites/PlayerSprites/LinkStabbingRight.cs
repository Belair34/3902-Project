using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;

namespace Game1.PlayerSprites
{
    class LinkStabbingRight : ISprite
    {
        Texture2D texture;
        IPlayer player;
        IProjectile sword;
        int linkSrcWidth = 15;
        int linkSrcHeight = 16;
        int swordSrcWidth = 16;
        int swordSrcHeight = 12;
        int linkDestWidth = 15;
        int linkDestHeight = 16;
        int swordDestWidth = 16;
        int swordDestHeight = 12;
        int linkSrcX = 90; /*Change this*/
        int linkSrcY = 60;  /*and this*/
        int swordSrcX = 90;
        int swordSrcY = 194;
        int swordOffset = 11;
        int curFrame = 1;
        int totalFrames = 5; /*Maybe this*/
        int delay = 0;
        int coolDown = 20;

        public LinkStabbingRight(IPlayer player, Texture2D texture)
        {
            this.texture = texture;
            this.player = player;
            this.linkDestWidth *= player.Size;
            this.linkDestHeight *= player.Size;
            this.swordDestWidth *= player.Size;
            this.swordDestHeight *= player.Size;
            this.swordOffset *= player.Size;
            this.sword = new ProjLinkStabRight(player);
            this.player.GetProjectiles().Add(sword);
        }
        public void Update()
        {
            delay++;
            if (delay == 3) /*Delay of frame changes*/
            {
                delay = 0;
                curFrame++;
                if (curFrame > totalFrames)
                {
                    if (player.GetInventory().Health == player.GetInventory().MaxHealth)
                    {
                        IProjectile swordBeam = new ProjLinkSwordRight(player);
                        player.GetProjectiles().Add(swordBeam);
                        swordBeam.Shoot();
                    }
                    player.SetState(new PStateIdleRight(player,coolDown));
                }
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle linkDestRec = new Rectangle((int)player.GetPosition().X, (int)player.GetPosition().Y, linkDestWidth, linkDestHeight);
            Rectangle linkSrcRec = new Rectangle(linkSrcX, linkSrcY, linkSrcWidth, linkSrcHeight);
            Rectangle swordSrcRec = new Rectangle(swordSrcX, swordSrcY, swordSrcWidth, swordSrcHeight);
            Rectangle swordDestRec;
            if (curFrame == 1)
            {
                swordDestRec = new Rectangle((int)player.GetPosition().X + swordOffset / 3, (int)player.GetPosition().Y, swordDestWidth, swordDestHeight);
            }
            else if (curFrame == 2)
            {
                swordDestRec = new Rectangle((int)player.GetPosition().X + swordOffset / 2, (int)player.GetPosition().Y, swordDestWidth, swordDestHeight);
            }
            else if (curFrame == 3 || curFrame == 4)
            {
                sword.Shoot();
                swordDestRec = new Rectangle((int)player.GetPosition().X + swordOffset, (int)player.GetPosition().Y, swordDestWidth, swordDestHeight);
            }
            else
            {
                swordDestRec = new Rectangle((int)player.GetPosition().X + swordOffset / 2, (int)player.GetPosition().Y, swordDestWidth, swordDestHeight);
            }
            spriteBatch.Begin();
            spriteBatch.Draw(texture, swordDestRec, swordSrcRec, Color.White);
            spriteBatch.Draw(texture, linkDestRec, linkSrcRec, Color.White);
            spriteBatch.End();
        }
    }
}
