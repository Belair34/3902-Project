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
        HUD hud;
        SpriteFont hudFont;
        List<IGameState> gameStates;
        IGameState currentState;
        IPlayer player;
        int nextState;
        bool changingState;
        bool initializing;

        public Game1()
        {
            this.graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.changingState = false;
            this.initializing = true;
        }

        public HUD GetHUD()
        {
            return this.hud;
        }

        public IPlayer GetPlayer()
        {
            return player;
        }

        public void SetPlayer(IPlayer player)
        {
            this.player = player;
        }

        public void SetRoom(IRoom room)
        {
            currentState.SetRoom(room);
        }

        public void SetState(int stateNum)
        {
            changingState = true;
            nextState = stateNum;
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
            ZeldaSound.Instance.LoadSound(Content);
            hudFont = Content.Load<SpriteFont>("HUDfont");
            this.player = new PlayerDefault(100, 100, this);
            this.hud = new HUD(graphics, this, hudFont);
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 480 + GetHUD().GetHeight();
            graphics.ApplyChanges();
            gameStates = new List<IGameState>();
            gameStates.Add(new InGameState(this, graphics));
            gameStates.Add(new DeathScreenState(this, graphics));
            currentState = gameStates[0];
            this.IsMouseVisible = true;
            base.Initialize();
            this.initializing = false;
        }

        protected override void LoadContent()
        {

        }


        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (changingState)
            {
                currentState = gameStates[nextState];
                changingState = false;
            }
            if (!initializing)
            {
                currentState.Update();
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            if (!initializing)
            {
                currentState.Draw(spriteBatch);
            }
        }
    }
}
