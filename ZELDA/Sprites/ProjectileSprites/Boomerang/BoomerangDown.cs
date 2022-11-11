using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System;

namespace Game1.ProjectileSprites
{
    class BoomerangDown : ISprite
    {
        Texture2D texture;
        IProjectile projectile;
        int boomSrcWidth = 5;
        int boomSrcHeight = 10;
        int boomDestWidth = 5;
        int boomDestHeight = 10;
        int boomSrcX = 0;
        int boomSrcY = 111;
        int speed;
        float rotation;
        float velocity = 30f;

        public BoomerangDown(IProjectile projectile, Texture2D texture)
        {
            this.texture = texture;
            this.projectile = projectile;
            this.boomDestWidth *= projectile.Size;
            this.boomDestHeight *= projectile.Size;
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
            rotation += MathHelper.ToRadians(velocity);
            Rectangle boomSrcRec = new Rectangle(boomSrcX, boomSrcY, boomSrcWidth, boomSrcHeight);
            Rectangle boomDestRec = new Rectangle((int)projectile.GetPosition().X+25, (int)projectile.GetPosition().Y+45, boomDestWidth, boomDestHeight);
            spriteBatch.Begin();
            spriteBatch.Draw(texture, boomDestRec, boomSrcRec, Color.White, rotation, new Vector2(3,5),SpriteEffects.None,0); //gotta play around with origin vector due to rotation
            spriteBatch.End();
        }
    }
}
