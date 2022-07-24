using System;

namespace Game_dz_2
{
    //Feature 1
    class SuperPowerGenerator
    {
        static int startVal = DateTime.Now.Second;
        public int GenrateAmountSuperPower()
        {
            // var rand = new Random();
            // return rand.Next(5,10);
            int res = startVal;
            int multiplier = 5;
            int increment = 2;
            int module = 9;

            while (res < 5 || res > 10)
            {
                res = (multiplier * res + increment) % module;

            }
            return res;
        }
    }
    //Feature 2
    abstract class Warrior
    {
        public int Hp { get; set; } = 100;
        public int Defence { get; set; }
        public int Power { get; set; }

    }

    class Bowman : Warrior
    {
        public Bowman(int defence = 4, int power = 16)
        {
            Defence = defence;
            Power = power;
        }
        public override string ToString()
        {
            return $"Hp: {Hp}, Defence : {Defence}, Power: {Power}";
        }
    }
    class Ninja : Warrior
    {
        public Ninja(int defence = 8, int power = 12)
        {
            Defence = defence;
            Power = power;
        }
        public override string ToString()
        {
            return $"Hp: {Hp}, Defence : {Defence}, Power: {Power}";
        }

    }
    class Samurai : Warrior
    {
        public Samurai(int defence = 12, int power = 8)
        {
            Defence = defence;
            Power = power;
        }
        public override string ToString()
        {
            return $"Hp: {Hp}, Defence : {Defence}, Power: {Power}";
        }
    }
    class Knight : Warrior
    {
        public Knight(int defence = 10, int power = 10)
        {
            Defence = defence;
            Power = power;
        }
        public override string ToString()
        {
            return $"Hp: {Hp}, Defence : {Defence}, Power: {Power}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
