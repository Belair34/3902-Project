using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.Projectiles;

namespace Game1.PlayerStates
{
    class EStateGoriyaMovingLeft : IEnemyState
    {
        ISprite sprite;
        IEnemy enemy;
        int coolDown;
        public EStateGoriyaMovingLeft(IEnemy enemy, int coolDown = 0)
        {
            this.enemy = enemy;
            this.sprite = SpriteFactory.Instance.GetGoriyaMovingLeft(enemy);
            this.coolDown = coolDown;
        }
        public void MoveUp()
        {
            enemy.SetState(new EStateGoriyaMovingUp(enemy, coolDown));
        }

        public void MoveDown()
        {
            enemy.SetState(new EStateGoriyaMovingDown(enemy, coolDown));
        }
        public void MoveLeft()
        {
        }

        public void MoveRight()
        {
            enemy.SetState(new EStateGoriyaMovingRight(enemy, coolDown));
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

        public void Stop()
        {

        }

        public void Update()
        {
            if (coolDown > 0)
            {
                coolDown--;
            }
            sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }


    }
}
