using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Game1.PlayerSprites;
using Game1.EnemySprites;
using Game1.ProjectileSprites;
using System;

namespace Game1
{
    class SpriteFactory
    {
        private Texture2D linkSheet;
        private Texture2D altLinkSheet;
        private Texture2D enemyLinkSheet;
        private Texture2D explosionSheet;
        private Texture2D bossLinkSheet;
        private Texture2D rooms;
        private static SpriteFactory instance = new SpriteFactory();
        public static SpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private SpriteFactory()
        {
        }

        /*Player Sprites*/
        public void LoadAll(ContentManager content)
        {
            linkSheet = content.Load<Texture2D>("ProjectSpriteSheets/LinkSpriteSheet");
            altLinkSheet = content.Load<Texture2D>("ProjectSpriteSheets/AltLinkSheet");
            enemyLinkSheet = content.Load<Texture2D>("ProjectSpriteSheets/Blade trap, Gel, Goriya, keese, stalfos, wall master");
            explosionSheet = content.Load<Texture2D>("ProjectSpriteSheets/ExplosionSheet");
            bossLinkSheet = content.Load<Texture2D>("ProjectSpriteSheets/boss");
            rooms = content.Load<Texture2D>("ProjectSpriteSheets/dungeon");
        }

        public ISprite GetLinkIdleDown(IPlayer player)
        {
            return new LinkIdleDown(player, linkSheet);
        }

        public ISprite GetLinkIdleUp(IPlayer player)
        {
            return new LinkIdleUp(player, linkSheet);
        }

        public ISprite GetLinkIdleRight(IPlayer player)
        {
            return new LinkIdleRight(player, linkSheet);
        }

        public ISprite GetLinkIdleLeft(IPlayer player)
        {
            return new LinkIdleLeft(player, linkSheet);
        }

        public ISprite GetLinkMovingDown(IPlayer player)
        {
            return new LinkMovingDown(player, linkSheet);
        }

        public ISprite GetLinkMovingUp(IPlayer player)
        {
            return new LinkMovingUp(player, linkSheet);
        }

        public ISprite GetLinkMovingRight(IPlayer player)
        {
            return new LinkMovingRight(player, linkSheet);
        }

        public ISprite GetLinkMovingLeft(IPlayer player)
        {
            return new LinkMovingLeft(player, linkSheet);
        }

        public ISprite GetLinkStabbingUp(IPlayer player)
        {
            return new LinkStabbingUp(player, linkSheet);
        }

        public ISprite GetLinkStabbingDown(IPlayer player)
        {
            return new LinkStabbingDown(player, linkSheet);
        }

        public ISprite GetLinkStabbingLeft(IPlayer player)
        {
            return new LinkStabbingLeft(player, linkSheet);
        }

        public ISprite GetLinkStabbingRight(IPlayer player)
        {
            return new LinkStabbingRight(player, linkSheet);
        }
        public ISprite GetLinkShootingDown(IPlayer player, IProjectile projectile)
        {
            return new LinkShootingDown(player, linkSheet, projectile);
        }
        public ISprite GetLinkShootingUp(IPlayer player, IProjectile projectile)
        {
            return new LinkShootingUp(player, linkSheet, projectile);
        }
        public ISprite GetLinkShootingLeft(IPlayer player, IProjectile projectile)
        {
            return new LinkShootingLeft(player, linkSheet, projectile);
        }
        public ISprite GetLinkShootingRight(IPlayer player, IProjectile projectile)
        {
            return new LinkShootingRight(player, linkSheet, projectile);
        }
        public ISprite GetLinkDamagedUp(IPlayer player)
        {
            return new LinkDamagedUp(player, linkSheet);
        }
        public ISprite GetLinkDamagedDown(IPlayer player)
        {
            return new LinkDamagedDown(player, linkSheet);
        }
        public ISprite GetLinkDamagedRight(IPlayer player)
        {
            return new LinkDamagedRight(player, linkSheet);
        }
        public ISprite GetLinkDamagedLeft(IPlayer player)
        {
            return new LinkDamagedLeft(player, linkSheet);
        }

        /*Projectile Sprites*/
        public ISprite GetLinkArrowDown(IProjectile projectile)
        {
            return new ArrowDown(projectile, linkSheet);
        }

        public ISprite GetLinkArrowUp(IProjectile projectile)
        {
            return new ArrowUp(projectile, linkSheet);
        }

        public ISprite GetLinkArrowLeft(IProjectile projectile)
        {
            return new ArrowLeft(projectile, linkSheet);
        }

        public ISprite GetLinkArrowRight(IProjectile projectile)
        {
            return new ArrowRight(projectile, linkSheet);
        }

        public ISprite GetLinkArrowExplode(IProjectile projectile)
        {
            return new ArrowExplode(projectile, altLinkSheet);
        }

        public ISprite GetWandWaveDown(IProjectile projectile)
        {
            return new WandWaveDown(projectile, altLinkSheet);
        }

        public ISprite GetWandWaveUp(IProjectile projectile)
        {
            return new WandWaveUp(projectile, altLinkSheet);
        }

        public ISprite GetWandWaveLeft(IProjectile projectile)
        {
            return new WandWaveLeft(projectile, altLinkSheet);
        }

        public ISprite GetWandWaveRight(IProjectile projectile)
        {
            return new WandWaveRight(projectile, altLinkSheet);
        }

        public ISprite GetBoomerangDown(IProjectile projectile)
        {
            return new BoomerangDown(projectile, altLinkSheet);
        }

        public ISprite GetBoomerangUp(IProjectile projectile)
        {
            return new BoomerangUp(projectile, altLinkSheet);
        }

        public ISprite GetBoomerangLeft(IProjectile projectile)
        {
            return new BoomerangLeft(projectile, altLinkSheet);
        }

        public ISprite GetBoomerangRight(IProjectile projectile)
        {
            return new BoomerangRight(projectile, altLinkSheet);
        }

        public ISprite GetLinkSwordBeamDown(IProjectile projectile)
        {
            return new SwordBeamDown(projectile, linkSheet);
        }

        public ISprite GetLinkSwordBeamUp(IProjectile projectile)
        {
            return new SwordBeamUp(projectile, linkSheet);
        }

        public ISprite GetLinkSwordBeamLeft(IProjectile projectile)
        {
            return new SwordBeamLeft(projectile, linkSheet);
        }

        public ISprite GetLinkSwordBeamRight(IProjectile projectile)
        {
            return new SwordBeamRight(projectile, linkSheet);
        }

        public ISprite GetLinkSwordExplode(IProjectile projectile)
        {
            return new SwordExplode(projectile, linkSheet);
        }

        public ISprite GetLinkBomb(IProjectile projectile)
        {
            return new Bomb(projectile, linkSheet);
        }

        public ISprite GetLinkBombExplode(IProjectile projectile)
        {
            return new BombExplode(projectile, explosionSheet);
        }
        public ISprite GetAquaFireballExplode(IProjectile projectile)
        {
            return new FireballExplode(projectile, bossLinkSheet);
        }

        public ISprite GetAquaFireballDown(IProjectile projectile)
        {
            return new AquaFireballDown(projectile, bossLinkSheet);
        }

        public ISprite GetAquaFireballUp(IProjectile projectile)
        {
            return new AquaFireballUp(projectile, bossLinkSheet);
        }

        public ISprite GetAquaFireballLeft(IProjectile projectile)
        {
            return new AquaFireballLeft(projectile, bossLinkSheet);
        }

        public ISprite GetAquaFireballRight(IProjectile projectile)
        {
            return new AquaFireballRight(projectile, bossLinkSheet);
        }
        /*Enemy Sprites*/
        public ISprite GetGelIdleJump(IEnemy enemy)
        {
            return new GelIdleJump(enemy, enemyLinkSheet);
        }
        public ISprite GetGelMovingLeft(IEnemy enemy)
        {
            return new GelMovingLeft(enemy, enemyLinkSheet);
        }
        public ISprite GetGelMovingRight(IEnemy enemy)
        {
            return new GelMovingRight(enemy, enemyLinkSheet);
        }
        public ISprite GetGelMovingUp(IEnemy enemy)
        {
            return new GelMovingUp(enemy, enemyLinkSheet);
        }
        public ISprite GetGelMovingDown(IEnemy enemy)
        {
            return new GelMovingDown(enemy, enemyLinkSheet);
        }
        public ISprite GetAnimatedKeese(IEnemy enemy)
        {
            return new AnimatedKeese(enemy, enemyLinkSheet);
        }
        public ISprite GetAnimatedWallMaster(IEnemy enemy)
        {
            return new AnimatedWallMaster(enemy, enemyLinkSheet);
        }
        public ISprite GetBladeTrapSprites(IEnemy enemy)
        {
            return new BladeTrapSprites(enemy, enemyLinkSheet);
        }
        public ISprite GetGoriyaDown(IEnemy enemy)
        {
            return new GoriyaDown(enemy, enemyLinkSheet);
        }
        public ISprite GetGoriyaRight(IEnemy enemy)
        {
            return new GoriyaRight(enemy, enemyLinkSheet);
        }
        public ISprite GetGoriyaThrowRight(IEnemy enemy)
        {
            return new GoriyaThrowRight(enemy, enemyLinkSheet);
        }
        public ISprite GetGoriyaUp(IEnemy enemy)
        {
            return new GoriyaUp(enemy, enemyLinkSheet);
        }
        public ISprite GetAquamentusMovingUp(IEnemy enemy)
        {
            return new AquamentusMovingUp(enemy, bossLinkSheet);
        }
        public ISprite GetAquamentusMovingDown(IEnemy enemy)
        {
            return new AquamentusMovingDown(enemy, bossLinkSheet);
        }
        public ISprite GetAquamentusMovingLeft(IEnemy enemy)
        {
            return new AquamentusMovingLeft(enemy, bossLinkSheet);
        }
        public ISprite GetAquamentusMovingRight(IEnemy enemy)
        {
            return new AquamentusMovingRight(enemy, bossLinkSheet);
        }
        public ISprite GetStalfosMovingUp(IEnemy enemy)
        {
            return new StalfosMovingUp(enemy, enemyLinkSheet);
        }
        public ISprite GetStalfosMovingDown(IEnemy enemy)
        {
            return new StalfosMovingDown(enemy, enemyLinkSheet);
        }
        public ISprite GetStalfosMovingLeft(IEnemy enemy)
        {
            return new StalfosMovingLeft(enemy, enemyLinkSheet);
        }
        public ISprite GetStalfosMovingRight(IEnemy enemy)
        {
            return new StalfosMovingRight(enemy, enemyLinkSheet);
        }
        /*Room texture*/
        public Texture2D GetBackgroundTexture()
        {
            return rooms;
        }
    }
}