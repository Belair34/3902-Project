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
            linkSheet = content.Load<Texture2D>(Stringholder.linkSheet);
            altLinkSheet = content.Load<Texture2D>(Stringholder.altLinkSheet);
        }

        public ISprite GetArrow(IItem item)
        {
            return new ArrowSprite(item,linkSheet);
        }
        
        public ISprite GetBomb(IItem item)
        {
            return new BombSprite(item,linkSheet);
        }
        
        public ISprite GetBoomerang(IItem item)
        {
            return new BoomerangSprite(item,linkSheet);
        }

        public ISprite GetBow(IItem item)
        {
            return new BowSprite(item, linkSheet);
        }

        public ISprite GetClock(IItem item)
        {
            return new ClockSprite(item, linkSheet);
        }
        public ISprite GetHeart(IItem item)
        {
            return new HeartSprite(item, linkSheet);
        }

        public ISprite GetKey(IItem item)
        {
            return new KeySprite(item,linkSheet);
        }

        public ISprite GetRupee(IItem item)
        {
            return new RupeeSprite(item,linkSheet);
        }
        public ISprite GetFlashingRupee(IItem item)
        {
            return new FlashingRupeeSprite(item, linkSheet);
        }
        public ISprite GetMap(IItem item)
        {
            return new MapSprite(item, linkSheet);
        }
        public ISprite GetCompass(IItem item)
        {
            return new CompassSprite(item, linkSheet);
        }
        public ISprite GetTriangle(IItem item)
        {
            return new TriangleSprite(item, linkSheet);
        }
        public ISprite GetSword(IItem item)
        {
            return new SwordSprite(item, linkSheet);
        }

    }
}
