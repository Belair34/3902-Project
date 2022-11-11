using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System;

namespace Game1.ProjectileSprites
{
    class SwordExplode : ISprite
    {
        private ISprite topLeft;
        private ISprite topRight;
        private ISprite botLeft;
        private ISprite botRightl;

        public SwordExplode(IProjectile projectile, Texture2D texture)
        {
            topLeft = new SwordExplodeTopLeft(projectile, texture);
            topRight = new SwordExplodeTopRight(projectile, texture);
            botLeft = new SwordExplodeBotLeft(projectile, texture);
            botRightl = new SwordExplodeBotRight(projectile, texture);
        }
        public void Update()
        {
            topLeft.Update();
            topRight.Update();
            botLeft.Update();
            botRightl.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            topLeft.Draw(spriteBatch);
            topRight.Draw(spriteBatch);
            botLeft.Draw(spriteBatch);
            botRightl.Draw(spriteBatch);
        }
    }
}
