using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;
using Game1.Sound;

namespace Game1
{
    class InGameState : IGameState
    {
        Game1 game;
        GraphicsDeviceManager graphics;
        SpriteFont hudFont;
        List<IController> controllers;
        
        Border border;
        IRoom room;
        IRoom nextRoom;
        bool switchingRooms;
        bool creating;

        public InGameState(Game1 game, GraphicsDeviceManager graphics)
        {
            this.game = game;
            this.graphics = graphics;
            this.creating = true;
        }

        public void SetRoom(IRoom room)
        {
            this.nextRoom = room;
            switchingRooms = true;
        }
        public void Initialize()
        {
            switchingRooms = false;
            ZeldaSound.Instance.PlayMusic();
            ZeldaSound.Instance.ChangeVolume(0.5f);
            border = new Border(graphics, game.GetHUD(), SpriteFactory.Instance.GetBackgroundTexture());
            room = new Room1(game, border, graphics, 1);
            controllers = new List<IController>();           /*Controllers*/
            controllers.Add(new KeyboardController(game));
        }
        public void Update()
        {
            if (creating)
            {
                Initialize();
                creating = false;
            }
            if (switchingRooms)
            {
                room = nextRoom;
                switchingRooms = false;
            }
            foreach (IController controller in controllers)
            {
                controller.Update();
            }
            room.Update();

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!creating)
            {
                room.Draw(spriteBatch);
                game.GetHUD().Draw(spriteBatch);
            }
        }
    }
}
