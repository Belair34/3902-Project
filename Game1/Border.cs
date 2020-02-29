using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Game1
{
    public class Border
    {
        private int minX;
        private int minY;
        private int maxX;
        private int maxY;
        private int verticalDoorTopY;
        private int horizontalDoorLeftX;
        private int topWallDistance;
        private int doorWidth;
        private Rectangle rightTop;
        private Rectangle rightBot;
        private bool topOpen;
        private bool leftOpen;
        private bool rightOpen;
        private bool botOpen;
        Texture2D block;

        public Border(GraphicsDeviceManager graphics, Texture2D back)
        {
            topWallDistance = 60;
            doorWidth = 25;
            minX = graphics.GraphicsDevice.Viewport.X + topWallDistance+30;
            minY = graphics.GraphicsDevice.Viewport.Y + topWallDistance;
            maxX = graphics.GraphicsDevice.Viewport.Width-topWallDistance*2-10;
            maxY = minY + graphics.GraphicsDevice.Viewport.Height - topWallDistance*3-12;
            verticalDoorTopY = graphics.GraphicsDevice.Viewport.Height / 2 - doorWidth / 2 - 20;
            horizontalDoorLeftX = graphics.GraphicsDevice.Viewport.Width / 2 - doorWidth / 2;
            rightTop = new Rectangle(maxX, 0, topWallDistance*2, verticalDoorTopY);
            rightBot = new Rectangle(maxX, verticalDoorTopY + doorWidth, topWallDistance, graphics.GraphicsDevice.Viewport.Y - verticalDoorTopY - doorWidth);
            rightOpen = true;
            topOpen = false;
            leftOpen = false;
            botOpen = false;
            block = back;
        }

        public void CheckCollision(ICollidable collidable)
        {
            if (collidable.GetHitBox().X > maxX)
            {
                if (!rightOpen)
                {
                    collidable.SetPosition(maxX, collidable.GetHitBox().Y);
                    collidable.BorderCollision();
                }
                else if (rightOpen && rightTop.Intersects(collidable.GetHitBox()))
                {
                    Rectangle intersection = Rectangle.Intersect(rightTop, collidable.GetHitBox());
                   if (intersection.Width > intersection.Height)
                    {
                        collidable.SetPosition(collidable.GetHitBox().X, rightTop.Bottom);
                    }
                    else if (intersection.Height > intersection.Width)
                    {
                        collidable.SetPosition(rightTop.Left, collidable.GetHitBox().Y);
                    } 
                    else
                    {
                        collidable.SetPosition(rightTop.X, collidable.GetHitBox().Y);
                    }
                }
          
            }
 
        }

        public void DrawBox(SpriteBatch spriteBatch)
        {
            Rectangle src = new Rectangle(900, 0, 1, 1);
            spriteBatch.Begin();
            spriteBatch.Draw(block, rightTop, src, Color.White);
            spriteBatch.End();
        }
    }
}
