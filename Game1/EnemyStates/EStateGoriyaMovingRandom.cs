using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework.Input;
using Game1.Projectiles;

namespace Game1.PlayerStates
{
    class EStateGoriyaMovingRandom : IEnemyState
    {
        ISprite sprite;
        IEnemy enemy;
        Random rand;
        int coolDown;
        int randomNum;
        public EStateGoriyaMovingRandom(IEnemy enemy, int coolDown = 0)
        {
            this.rand = new Random();
            randomNum = rand.Next(-2, 2);
            switch(randomNum)
            {
                case 0:
                    this.sprite = SpriteFactory.Instance.GetGoriyaMovingDown(enemy);
                    break;
                case -1:
                    this.sprite = SpriteFactory.Instance.GetGoriyaMovingUp(enemy);
                    break;
                case -2:
                    this.sprite = SpriteFactory.Instance.GetGoriyaMovingLeft(enemy);
                    break;
                case 1:
                    this.sprite = SpriteFactory.Instance.GetGoriyaMovingRight(enemy);
                    break;
            }
            this.enemy = enemy;
            this.coolDown = coolDown;
        }
        public void MoveUp()
        {
            //enemy.SetState(new EStateMovingUp(enemy, coolDown));
        }

        public void MoveDown()
        {
            enemy.SetState(new EStateGoriyaDown(enemy, coolDown));
        }
        public void MoveLeft()
        {
            //enemy.SetState(new EStateMovingLeft(enemy, coolDown));
        }

        public void MoveRight()
        {
            //enemy.SetState(new EStateMovingRight(enemy, coolDown));
        }
        public void MoveHorizontal()
        {
            
        }

        public void MoveVertical()
        {
            
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
