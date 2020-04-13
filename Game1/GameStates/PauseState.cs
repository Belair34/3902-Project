using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class PauseState : IGameState
    {
        Game1 game;
        public PauseState()
        {
            game = Game1.getInstance();
            game.paused = true;
            game.controllers.Add(new PauseController());
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            game.room.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {

            foreach (IController controller in game.controllers)
            {
                controller.Update();
            }

        }
    }
}
