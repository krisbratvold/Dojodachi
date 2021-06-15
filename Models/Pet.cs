using System;

namespace Dojodachi.Models
{
    public class Pet
    {
        public int Fullness { get; set; } = 20;
        public int Happiness { get; set; } = 20;
        public int Energy { get; set; } = 50;
        public int Meals { get; set; } = 3;
        public Random rand = new Random();
        public int RandomStatAmnt
        {
            get
            {
                return rand.Next(5, 11);
            }
        }
        public bool QuarterChance
        {
            get
            {
                return rand.Next(1, 5) == 1;
            }
        }
        public bool IsDead
        {
            get
            {
                return Happiness <= 0 || Fullness <=0;
            }
        }
        public bool IsWinner
        {
            get{
                return Energy > 100 && Fullness > 100 && Happiness >100;
            }
        }

        public Pet()
        {
            Fullness = 20;
            Happiness = 20;
            Energy = 50;
            Meals = 3;

        }

        public bool Feed()
        {
            if (Meals <= 0)
            {
                return false;
            }
            int randFullness = rand.Next(5, 11);
            Meals -= 1;
            if (!QuarterChance)
            {
                Fullness += RandomStatAmnt;
            }
            return true;
        }
        public bool Play()
        {
            if (Energy < 5)
            {
                return false;
            }
            if(!QuarterChance)
            {
                Happiness += RandomStatAmnt;
            } 
            return true;
        }
        public bool Work()
        {
            if(Energy < 5)
            {
                return false;
            }
            Meals += rand.Next(1,4);
            Energy -= 5;
            return true;
        }
        public bool Sleep()
        {
            Energy += 15;
            Fullness -= 5;
            Happiness -=5;
            return true;
        }
    }
}
