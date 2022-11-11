using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System;

namespace Game1.ProjectileSprites
{
    class FireballExplode : ISprite
    {
        Texture2D texture;
        IProjectile projectile;
        int srcWidth = 7;
        int srcHeight = 16;
        int destWidth = 7;
        int destHeight = 16;
        int srcX = 119;
        int srcY = 11;
        //int xCorrection = 7;
        //int yCorrection = 10;

        public FireballExplode(IProjectile projectile, Texture2D texture)
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
            /* delete +xCorrection and +yCorrection here */
            Rectangle destRec = new Rectangle((int)projectile.GetPosition().X, (int)projectile.GetPosition().Y, destWidth, destHeight);
            spriteBatch.Begin();
            spriteBatch.Draw(texture, destRec, srcRec, Color.White);
            spriteBatch.End();
        }
    }
}
