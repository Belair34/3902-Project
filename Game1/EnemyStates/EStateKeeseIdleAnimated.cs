﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.Projectiles;

namespace Game1.PlayerStates
{
    class EStateKeeseIdleAnimated : IEnemyState
    {
        ISprite sprite;
        IEnemy enemy;
        int coolDown;
        public EStateKeeseIdleAnimated(IEnemy enemy, int coolDown = 0)
        {
            this.enemy = enemy;
            this.sprite = SpriteFactory.Instance.GetAnimatedKeese(enemy);
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
        public void MoveHorizontal()
        {
            //enemy.SetState(new EStateKeeseIdleAnimated(enemy, coolDown));
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
