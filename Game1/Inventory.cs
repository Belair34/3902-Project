﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        IPlayer player;
        ICommand slotB;

        public Inventory(IPlayer player)
        {
            this.player = player;
            Health = 6;
            MaxHealth = 6;
            Rupees = 0;
            Keys = 0;
            Bombs = 0;
            Arrows = 10; //set to 4 for testing purposes. will be 0 eventually
            TriforceShards = 0;
            CandleUsed = 0;
            HaveMap = 0;
            HaveCompass = 0;
            HaveWoodRang = 0;
            HaveBlueCandle = 0;
            HaveBow = 0;
            HaveBlueRing = 0;
            slotB = new BowCommand(player);
        }
        public ICommand GetSlotBCommand()
        {
            slotB.Initialize(player);
            return slotB;
        }
        public void SetSlotBCommand(ICommand command)
        {
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
