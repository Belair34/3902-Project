using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
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
        public Stack<IItem> items1;
        public Stack<IItem> items2;
        List<IController> controllers;
        IPlayer player;
        IEnemy enemy;
        IItem item;
        private Texture2D background;
        Border border;

        //change this more efficiently maybe?
        public Stack<IEnemy> enemies1;
        public Stack<IEnemy> enemies2;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        public IPlayer GetPlayer()
        {
            return this.player;
        }
        public IItem GetItem()
        {
            return this.item;
        }
        public IEnemy GetEnemy()
        {

            return this.enemy;
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
            player = new PlayerDefault(100, 100, 6, 6);
            //enemy = new BladeTrap(600, 300, 3, 6, GraphicsDevice);
            this.backgroundSrcRec = new Rectangle(515, 886, 256, 176);
            this.backgroundDestRec = new Rectangle(0, 0, spriteBatch.GraphicsDevice.Viewport.Width, spriteBatch.GraphicsDevice.Viewport.Height);
            controllers = new List<IController>();           /*Controllers*/
            controllers.Add(new KeyboardController(this));
            //push items onto stack for rotation
            items1 = new Stack<IItem>();
            items2 = new Stack<IItem>();
            items1.Push(new ArrowItem(150,150,GraphicsDevice));
            items1.Push(new BombItem(150, 150, GraphicsDevice));
            items1.Push(new RupeeItem(150, 150, GraphicsDevice));
            items1.Push(new BoomerangItem(150, 150, GraphicsDevice));
            items1.Push(new FlashingRupeeItem(150, 150, GraphicsDevice));
            items1.Push(new BowItem(150, 150, GraphicsDevice));
            items1.Push(new SwordItem(150, 150, GraphicsDevice));
            items1.Push(new KeyItem(150, 150, GraphicsDevice));
            items1.Push(new ClockItem(150, 150, GraphicsDevice));
            items1.Push(new HeartItem(150, 150, GraphicsDevice));
            items1.Push(new MapItem(150, 150, GraphicsDevice));
            //get first item on stack
            item = items1.Peek();

            //enemy push
            enemies1 = new Stack<IEnemy>();
            enemies2 = new Stack<IEnemy>();
            enemies1.Push(new BladeTrap(600, 300, 3, 6, GraphicsDevice));
            enemies1.Push(new Gel(600, 300, 3, 6, GraphicsDevice));
            enemies1.Push(new Keese(600, 300, 3, 6, GraphicsDevice));
            enemies1.Push(new WallMaster(600, 300, 3, 6, GraphicsDevice));
            enemies1.Push(new Goriya(600, 300, 3, 6, GraphicsDevice));
            enemies1.Push(new Aquamentus(600, 300, 10, 20, GraphicsDevice));

            enemy = enemies1.Peek();

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
            //enemy
            if (enemies1.Count > 0)
            {
                enemy = enemies1.Peek();
            }
            enemy.Update();
            //border.CheckCollision(enemy);
            //item
            if (items1.Count > 0)
            {
                item = items1.Peek();
            }
            item.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(background, backgroundDestRec, backgroundSrcRec, Color.White);
            spriteBatch.End();
            //GraphicsDevice.Clear(Color.CornflowerBlue);
            enemy.Draw(spriteBatch);
            item.Draw(spriteBatch);
            player.Draw(spriteBatch);
            base.Draw(gameTime);
            
        }
    }
}
