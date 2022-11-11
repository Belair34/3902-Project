using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System;

namespace Game1
{
    public abstract class AbstractSprite : ISprite
    {
        internal Texture2D texture;
        internal IDrawable drawable;
        internal int srcWidth;
        internal int srcHeight;
        internal int destWidth;
        internal int destHeight;
        internal int srcX;
        internal int srcY;

        public AbstractSprite(IDrawable drawable, Texture2D texture)
        {
            Initialize();
            this.texture = texture;
            this.drawable = drawable;
            this.destWidth *= drawable.Size;
            this.destHeight *= drawable.Size;
        }
        public virtual void Update()
        {
            //default: do nothing
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Rectangle arrowSrcRec = new Rectangle(srcX, srcY, srcWidth, srcHeight);
            Rectangle arrowDestRec = GetDestRect();
            spriteBatch.Begin();
            spriteBatch.Draw(texture, arrowDestRec, arrowSrcRec, Color.White);
            spriteBatch.End();
        }

        internal abstract void Initialize();

        public Rectangle GetDestRect()
        {
            return new Rectangle((int)drawable.GetPosition().X, (int)drawable.GetPosition().Y, destWidth, destHeight);
        }

    }
}
