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
        List<IController> controllers;
        Border border;
        List<IRoom> rooms;
        IRoom currentRoom;
        int nextRoom;
        int nextSpawnDoor;
        bool switchingRooms;
        bool creating;
        public static bool paused = false;

        public InGameState(Game1 game, GraphicsDeviceManager graphics)
        {
            this.game = game;
            this.graphics = graphics;
            this.creating = true;
        }

        public void SetRoom(int room, int spawnDoor)
        {
            this.nextRoom = room;
            this.nextSpawnDoor = spawnDoor;
            switchingRooms = true;
        }
        public void Initialize()
        {
            switchingRooms = false;
            ZeldaSound.Instance.PlayMusic();
            ZeldaSound.Instance.ChangeVolume(0.5f);
            border = new Border(graphics, game.GetHUD(), SpriteFactory.Instance.GetBackgroundTexture());
            this.rooms = new List<IRoom>();
            rooms.Add(null); //this is to make the index match up with the assigned room numbers
            rooms.Add(new Room1(game, border, graphics));
            rooms.Add(new Room2(game, border, graphics));
            rooms.Add(new Room3(game, border, graphics));
            rooms.Add(new Room4(game, border, graphics));
            rooms.Add(new Room5(game, border, graphics));
            rooms.Add(new Room6(game, border, graphics));
            rooms.Add(new Room7(game, border, graphics));
            rooms.Add(new Room8(game, border, graphics));
            rooms.Add(new Room9(game, border, graphics));
            rooms.Add(new Room10(game, border, graphics));
            rooms.Add(new Room11(game, border, graphics));
            rooms.Add(new Room12(game, border, graphics));
            rooms.Add(new Room13(game, border, graphics));
            rooms.Add(null);
            rooms.Add(new Room15(game, border, graphics));
            rooms.Add(new Room16(game, border, graphics));
            rooms.Add(new Room17(game, border, graphics));
            rooms.Add(new Room18(game, border, graphics));
            currentRoom = rooms[1];
            currentRoom.SetBorders();
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
                currentRoom.Transitioning = false;
                currentRoom.ResetCamera();
                currentRoom = rooms[nextRoom];
                currentRoom.SetBorders();
                currentRoom.SpawnLink(nextSpawnDoor);
                switchingRooms = false;
            }
            if ((Keyboard.GetState().IsKeyDown(Keys.Space)))
            {
                paused = !paused;
            }
            if (!paused)
                {
                    foreach (IController controller in controllers)
                    {
                        controller.Update();
                    }
                    currentRoom.Update();
                }
           
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!creating)
            {
                currentRoom.Draw(spriteBatch);
                game.GetHUD().Draw(spriteBatch);
            }
        }
    }
}
