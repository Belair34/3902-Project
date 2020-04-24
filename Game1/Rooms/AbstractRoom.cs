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
        internal ICommand entityClearer;
        internal ICommand transitionHandler;
        internal List<IEnemy> enemies;
        internal List<IItem> items;
        internal List<ICollidable> collidables;
        internal List<Block> blocks;
        internal List<Water> waters;
        internal Texture2D background;
        internal Rectangle backgroundSrcRec;
        internal Rectangle backgroundDestRec;
        internal GraphicsDeviceManager graphics;

        public AbstractRoom(Game1 game, Border border, GraphicsDeviceManager graphics)
        {
            this.game = game;
            this.border = border;
            this.graphics = graphics;
            this.enemies = new List<IEnemy>();
            this.items = new List<IItem>();
            this.collidables = new List<ICollidable>();
            this.blocks = new List<Block>();
            this.waters = new List<Water>();
            this.background = SpriteFactory.Instance.GetBackgroundTexture();
            this.backgroundDestRec = new Rectangle(0, game.GetHUD().GetHeight(), graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height-game.GetHUD().GetHeight());
            this.Transitioning = false;
            collidables.Add(game.GetPlayer());
            collisionChecker = new CheckAllCollisionsCommand(collidables, border);
            entityClearer = new ClearEntitiesCommand(collidables, game.GetPlayer().GetProjectiles(), items, enemies);
        }
        public bool Transitioning { get; set; }

        public abstract void ResetCamera();
        public abstract void SetBorders();

        public void SpawnLink(int spawnDoor)
        {
            switch (spawnDoor)
            {
                case 0: // 0 = top 
                    game.GetPlayer().SetPosition(graphics.GraphicsDevice.Viewport.Width / 2, game.GetHUD().GetHeight());
                    game.GetPlayer().SetState(new PStateIdleDown(game.GetPlayer()));
                    break;
                case 1: // 1 = bottom
                    game.GetPlayer().SetPosition(graphics.GraphicsDevice.Viewport.Width / 2, graphics.GraphicsDevice.Viewport.Height - game.GetPlayer().GetHitBox().Height);
                    game.GetPlayer().SetState(new PStateIdleUp(game.GetPlayer()));
                    break;
                case 2: // 2 = left
                    game.GetPlayer().SetPosition(0, ((graphics.GraphicsDevice.Viewport.Height - game.GetHUD().GetHeight()) / 2) + game.GetHUD().GetHeight());
                    game.GetPlayer().SetState(new PStateIdleRight(game.GetPlayer()));
                    break;
                case 3: // 3 = right
                    game.GetPlayer().SetPosition(graphics.GraphicsDevice.Viewport.Width - game.GetPlayer().GetHitBox().Width, ((graphics.GraphicsDevice.Viewport.Height - game.GetHUD().GetHeight()) / 2) + game.GetHUD().GetHeight());
                    game.GetPlayer().SetState(new PStateIdleLeft(game.GetPlayer()));
                    break;
                default:
                    break;
            }
        }
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
                entityClearer.Execute();
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
                else if (game.GetPlayer().GetPosition().Y < game.GetHUD().GetHeight())
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
                DrawDoorTops(spriteBatch);
            }
        }

        private void DrawDoorTops(SpriteBatch spriteBatch)
        {
            ICommand DoorsCommand = new DrawDoorTopsCommand(game, spriteBatch, background, border, graphics);
            DoorsCommand.Execute();
        }

    }
}
