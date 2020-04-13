using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Collections;
using Game1.PlayerStates;
using Game1.Projectiles;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Game1.Sound;


/*Authors: Mike Belair, Chase Armstrong, Zhiren Xu, Xian Zhang, Simon Manning, Yunseong Lee */
namespace Game1
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont hudFont;
        List<IController> controllers;
        IPlayer player;
        Border border;
        HUD hud;
        Song music;
        public List<SoundEffect> soundEffects;
        IRoom room;
        IRoom nextRoom;
        bool switchingRooms;

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
            ZeldaSound.Instance.LoadSound(Content);
            ZeldaSound.Instance.PlayMusic();
            ZeldaSound.Instance.ChangeVolume(-0.5f);
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
            hud.Draw(spriteBatch);
            room.Draw(spriteBatch);
            base.Draw(gameTime);
        }
    }
}
