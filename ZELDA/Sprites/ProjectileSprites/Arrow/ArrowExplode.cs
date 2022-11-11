using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System;

namespace Game1.ProjectileSprites
{
    class ArrowExplode : ISprite
    {
        Texture2D texture;
        IProjectile projectile;
        int srcWidth = 12;
        int srcHeight = 10;
        int destWidth = 12;
        int destHeight = 10;
        int srcX = 147;
        int srcY = 112;
        int xCorrection = 7;
        int yCorrection = 10;

        public ArrowExplode(IProjectile projectile, Texture2D texture)
        {
            this.texture = texture;
            this.projectile = projectile;
            this.destWidth *= projectile.Size;
            this.destHeight *= projectile.Size;
        }
        public void Update()
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle srcRec = new Rectangle(srcX, srcY, srcWidth, srcHeight);
            Rectangle destRec = new Rectangle((int)projectile.GetPosition().X+xCorrection, (int)projectile.GetPosition().Y+yCorrection, destWidth, destHeight);
            spriteBatch.Begin();
            spriteBatch.Draw(texture, destRec, srcRec, Color.White);
            spriteBatch.End();
        }
    }
}
