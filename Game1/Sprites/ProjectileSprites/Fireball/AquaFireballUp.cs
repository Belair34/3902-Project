using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System;

namespace Game1.ProjectileSprites
{
    class ArrowLeft : ISprite
    {
        Texture2D texture;
        IProjectile projectile;
        int arrowSrcWidth = 15;
        int arrowSrcHeight = 15;
        int arrowDestWidth = 15;
        int arrowDestHeight = 15;
        int arrowSrcX = 150;
        int arrowSrcY = 194;
        int speed;

        public ArrowLeft(IProjectile projectile, Texture2D texture)
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
            projX -= speed;
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
