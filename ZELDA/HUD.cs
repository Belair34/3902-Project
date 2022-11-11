using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public class HUD
    {
        private Game1 game;
        private Texture2D background;
        private Texture2D heartSheet;
        private int height;
        private int heartWidth;
        private int heartHeight;
        private int heartScale;
        private Vector2 heartsPosition;
        private Rectangle srcRec;
        private Rectangle destRec;
        private Rectangle heartSrc;
        private Rectangle halfHeartSrc;
        private SpriteFont hudFont;

        public HUD(GraphicsDeviceManager graphics, Game1 game, SpriteFont font)
        {
            this.game = game;
            this.hudFont = font;
            this.height = 200;
            this.heartScale = 3;
            this.heartWidth = 8;
            this.heartHeight = 8;
            this.background = SpriteFactory.Instance.GetHUDBackground();
            this.heartSheet = SpriteFactory.Instance.GetLinkSheet();
            this.srcRec = new Rectangle(0, 0, 1024, 349);
            this.destRec = new Rectangle(0, 0, graphics.GraphicsDevice.Viewport.Width, height);
            this.heartsPosition = new Vector2(550,(int)((float)height*0.70));
            this.heartSrc = new Rectangle(244, 199, heartWidth, heartHeight);
            this.halfHeartSrc = new Rectangle(244, 199, heartWidth / 2, heartHeight);
        }

        public int GetHeight()
        {
            return height;
        }
        
        private void DrawHearts(SpriteBatch spriteBatch)
        {
            int i;
            int health = game.GetPlayer().GetInventory().Health;
            for(i = 0; i < health / 2; i++)
            {
                DrawHeart(spriteBatch, (int)heartsPosition.X + i * heartWidth * heartScale, (int)heartsPosition.Y);
            }
            if(health % 2 != 0)
            {
                DrawHalfHeart(spriteBatch, (int)heartsPosition.X + i * heartWidth * heartScale, (int)heartsPosition.Y);
            }
        }
        private void DrawHeart(SpriteBatch spriteBatch, int x, int y)
        {
            Rectangle destRec = new Rectangle(x, y, heartWidth*heartScale, heartHeight*heartScale);
            spriteBatch.Draw(heartSheet, destRec, heartSrc, Color.White);
        }

        private void DrawHalfHeart(SpriteBatch spriteBatch, int x, int y)
        {
            Rectangle destRec = new Rectangle(x, y, (heartWidth/2)*heartScale, heartHeight*heartScale);
            spriteBatch.Draw(heartSheet, destRec, halfHeartSrc, Color.White);
        }
        
        private void DrawValues(SpriteBatch spriteBatch)
        {
            int rupees = game.GetPlayer().GetInventory().Rupees;
            int keys = game.GetPlayer().GetInventory().Keys;
            int bombs = game.GetPlayer().GetInventory().Bombs;
            Vector2 rupeesPosition = new Vector2(330, (int)((float)height*0.33));
            Vector2 keysPosition = new Vector2(330, (int)((float)height * 0.52));
            Vector2 bombsPosition = new Vector2(330, (int)((float)height * 0.69));
            spriteBatch.DrawString(hudFont, rupees.ToString("D2"), rupeesPosition, Color.White);
            spriteBatch.DrawString(hudFont, keys.ToString("D2"), keysPosition, Color.White);
            spriteBatch.DrawString(hudFont, bombs.ToString("D2"), bombsPosition, Color.White);
        }

        private void DrawABSlots(SpriteBatch spriteBatch)
        {
            Rectangle ASlotDest = new Rectangle(473, (int)((float)height * 0.49), 30, 40);
            Rectangle BSlotDest = new Rectangle(405, (int)((float)height * 0.5), 20, 40);
            Rectangle ASlotSrc = new Rectangle(61, 195, 12, 16);
            Rectangle BSlotSrc = new Rectangle((int)game.GetPlayer().GetInventory().SlotBCoordinates.X, (int)game.GetPlayer().GetInventory().SlotBCoordinates.Y, 9, 16);
            spriteBatch.Draw(heartSheet, ASlotDest, ASlotSrc, Color.White);
            spriteBatch.Draw(heartSheet, BSlotDest, BSlotSrc, Color.White);
        }

        private void DrawMapLocation(SpriteBatch spriteBatch)
        {
            Rectangle srcRec = new Rectangle(1000, 0, 10, 10);
            Rectangle destRec = new Rectangle();
            switch (game.GetPlayer().GetInventory().CurrentRoom)
            {
                case 1:
                    destRec = new Rectangle(130, 145, 15, 5);
                    break;
                case 2:
                    destRec = new Rectangle(105, 145, 15, 5);
                    break;
                case 3:
                    destRec = new Rectangle(155, 145, 15, 5);
                    break;
                case 4:
                    destRec = new Rectangle(130, 136, 15, 5);
                    break;
                case 5:
                    destRec = new Rectangle(130, 127, 15, 5);
                    break;
                case 6:
                    destRec = new Rectangle(105, 127, 15, 5);
                    break;
                case 7:
                    destRec = new Rectangle(155, 127, 15, 5);
                    break;
                case 8:
                    destRec = new Rectangle(130, 117, 15, 5);
                    break;
                case 9:
                    destRec = new Rectangle(105, 117, 15, 5);
                    break;
                case 10:
                    destRec = new Rectangle(80, 117, 15, 5);
                    break;
                case 11:
                    destRec = new Rectangle(130, 108, 15, 5);
                    break;
                case 12:
                    destRec = new Rectangle(130, 99, 15, 5);
                    break;
                case 13:
                    destRec = new Rectangle(105, 99, 15, 5);
                    break;
                case 15:
                    destRec = new Rectangle(155, 117, 15, 5);
                    break;
                case 16:
                    destRec = new Rectangle(180, 117, 15, 5);
                    break;
                case 17:
                    destRec = new Rectangle(180, 108, 15, 5);
                    break;
                case 18:
                    destRec = new Rectangle(205, 108, 15, 5);
                    break;
                case 0:
                    destRec = new Rectangle(130, 145, 15, 5);
                    break;

            }
            
            spriteBatch.Draw(SpriteFactory.Instance.GetBackgroundTexture(), destRec, srcRec, Color.White);

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(background, destRec, srcRec, Color.White);
            DrawHearts(spriteBatch);
            DrawValues(spriteBatch);
            DrawABSlots(spriteBatch);
            if (game.GetPlayer().GetInventory().HaveCompass == 1)
            {
                DrawMapLocation(spriteBatch);
            }
            spriteBatch.End();
        }

    }
}
