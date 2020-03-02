using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System;

namespace Game1.ProjectileSprites
{
    class AquaFireballDown : ISprite
    {
        Texture2D texture;
        IProjectile projectile;
        int fireballSrcWidth = 7;
        int fireballSrcHeight = 16;
        int fireballDestWidth = 7;
        int fireballDestHeight = 16;
        int fireballSrcX = 119;
        int fireballSrcY = 11;
        int speed;

        //start from here
        public AquaFireballDown(IProjectile projectile, Texture2D texture)
        {
            this.texture = texture;
            this.projectile = projectile;
            this.fireballDestWidth *= projectile.Size;
            this.fireballDestHeight *= projectile.Size;
            this.speed = projectile.Speed;
        }
        public void Update()
        {
            int projX = (int)projectile.GetPosition().X;
            int projY = (int)projectile.GetPosition().Y;
            projY += speed;
            projectile.SetPosition(projX, projY);
            projectile.ShotDistance += speed;
        }

        public void Draw(SpriteBatch spriteBatch)
        { 
            Rectangle arrowSrcRec = new Rectangle(fireballSrcX, fireballSrcY, fireballSrcWidth, fireballSrcHeight);
            Rectangle arrowDestRec = new Rectangle((int)projectile.GetPosition().X, (int)projectile.GetPosition().Y, fireballDestWidth, fireballDestHeight);
            spriteBatch.Begin();
            spriteBatch.Draw(texture, arrowDestRec, arrowSrcRec, Color.White);
            spriteBatch.End();
        }
    }
}
