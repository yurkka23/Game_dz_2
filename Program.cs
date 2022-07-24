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
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
