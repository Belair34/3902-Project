using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1.EnemySprites
{
    class AnimatedKeese : AbstractSprite, ISprite
    {
        internal override void Initialize()
        {
            base.srcWidth = 16;
            base.srcHeight = 16;
            base.destWidth = 32;
            base.destHeight = 32;
            base.srcX = 183; /*Change this*/
            base.srcY = 11;  /*and this*/
        }

        int curFrame = 1;
        int totalFrames = 2;
        int delay = 0;

        public AnimatedKeese(IDrawable drawable, Texture2D texture) : base(drawable, texture)
        {
            Initialize();
        }
        public override void Update()
        {
            delay++;
            if (delay == 7) /*Delay of frame changes*/
            {
                delay = 0;
                curFrame++;
                if (curFrame > totalFrames)
                {
                    curFrame = 1;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destRec = GetDestRect();
            Rectangle srcRec;
            if (curFrame == 1) /*Change these to correct frames, might need to add/delete else if*/
            {
                srcX = 183;
                srcY = 11;
            }
            else if (curFrame == 2)
            {
                srcX = 200;
                srcY = 11;
            }
            srcRec = new Rectangle(srcX, srcY, srcWidth, srcHeight);
            spriteBatch.Begin();
            spriteBatch.Draw(texture, destRec, srcRec, Color.White);
            spriteBatch.End();
        }
    }
}
