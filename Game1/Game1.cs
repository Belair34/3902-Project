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
        Rectangle backgroundSrcRec;
        Rectangle backgroundDestRec;
        //SpriteFont text;
        List<IController> controllers;
        IPlayer player;
        ArrayList collidables;
        Border border;
        private Texture2D background;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        public IPlayer GetPlayer()
        {
            return this.player;
        }

        public void Reset()
        {
            Initialize();
        }
        protected override void Initialize()
        {
            collidables = new ArrayList();
            spriteBatch = new SpriteBatch(GraphicsDevice);
            SpriteFactory.Instance.LoadAll(Content);
            SpriteFactoryItems.Instance.LoadAll(Content);
            border = new Border(graphics);
            player = new PlayerDefault(100, 100);
            this.backgroundSrcRec = new Rectangle(515, 886, 256, 176);
            this.backgroundDestRec = new Rectangle(0, 0, spriteBatch.GraphicsDevice.Viewport.Width, spriteBatch.GraphicsDevice.Viewport.Height);
            controllers = new List<IController>();           /*Controllers*/
            controllers.Add(new KeyboardController(this));

            //controllers.Add(new MouseController(this));
            this.IsMouseVisible = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            background = Content.Load<Texture2D>("ProjectSpriteSheets/dungeon");
        }

   
        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            foreach (IController controller in controllers)
            {
                controller.Update();
            }
            
            player.Update();
            border.CheckCollision(player);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(background, backgroundDestRec, backgroundSrcRec, Color.White);
            spriteBatch.End();
            //GraphicsDevice.Clear(Color.CornflowerBlue);
            player.Draw(spriteBatch);
            base.Draw(gameTime);
            
        }
    }
}
