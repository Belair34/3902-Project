using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Collections;
using Game1.PlayerStates;
using Game1.Projectiles;
/*Authors: Mike Belair, Chase Armstrong, Zhiren Xu, Xian Zhang, Simon Manning, Yunseong Lee */
namespace Game1
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //SpriteFont text;
        List<IController> controllers;
        IPlayer player;
        Border border;
        IRoom room;
        IRoom nextRoom;
        bool switchingRooms;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            switchingRooms = false;
        }

        public IPlayer GetPlayer()
        {
            return this.player;
        }


        public void SetRoom(IRoom room)
        {
            this.nextRoom = room;
            switchingRooms = true;
        }

        public void Reset()
        {
            Initialize();
        }
        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            SpriteFactory.Instance.LoadAll(Content);
            SpriteFactoryItems.Instance.LoadAll(Content);
            border = new Border(graphics);
            player = new PlayerDefault(100, 100, this);
            room = new Room1(this, border, graphics, 1);
            
            controllers = new List<IController>();           /*Controllers*/
            controllers.Add(new KeyboardController(this));
            controllers.Add(new GamepadController(this));
             
            this.IsMouseVisible = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {

        }

   
        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (switchingRooms)
            {
                room = nextRoom;
                switchingRooms = false;
            }
            foreach(IController controller in controllers)
            {
                controller.Update();
            }
            room.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            room.Draw(spriteBatch);
            base.Draw(gameTime);
            
        }
    }
}
