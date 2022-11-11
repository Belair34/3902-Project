using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System;

namespace Game1.ProjectileSprites
{
    class ArrowRight : ISprite
    {
        Texture2D texture;
        IProjectile projectile;
        int arrowSrcWidth = 15;
        int arrowSrcHeight = 7;
        int arrowDestWidth = 15;
        int arrowDestHeight = 7;
        int arrowSrcX = 210;
        int arrowSrcY = 199;
        int speed;

        public ArrowRight(IProjectile projectile, Texture2D texture)
        {
            this.texture = texture;
            this.projectile = projectile;
            this.arrowDestWidth *= projectile.Size;
            this.arrowDestHeight *= projectile.Size;
            this.speed = projectile.Speed;
        }
        public void Update()
        {
            int projX = (int)projectile.GetPosition().X;
            int projY = (int)projectile.GetPosition().Y;
            projX += speed;
            projectile.SetPosition(projX, projY);
            projectile.ShotDistance += speed;
        }

        public void Draw(SpriteBatch spriteBatch)
        { 
            Rectangle arrowSrcRec = new Rectangle(arrowSrcX, arrowSrcY, arrowSrcWidth, arrowSrcHeight);
            Rectangle arrowDestRec = new Rectangle((int)projectile.GetPosition().X, (int)projectile.GetPosition().Y, arrowDestWidth, arrowDestHeight);
            spriteBatch.Begin();
            spriteBatch.Draw(texture, arrowDestRec, arrowSrcRec, Color.White);
            spriteBatch.End();
        }
    }
}
