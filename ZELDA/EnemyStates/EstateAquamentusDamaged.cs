using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.Projectiles;

namespace Game1.PlayerStates
{
    class EStateAquamentusDamaged: IEnemyState
    {
        ISprite sprite;
        IEnemy enemy;
        int coolDown;
        Game1 game;

        public EStateAquamentusDamaged(IEnemy enemy, Game1 game, int coolDown = 0)
        {
            this.enemy = enemy;
            this.game = game;
            this.sprite = SpriteFactory.Instance.GetAquamentusDamaged(enemy);
            this.coolDown = coolDown;
        }
        public void MoveUp()
        {

        }

        public void MoveDown()
        {

        }
        public void MoveLeft()
        {

        }

        public void MoveRight()
        {

        }
        public void MoveHorizontal()
        {

        }

        public void MoveVertical()
        {

        }
        public void MoveToPlayer()
        {

        }

        public void TakeDamage(int damage)
        {

        }

        public void Stop()
        {

        }

        public void Update()
        {
            if (coolDown > 0)
            {
                coolDown--;
            }
            if(coolDown <= 0)
            {
                enemy.SetState(new EStateAquamentusMovingToPlayer(enemy, game));
            }
            sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }

       
    }
}
