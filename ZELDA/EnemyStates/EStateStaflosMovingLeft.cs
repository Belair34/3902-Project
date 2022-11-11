using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.Projectiles;

namespace Game1.PlayerStates
{
    class EStateStalfosMovingLeft : IEnemyState
    {
        ISprite sprite;
        IEnemy enemy;
        int coolDown;
        public EStateStalfosMovingLeft(IEnemy enemy, int coolDown = 0)
        {
            this.enemy = enemy;
            this.sprite = SpriteFactory.Instance.GetStalfosMovingLeft(enemy);
            this.coolDown = coolDown;
        }
        public void MoveUp()
        {
            enemy.SetState(new EStateStalfosMovingUp(enemy, coolDown));
        }

        public void MoveDown()
        {
            enemy.SetState(new EStateStalfosMovingDown(enemy, coolDown));
        }
        public void MoveLeft()
        {
        }

        public void MoveRight()
        {
            enemy.SetState(new EStateStalfosMovingRight(enemy, coolDown));
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
