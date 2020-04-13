using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class ZeldaGameState : IGameState
    {
        Game1 game;

        public ZeldaGameState()
        {
            game = Game1.getInstance();
            game.controllers.Add(new KeyboardController(game));

        }
        public void Update(GameTime gameTime)
        {

            foreach (IController controller in game.controllers)
            {
                controller.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.room.Draw(spriteBatch);
        }
    }
}
