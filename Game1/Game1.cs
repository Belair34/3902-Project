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
        SpriteFont hudFont;
        KeyboardState key, prevKey;
        public List<IController> controllers;
        IPlayer player;
        Border border;
        public HUD hud;
        public IGameState gameState;
        public IRoom room;
        IRoom nextRoom;
        bool switchingRooms;
        public bool paused = false;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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

        public void Reset()
        {
            Initialize();
        }
        protected override void Initialize()
        {
            
            switchingRooms = false;
            spriteBatch = new SpriteBatch(GraphicsDevice);
            SpriteFactory.Instance.LoadAll(Content);
            SpriteFactoryItems.Instance.LoadAll(Content);
            hudFont = Content.Load<SpriteFont>("HUDfont");
            hud = new HUD(graphics, this, hudFont);
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 480 + hud.GetHeight();
            graphics.ApplyChanges();
            border = new Border(graphics, hud, SpriteFactory.Instance.GetBackgroundTexture());
            player = new PlayerDefault(100, 100, this);
            room = new Room1(this, border, graphics, 1);
            controllers = new List<IController>();           /*Controllers*/
            controllers.Add(new KeyboardController(this));

            //controllers.Add(new GamepadController(this));
             
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
            prevKey = key;
            key = Keyboard.GetState();
            if (!paused)
            {
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
                base.Update(gameTime);
                //gameState.Update(gameTime);
            }
            if (key.IsKeyDown(Keys.Space) && prevKey.IsKeyUp(Keys.Space))
            {
                paused = !paused;
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            {
                room.Draw(spriteBatch);
                hud.Draw(spriteBatch);
                base.Draw(gameTime);
                //gameState.Draw(spriteBatch);
            }
        }
        public static Game1 getInstance()
        {
            return new Game1();
        }
    }
}
