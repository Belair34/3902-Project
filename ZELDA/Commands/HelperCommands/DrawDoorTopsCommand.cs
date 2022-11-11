using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.PlayerStates;
using System.Collections.Generic;

namespace Game1
{
    class DrawDoorTopsCommand : ICommand
	{
        private Game1 game;
        private SpriteBatch spriteBatch;
        private Texture2D texture;
        private Border border;
        private GraphicsDeviceManager graphics;
        private int doorSrcWidth;
        private int doorSrcHeight;
        private int doorDestWidth;
        private int doorDestHeight;
        private Rectangle topDoorSrc;
        private Rectangle botDoorSrc;
        private Rectangle leftDoorSrc;
        private Rectangle rightDoorSrc;
        private Rectangle topDoorDest;
        private Rectangle botDoorDest;
        private Rectangle leftDoorDest;
        private Rectangle rightDoorDest;

        public DrawDoorTopsCommand(Game1 game, SpriteBatch spriteBatch, Texture2D texture, Border border, GraphicsDeviceManager graphics)
		{
            this.spriteBatch = spriteBatch;
            this.texture = texture;
            this.border = border;
            this.graphics = graphics;
            this.doorSrcWidth = 35;
            this.doorSrcHeight = 17;
            this.doorDestWidth = 108;
            this.doorDestHeight = 46;
            this.topDoorSrc = new Rectangle(625, 886, doorSrcWidth, doorSrcHeight);
            this.topDoorDest = new Rectangle(345, game.GetHUD().GetHeight(), doorDestWidth, doorDestHeight);
            this.botDoorSrc = new Rectangle(625, 1045, doorSrcWidth, doorSrcHeight);
            this.botDoorDest = new Rectangle(345, graphics.GraphicsDevice.Viewport.Height-doorDestHeight, doorDestWidth, doorDestHeight);
            this.leftDoorSrc = new Rectangle(515, 956, doorSrcHeight, doorSrcWidth);
            this.leftDoorDest = new Rectangle(0, game.GetHUD().GetHeight()+190, doorDestHeight+8, doorDestWidth-11);
            this.rightDoorSrc = new Rectangle(754, 956, doorSrcHeight, doorSrcWidth);
            this.rightDoorDest = new Rectangle(746, game.GetHUD().GetHeight() + 190, doorDestHeight + 8, doorDestWidth - 11);


        }

		public void Execute()
		{
            spriteBatch.Begin();
            if (border.TopIsOpen())
            {
                spriteBatch.Draw(texture, topDoorDest, topDoorSrc, Color.White);
            }
            if (border.BottomIsOpen())
            {
                spriteBatch.Draw(texture, botDoorDest, botDoorSrc, Color.White);
            }
            if (border.LeftIsOpen())
            {
                spriteBatch.Draw(texture, leftDoorDest, leftDoorSrc, Color.White);
            }
            if (border.RightIsOpen())
            {
                spriteBatch.Draw(texture, rightDoorDest, rightDoorSrc, Color.White);
            }
            spriteBatch.End();

        }
	}
}
