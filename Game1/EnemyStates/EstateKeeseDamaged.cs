using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.Projectiles;

namespace Game1.PlayerStates
{
    class EStateKeeseDamaged: IEnemyState
    {
        ISprite sprite;
        IEnemy enemy;
        int coolDown;

        public EStateKeeseDamaged(IEnemy enemy, int coolDown = 0)
        {
            this.enemy = enemy;
            this.sprite = SpriteFactory.Instance.GetKeeseDamaged(enemy);
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
                enemy.SetState(new EStateKeeseMovingRight(enemy));
            }
            sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }

       
    }
}
