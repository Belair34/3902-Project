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
        List<IEnemy> enemies;
        List<IItem> items;
        List<ICollidable> collidables;
        Border border;
        ICommand collisionChecker;
        ICommand projectileClearer;
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
            items = new List<IItem>();
            enemies = new List<IEnemy>();
            collidables = new List<ICollidable>();
            spriteBatch = new SpriteBatch(GraphicsDevice);
            SpriteFactory.Instance.LoadAll(Content);
            SpriteFactoryItems.Instance.LoadAll(Content);
            border = new Border(graphics);
            player = new PlayerDefault(100, 100, this);
            collidables.Add(player);
            collisionChecker = new CheckAllCollisionsCommand(collidables, border);
            projectileClearer = new ClearProjectilesCommand(collidables, player.GetProjectiles());
            this.backgroundSrcRec = new Rectangle(515, 886, 256, 176);
            this.backgroundDestRec = new Rectangle(0, 0, spriteBatch.GraphicsDevice.Viewport.Width, spriteBatch.GraphicsDevice.Viewport.Height);
            controllers = new List<IController>();           /*Controllers*/
            controllers.Add(new KeyboardController(this));
             
            this.IsMouseVisible = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            ICommand LoadEntities = new L1EntitiesLoadCommand(enemies, items, collidables);
            LoadEntities.Execute();
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
            foreach(IProjectile projectile in player.GetProjectiles())
            {
                if (!collidables.Contains(projectile))
                {
                    collidables.Add(projectile);
                }
            }
            projectileClearer.Execute();
            player.Update();
            foreach(IEnemy enemy in enemies)
            {
                enemy.Update();
            }
            foreach(IItem item in items)
            {
                item.Update();
            }
            collisionChecker.Execute();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(background, backgroundDestRec, backgroundSrcRec, Color.White);
            spriteBatch.End();
            //GraphicsDevice.Clear(Color.CornflowerBlue);
            player.Draw(spriteBatch);
            foreach(IEnemy enemy in enemies)
            {
                enemy.Draw(spriteBatch);
            }
            foreach(IItem item in items)
            {
                item.Draw(spriteBatch);
            }
            base.Draw(gameTime);
            
        }
    }
}
