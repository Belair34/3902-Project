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
        IPlayer player;
        Border border;
        HUD hud;
        IRoom room;
        IRoom nextRoom;
        bool switchingRooms;
        bool creating;

        public InGameState(Game1 game, GraphicsDeviceManager graphics, SpriteFont hudFont)
        {
            this.game = game;
            this.graphics = graphics;
            this.hudFont = hudFont;
            this.creating = true;
        }

        public HUD GetHUD()
        {
            return this.hud;
        }

        public IPlayer GetPlayer()
        {
            return this.player;
        }

        public void SetPlayer(IPlayer player)
        {
            this.player = player;
        }

        public void SetRoom(IRoom room)
        {
            this.nextRoom = room;
            switchingRooms = true;
        }
        public void Initialize()
        {
            switchingRooms = false;
            hud = new HUD(graphics, game, hudFont);
            ZeldaSound.Instance.PlayMusic();
            ZeldaSound.Instance.ChangeVolume(0.5f);
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 480 + hud.GetHeight();
            graphics.ApplyChanges();
            border = new Border(graphics, hud, SpriteFactory.Instance.GetBackgroundTexture());
            player = new PlayerDefault(100, 100, game);
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
            room.Draw(spriteBatch);
            hud.Draw(spriteBatch);
        }
    }
}
