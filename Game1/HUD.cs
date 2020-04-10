using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public class HUD
    {
        private Game1 game;
        private Texture2D background;
        private int height;

        public HUD(GraphicsDeviceManager graphics, Game1 game)
        {
            this.game = game;
            this.height = 200;
        }

        public int GetHeight()
        {
            return height;
        }

    }
}
