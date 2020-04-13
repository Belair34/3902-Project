using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
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
        private Rectangle botRight;
        private Rectangle botLeft;
        private Rectangle leftTop;
        private Rectangle leftBot;
        private Rectangle topLeft;
        private Rectangle topRight;
        private List<Rectangle> rectangles;
        private bool topOpen;
        private bool leftOpen;
        private bool rightOpen;
        private bool botOpen;
        private Texture2D block;
        private HUD hud;

        public Border(GraphicsDeviceManager graphics, HUD hud, Texture2D back = null)
        {
            this.hud = hud;
            topWallDistance = 60;
            doorWidth = 25;
            minX = graphics.GraphicsDevice.Viewport.X + topWallDistance+30;
            minY = hud.GetHeight() + topWallDistance;
            maxX = graphics.GraphicsDevice.Viewport.Width - topWallDistance * 2 + 30;
            maxY = minY + graphics.GraphicsDevice.Viewport.Height - hud.GetHeight()- topWallDistance*2 - 30;
            verticalDoorTopY = (graphics.GraphicsDevice.Viewport.Height - hud.GetHeight()) / 2 + hud.GetHeight() - doorWidth / 2 - 20;
            horizontalDoorLeftX = graphics.GraphicsDevice.Viewport.Width / 2 - doorWidth*2 + 15;
            rectangles = new List<Rectangle>();
            rightTop = new Rectangle(maxX, 0, topWallDistance*2, verticalDoorTopY);
            rectangles.Add(rightTop);
            rightBot = new Rectangle(maxX, rightTop.Height+topWallDistance, topWallDistance*2, verticalDoorTopY + doorWidth);
            rectangles.Add(rightBot);
            botRight = new Rectangle(horizontalDoorLeftX + doorWidth*2 + 20, maxY, horizontalDoorLeftX, topWallDistance*2);
            rectangles.Add(botRight);
            botLeft = new Rectangle(0, maxY, horizontalDoorLeftX, topWallDistance * 2);
            rectangles.Add(botLeft);
            leftBot = new Rectangle(0, rightTop.Height + topWallDistance, minX, hud.GetHeight() + verticalDoorTopY + doorWidth);
            rectangles.Add(leftBot);
            leftTop = new Rectangle(0, 0, minX, verticalDoorTopY);
            rectangles.Add(leftTop);
            topLeft = new Rectangle(0, hud.GetHeight(), horizontalDoorLeftX, topWallDistance);
            rectangles.Add(topLeft);
            topRight = new Rectangle(horizontalDoorLeftX + doorWidth*2 + 20, hud.GetHeight(), horizontalDoorLeftX, topWallDistance);
            rectangles.Add(topRight);
            rightOpen = true;
            topOpen = true;
            leftOpen = true;
            botOpen = true;
            block = back;
        }

        public void CheckCollision(ICollidable collidable)
        {

            if (!rightOpen && collidable.GetHitBox().X + collidable.GetHitBox().Width > maxX)
            {
                collidable.SetPosition(maxX - collidable.GetHitBox().Width, collidable.GetHitBox().Y);
                collidable.BorderCollision();
            }
            else if (!botOpen && collidable.GetHitBox().Y + collidable.GetHitBox().Height > maxY)
            {
                collidable.SetPosition(collidable.GetHitBox().X, maxY - collidable.GetHitBox().Height);
                collidable.BorderCollision();
            }
            else if (!leftOpen && collidable.GetHitBox().X < minX)
            {
                collidable.SetPosition(minX, collidable.GetHitBox().Y);
                collidable.BorderCollision();
            }
            else if (!topOpen && collidable.GetHitBox().Y < minY)
            {
                collidable.SetPosition(collidable.GetHitBox().X, minY);
                collidable.BorderCollision();
            }
            else
            {
                foreach (Rectangle rec in rectangles)
                {
                    if (rec.Intersects(collidable.GetHitBox()))
                    {
                        Rectangle intersection = Rectangle.Intersect(rec, collidable.GetHitBox());
                        if (intersection.Height > intersection.Width && collidable.GetHitBox().X < rec.Left)
                        {
                            collidable.SetPosition(rec.Left - collidable.GetHitBox().Width, collidable.GetHitBox().Y);
                            collidable.BorderCollision();
                        }
                        else if (intersection.Width > intersection.Height && collidable.GetHitBox().Y < rec.Top)
                        {
                            collidable.SetPosition(collidable.GetHitBox().X, rec.Top - collidable.GetHitBox().Height);
                            collidable.BorderCollision();
                        }
                        else if (intersection.Width > intersection.Height && collidable.GetHitBox().Y > rec.Top)
                        { 
                            collidable.SetPosition(collidable.GetHitBox().X, rec.Bottom);
                            collidable.BorderCollision();
                        }
                        else if (intersection.Height > intersection.Width && collidable.GetHitBox().X > rec.Left)
                        {
                            collidable.SetPosition(rec.Right, collidable.GetHitBox().Y);
                            collidable.BorderCollision();
                        }
                        else
                        {
                            
                        }
                    }
                }
            }
        }

        public void SetRightOpen(bool isOpen)
        {
            rightOpen = isOpen;
        }

        public void SetLeftOpen(bool isOpen)
        {
            leftOpen = isOpen;
        }
        public void SetTopOpen(bool isOpen)
        {
            topOpen = isOpen;
        }
        public void SetBottomOpen(bool isOpen)
        {
            botOpen = isOpen;
        }

        public bool BottomIsOpen()
        {
            return botOpen;
        }

        public bool TopIsOpen()
        {
            return topOpen;
        }

        public bool LeftIsOpen()
        {
            return leftOpen;
        }

        public bool RightIsOpen()
        {
            return rightOpen;
        }

        /*For development to display hitboxes*/
        public void DrawBox(SpriteBatch spriteBatch)
        {
            Rectangle src = new Rectangle(900, 0, 1, 1);
            spriteBatch.Begin();
            spriteBatch.Draw(block, rightBot, src, Color.White);
            spriteBatch.End();
        }
    }
}
