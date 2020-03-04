using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System;

namespace Game1.ProjectileSprites
{
    class ArrowDown : AbstractSprite, ISprite
    {
        int speed;
        //branching test

        public ArrowDown(IProjectile projectile, Texture2D texture) : base((IDrawable)projectile, texture)
        {
            Initialize();
            this.speed = projectile.Speed;
        }
        internal override void Initialize()
        {
            base.srcWidth = 15;
            base.srcHeight = 15;
            base.destWidth = 15;
            base.destHeight = 15;
            base.srcX = 119;
            base.srcY = 195;
        }
        public override void Update()
        {
            int projX = (int)drawable.GetPosition().X;
            int projY = (int)drawable.GetPosition().Y;
            projY += speed;
            ((IProjectile)drawable).SetPosition(projX, projY);
            ((IProjectile)drawable).ShotDistance += speed;
        }
    }
}
