using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class SpriteFactoryItems
    {
        private Texture2D linkSheet;
        private Texture2D altLinkSheet;


        public static SpriteFactoryItems instance = new SpriteFactoryItems();

        public static SpriteFactoryItems Instance
        {
            get
            {
                return instance;
            }
        }
        private SpriteFactoryItems()
        {
        }

        public void LoadAll(ContentManager content)
        {
            linkSheet = content.Load<Texture2D>("ProjectSpriteSheets/LinkSpriteSheet");
            altLinkSheet = content.Load<Texture2D>("ProjectSpriteSheets/AltLinkSheet");
        }

        public ISprite GetArrow(IItems item)
        {
            return new ArrowSprite(item,linkSheet);
        }
        
        public ISprite GetBomb(IItems item)
        {
            return new BombSprite(item,linkSheet);
        }
        
        public ISprite GetBoomerang(IItems item)
        {
            return new BoomerangSprite(item,altLinkSheet);
        }

        public ISprite GetBow(IItems item)
        {
            return new BowSprite(item, linkSheet);
        }

        public ISprite GetClock(IItems item)
        {
            return new ClockSprite(item, linkSheet);
        }
        public ISprite GetHeart(IItems item)
        {
            return new HeartSprite(item, linkSheet);
        }

        public ISprite GetKey(IItems item)
        {
            return new KeySprite(item,linkSheet);
        }

        public ISprite GetRupee(IItems item)
        {
            return new RupeeSprite(item,linkSheet);
        }
        public ISprite GetFlashingRupee(IItems item)
        {
            return new FlashingRupeeSprite(item, linkSheet);
        }
        public ISprite GetMap(IItems item)
        {
            return new MapSprite(item, linkSheet);
        }
        public ISprite GetSword(IItems item)
        {
            return new SwordSprite(item, linkSheet);
        }

    }
}
