using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public class Inventory : IInventory
    {
        public int Direction { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Rupees { get; set; }
        public int Keys { get; set; }
        public int Bombs { get; set; }
        public int Arrows { get; set; }
        public int TriforceShards { get; set; }
        public int CandleUsed { get; set; }
        public int HaveMap { get; set; }
        public int HaveCompass { get; set; }
        public int HaveWoodRang { get; set; }
        public int HaveBlueCandle { get; set; }
        public int HaveBow { get; set; }
        public int HaveBlueRing { get; set; }
        public int HaveWand { get; set; }
        public int HaveSword { get; set; }
        public int CurrentRoom { get; set; }
        public Vector2 SlotBCoordinates { get; set; }
        IPlayer player;
        ICommand slotB;

        public Inventory(IPlayer player)
        {
            this.player = player;
            Health = 6;
            MaxHealth = 6;
            Rupees = 0;
            Keys = 0;
            Bombs = 10;
            Arrows = 10; //set for testing purposes. will be 0 eventually
            TriforceShards = 0;
            CandleUsed = 0;
            HaveMap = 0;
            HaveCompass = 0;
            HaveWoodRang = 0;
            HaveBlueCandle = 0;
            HaveBow = 0;
            HaveBlueRing = 0;
            HaveWand = 0;
            CurrentRoom = 1;
            slotB = new EmptyCommand(player);
            SlotBCoordinates = new Vector2(350, 0);
        }
        public ICommand GetSlotBCommand()
        { 
            return slotB;
        }
        public void SetSlotBCommand(ICommand command, int textureX, int textureY)
        {
            Vector2 newCoords = new Vector2(textureX, textureY);
            SlotBCoordinates = newCoords;
            slotB = command;
        }

        public void Update()
        {
            if(Health > MaxHealth)
            {
                Health = MaxHealth;
            }
            else if(Health < 0)
            {
                Health = 0;
            }
        }
    }
}
