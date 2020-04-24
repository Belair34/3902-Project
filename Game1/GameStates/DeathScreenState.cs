using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;
using Game1.Sound;

namespace Game1
{
    class DeathScreenState : IGameState
    {
        Game1 game;
        GraphicsDeviceManager graphics;
        List<IController> controllers;
        Texture2D deathScreenTexture;
        Rectangle srcRec;
        Rectangle destRec;


        public DeathScreenState(Game1 game, GraphicsDeviceManager graphics)
        {
            this.game = game;
            this.graphics = graphics;
            this.deathScreenTexture = SpriteFactory.Instance.GetGameOver();
            this.srcRec = new Rectangle(0, 0, 780, 437);
            this.destRec = new Rectangle(0, 0, graphics.GraphicsDevice.Viewport.Width, graphics.PreferredBackBufferHeight);
            controllers = new List<IController>();           /*Controllers*/
            controllers.Add(new KeyboardController(game));
        }

        public void SetRoom(IRoom room)
        {
            //not applicable
        }

        public void Update()
        {
            foreach (IController controller in controllers)
            {
                controller.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(deathScreenTexture, destRec, srcRec, Color.White);
            spriteBatch.End();
        }
    }
}
