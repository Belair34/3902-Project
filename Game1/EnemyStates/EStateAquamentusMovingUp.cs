using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.Projectiles;

namespace Game1.PlayerStates
{
    class EStateAquamentusMovingUp : IEnemyState
    {
        ISprite sprite;
        IEnemy enemy;
        int coolDown;
        public EStateAquamentusMovingUp(IEnemy enemy, int coolDown = 0)
        {
            this.enemy = enemy;
            this.sprite = SpriteFactory.Instance.GetAquamentusMovingUp(enemy);
            this.coolDown = coolDown;
        }
        public void MoveUp()
        {
        }

        public void MoveDown()
        {
            enemy.SetState(new EStateAquamentusMovingDown(enemy, coolDown));
        }
        public void MoveLeft()
        {
            enemy.SetState(new EStateAquamentusMovingLeft(enemy, coolDown));
        }

        public void MoveRight()
        {
            enemy.SetState(new EStateAquamentusMovingRight(enemy, coolDown));
        }
        public void MoveHorizontal()
        {

        }

        public void MoveVertical()
        {
            //enemy.SetState(new EStateGelMovingVertical(enemy, coolDown));
        }
        public void MoveToPlayer()
        {
            //enemy.SetState(new EStateMovingToPlayer(enemy, coolDown));
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
