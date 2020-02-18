using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{

    public class KeyboardController : IController
    {
        Game1 myGame;
        int delay;
        public KeyboardController(Game1 game)
        {
            myGame = game;
            delay = 0;
        }

        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.E))
            {
                myGame.GetPlayer().TakeDamage(2);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.R))
            {
                myGame.GetPlayer().GetInventory().Health += 2;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Z) || Keyboard.GetState().IsKeyDown(Keys.N))
            {
                myGame.GetPlayer().SlotA();
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.X) || Keyboard.GetState().IsKeyDown(Keys.M))
            {
                myGame.GetPlayer().SlotB();
            }
            else if ((Keyboard.GetState().IsKeyDown(Keys.D1)))
            {
                myGame.GetPlayer().GetInventory().SetSlotBCommand(new BowCommand(myGame.GetPlayer()));
                myGame.GetPlayer().SlotB();
            }
            else if ((Keyboard.GetState().IsKeyDown(Keys.D2)))
            {
                myGame.GetPlayer().GetInventory().SetSlotBCommand(new WandCommand(myGame.GetPlayer()));
                myGame.GetPlayer().SlotB();
            }
            else if ((Keyboard.GetState().IsKeyDown(Keys.D3)))
            {
                myGame.GetPlayer().GetInventory().SetSlotBCommand(new BoomerangCommand(myGame.GetPlayer()));
                myGame.GetPlayer().SlotB();
            }
            else if ((Keyboard.GetState().IsKeyDown(Keys.D4)))
            {
                myGame.GetPlayer().GetInventory().SetSlotBCommand(new BombCommand(myGame.GetPlayer()));
                myGame.GetPlayer().SlotB();
            }
            else if ((Keyboard.GetState().IsKeyDown(Keys.D5)))
            {
                myGame.GetPlayer().GetInventory().SetSlotBCommand(new EmptyCommand(myGame.GetPlayer()));
                myGame.GetPlayer().SlotB();
            }
            else if ((Keyboard.GetState().IsKeyDown(Keys.I)) && delay <= 0)
            {
                delay = 20;
                if(myGame.items1.Count > 1)
                {
                    myGame.items2.Push(myGame.items1.Pop());
                }
            }
            else if ((Keyboard.GetState().IsKeyDown(Keys.U)) && delay <= 0)
            {
                delay = 20;
                if (myGame.items2.Count > 0)
                {
                    myGame.items1.Push(myGame.items2.Pop());
                }

            }
            else if ((Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Up)) && !((Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down))))
            {
                myGame.GetPlayer().MoveUp();
            }
            else if((Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down)) && !((Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Up))))
            {
                myGame.GetPlayer().MoveDown();
            }
            else if ((Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left)) && !((Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right))))
            {
                myGame.GetPlayer().MoveLeft();
            }
            else if ((Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right)) && !((Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left))))
            {
                myGame.GetPlayer().MoveRight();
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.O))
            {
                
                
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.P))
            {

            }
            else
            {
                myGame.GetPlayer().Stop();
            }

            if(delay > 0)
            {
                delay--;
            }

        }
       
    }
}

