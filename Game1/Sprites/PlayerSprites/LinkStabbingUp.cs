using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;

namespace Game1.PlayerSprites
{
    class LinkStabbingUp :ISprite
    {
        Texture2D texture;
        IPlayer player;
        IProjectile sword;
        int linkSrcWidth = 15;
        int linkSrcHeight = 16;
        int swordSrcWidth = 12;
        int swordSrcHeight = 16;
        int linkDestWidth = 15;
        int linkDestHeight = 16;
        int swordDestWidth = 12;
        int swordDestHeight = 16;
        int linkSrcX = 60; /*Change this*/
        int linkSrcY = 60;  /*and this*/
        int swordSrcX = 61;
        int swordSrcY = 195;
        int swordOffset = 12;
        int curFrame = 1;
        int totalFrames = 5; /*Maybe this*/
        int delay = 0;
        int coolDown = 20;

        public LinkStabbingUp(IPlayer player, Texture2D texture)
        {
            this.texture = texture;
            this.player = player;
            this.linkDestWidth *= player.Size;
            this.linkDestHeight *= player.Size;
            this.swordDestWidth *= player.Size;
            this.swordDestHeight *= player.Size;
            this.swordOffset *= player.Size;
            this.sword = new ProjLinkStabUp(player);
            this.player.GetProjectiles().Add(sword);
        }
        public void Update()
        {
            delay++;
            if(delay == 3) /*Delay of frame changes*/
            {
                delay = 0;
                curFrame++;
                if(curFrame > totalFrames)
                {
                    if (player.GetInventory().Health == player.GetInventory().MaxHealth)
                    {
                        IProjectile swordBeam = new ProjLinkSwordUp(player);
                        player.GetProjectiles().Add(swordBeam);
                        swordBeam.Shoot();
                    }
                    player.SetState(new PStateIdleUp(player,coolDown));
                }
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle linkDestRec = new Rectangle((int)player.GetPosition().X, (int)player.GetPosition().Y, linkDestWidth, linkDestHeight);
            Rectangle linkSrcRec = new Rectangle(linkSrcX, linkSrcY, linkSrcWidth, linkSrcHeight);
            Rectangle swordSrcRec = new Rectangle(swordSrcX, swordSrcY, swordSrcWidth, swordSrcHeight);
            Rectangle swordDestRec;
            if(curFrame == 1)
            {
                swordDestRec = new Rectangle((int)player.GetPosition().X, (int)player.GetPosition().Y-swordOffset/3, swordDestWidth, swordDestHeight);
            }
            else if(curFrame == 2)
            {
                swordDestRec = new Rectangle((int)player.GetPosition().X, (int)player.GetPosition().Y-swordOffset/2, swordDestWidth, swordDestHeight);
            }
            else if(curFrame == 3 || curFrame == 4)
            {
                sword.Shoot();
                swordDestRec = new Rectangle((int)player.GetPosition().X, (int)player.GetPosition().Y-swordOffset, swordDestWidth, swordDestHeight);
            }
            else
            {
                swordDestRec = new Rectangle((int)player.GetPosition().X, (int)player.GetPosition().Y-swordOffset/2, swordDestWidth, swordDestHeight);
            }
            spriteBatch.Begin();
            spriteBatch.Draw(texture, swordDestRec, swordSrcRec, Color.White);
            spriteBatch.Draw(texture, linkDestRec, linkSrcRec, Color.White);
            spriteBatch.End();
        }
    }
}
