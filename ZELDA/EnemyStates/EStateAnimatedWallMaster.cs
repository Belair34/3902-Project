using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.Projectiles;

namespace Game1.PlayerStates
{
    class EStateAnimatedWallMaster : IEnemyState
    {
        ISprite sprite;
        IEnemy enemy;
        int coolDown;
        public EStateAnimatedWallMaster(IEnemy enemy, int coolDown = 0)
        {
            this.enemy = enemy;
            this.sprite = null;
            this.coolDown = coolDown;
        }
        public void MoveUp()
        {
            //enemy.SetState(new EStateMovingUp(enemy, coolDown));
        }

        public void MoveDown()
        {
            //enemy.SetState(new EStateMovingDown(enemy, coolDown));
        }
        public void MoveLeft()
        {
            //enemy.SetState(new EStateMovingLeft(enemy, coolDown));
        }

        public void MoveRight()
        {
            //enemy.SetState(new EStateMovingRight(enemy, coolDown));
        }
        public void MoveToPlayer()
        {
            //enemy.SetState(new EStateMovingToPlayer(enemy, coolDown));
        }
        public void MoveHorizontal()
        {
            throw new System.NotImplementedException();
        }
        public void MoveVertical()
        {
            throw new System.NotImplementedException();
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
