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
        IGameState gameState;
        IGameState nextState;
        bool changingState;

        public Game1()
        {
            this.changingState = false;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        public HUD GetHUD()
        {
            return gameState.GetHUD();
        }

        public IPlayer GetPlayer()
        {
            return gameState.GetPlayer();
        }

        public void SetPlayer(IPlayer player)
        {
            gameState.SetPlayer(player);
        }

        public void SetRoom(IRoom room)
        {
            gameState.SetRoom(room);
        }

        public void SetState(IGameState state)
        {
            changingState = true;
            nextState = state;
        }

        public void Reset()
        {
            SetState(new InGameState(this, graphics, hudFont));
        }
        protected override void Initialize()
        {
            hudFont = Content.Load<SpriteFont>("HUDfont");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            SpriteFactory.Instance.LoadAll(Content);
            SpriteFactoryItems.Instance.LoadAll(Content);
            ZeldaSound.Instance.LoadSound(Content);
            gameState = new InGameState(this, graphics, hudFont);
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
            if (changingState)
            {
                gameState = nextState;
                changingState = false;
            }
            gameState.Update();
        }

        protected override void Draw(GameTime gameTime)
        { 
            gameState.Draw(spriteBatch);
        }
    }
}
