using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Game1.PlayerStates;

namespace Game1
{
    public abstract class AbstractRoom : IRoom
    {
        internal Game1 game;
        internal Border border;
        internal ICommand entityLoader;
        internal ICommand collisionChecker;
        internal ICommand projectileClearer;
        internal ICommand transitionHandler;
        internal List<IEnemy> enemies;
        internal List<IItem> items;
        internal List<ICollidable> collidables;
        internal List<Block> blocks;
        internal Texture2D background;
        internal Rectangle backgroundSrcRec;
        internal Rectangle backgroundDestRec;
        internal GraphicsDeviceManager graphics;

        public AbstractRoom(Game1 game, Border border, GraphicsDeviceManager graphics, int spawnDoor)
        {
            this.game = game;
            this.border = border;
            this.graphics = graphics;
            this.enemies = new List<IEnemy>();
            this.items = new List<IItem>();
            this.collidables = new List<ICollidable>();
            this.blocks = new List<Block>();
            this.background = SpriteFactory.Instance.GetBackgroundTexture();
            this.Transitioning = false;
            collidables.Add(game.GetPlayer());
            collisionChecker = new CheckAllCollisionsCommand(collidables, border);
            projectileClearer = new ClearProjectilesCommand(collidables, game.GetPlayer().GetProjectiles());
            switch (spawnDoor)
            {
                case 0: // 0 = top 
                    game.GetPlayer().SetPosition(graphics.GraphicsDevice.Viewport.Width / 2, 0);
                    game.GetPlayer().SetState(new PStateIdleDown(game.GetPlayer()));
                    break;
                case 1: // 1 = bottom
                    game.GetPlayer().SetPosition(graphics.GraphicsDevice.Viewport.Width / 2, graphics.GraphicsDevice.Viewport.Height - game.GetPlayer().GetHitBox().Height);
                    game.GetPlayer().SetState(new PStateIdleUp(game.GetPlayer()));
                    break;
                case 2: // 2 = left
                    game.GetPlayer().SetPosition(0, graphics.GraphicsDevice.Viewport.Height / 2);
                    game.GetPlayer().SetState(new PStateIdleRight(game.GetPlayer()));
                    break;
                case 3: // 3 = right
                    game.GetPlayer().SetPosition(graphics.GraphicsDevice.Viewport.Width-game.GetPlayer().GetHitBox().Width, graphics.GraphicsDevice.Viewport.Height / 2);
                    game.GetPlayer().SetState(new PStateIdleLeft(game.GetPlayer()));
                    break;
                default:

                    break;
            }
        }
        public bool Transitioning { get; set; }
        public abstract void TransitionUp();

        public abstract void TransitionDown();

        public abstract void TransitionLeft();

        public abstract void TransitionRight();

        public void IncrementSourcePosition(int distance, bool vertical)
        {
            if (vertical)
            {
                backgroundSrcRec.Y += distance;
            }
            else
            {
                backgroundSrcRec.X += distance;
            }
        }

        public void Update()
        {
            if (Transitioning)
            {
                transitionHandler.Execute();
            }
            else
            {
                foreach (IProjectile projectile in game.GetPlayer().GetProjectiles())
                {
                    if (!collidables.Contains(projectile))
                    {
                        collidables.Add(projectile);
                    }
                }
                projectileClearer.Execute();
                foreach (IItem item in items)
                {
                    item.Update();
                }
                game.GetPlayer().Update();
                foreach (IEnemy enemy in enemies)
                {
                    enemy.Update();
                }
                collisionChecker.Execute();
                if (game.GetPlayer().GetPosition().X < 0)
                {
                    TransitionLeft();
                }
                else if (game.GetPlayer().GetPosition().X > graphics.GraphicsDevice.Viewport.Width - game.GetPlayer().GetHitBox().Width)
                {
                    TransitionRight();
                }
                else if (game.GetPlayer().GetPosition().Y > graphics.GraphicsDevice.Viewport.Height - game.GetPlayer().GetHitBox().Height)
                {
                    TransitionDown();
                }
                else if (game.GetPlayer().GetPosition().Y < 0)
                {
                    TransitionUp();
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(background, backgroundDestRec, backgroundSrcRec, Color.White);
            spriteBatch.End();
            //GraphicsDevice.Clear(Color.CornflowerBlue);
            if (!Transitioning)
            {
                foreach (IItem item in items)
                {
                    item.Draw(spriteBatch);
                }
                foreach(Block block in blocks)
                {
                    block.Draw(spriteBatch);
                }
                game.GetPlayer().Draw(spriteBatch);
                foreach (IEnemy enemy in enemies)
                {
                    enemy.Draw(spriteBatch);
                }
            }
        }

    }
}
