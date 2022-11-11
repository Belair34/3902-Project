using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System;

namespace Game1.ProjectileSprites
{
    class WandWaveLeft : ISprite
    {
        Texture2D texture;
        IProjectile projectile;
        int waveSrcWidth = 16;
        int waveSrcHeight = 17;
        int waveDestWidth = 16;
        int waveDestHeight = 17;
        int waveSrcX = 0;
        int waveSrcY = 139;
        int speed;
        

        public WandWaveLeft(IProjectile projectile, Texture2D texture)
        {
            this.texture = texture;
            this.projectile = projectile;
            this.waveDestWidth *= projectile.Size;
            this.waveDestHeight *= projectile.Size;
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
            Rectangle waveSrcRec = new Rectangle(waveSrcX, waveSrcY, waveSrcWidth, waveSrcHeight);
            Rectangle waveDestRec = new Rectangle((int)projectile.GetPosition().X, (int)projectile.GetPosition().Y, waveDestWidth, waveDestHeight);
            spriteBatch.Begin();
            spriteBatch.Draw(texture, waveDestRec, waveSrcRec, Color.White, MathHelper.Pi, new Vector2(0,16),SpriteEffects.None,0); //gotta play around with origin vector due to rotation
            spriteBatch.End();
        }
    }
}
