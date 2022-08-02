using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Game_dz_2
{
    //Feature 1
    static class SuperPowerGenerator
    {
        //static int startVal = DateTime.Now.Second;
        public static int GenrateAmountSuperPower()
        {
            // var rand = new Random();
            // return rand.Next(5,10);
            /* int res = startVal;
             int multiplier = 5;
             int increment = 2;
             int module = 9;

             while (res < 5 || res > 10)
             {
                 res = (multiplier * res + increment) % module;

             }
             return res;*/
            return new Random().Next(5, 10);
        }
    }
    
    //Feature 2
    abstract class Warrior
    {
        public virtual int Hp { get; set; } = 100;
        public virtual int Defence { get; set; } = 10;
        public virtual int Power { get; set; } = 10;
        public bool isAlive
        {
            get
            {
                return this.Hp > 0 ? true : false;
            }
        }
        public virtual void AddSuperPower(ISuperPower superPower, int power) {
            superPower.AddSuperPower(this, power);
        }

        public int Attack()
        {
            if (this.Defence > 0)
            {
                return this.Power;
            }
            else if (this.Power >= 1)
            {
                return --this.Power;
            }
            else
            {
                return 1;
            }
        }

        public void Defend(int powerHit)
        {
            if (this.Defence > +powerHit / 2)
            {
                this.Hp -= powerHit / 2;
                this.Defence -= powerHit / 2;
            }
            else if (this.Defence > 0)
            {
                this.Hp -= powerHit - this.Defence;
                this.Defence = 0;
            }
            else
            {
                this.Hp -= powerHit;
            }
        }
        public override string ToString()
        {
            return $"BasicWarrior";
        }
    }

    class Bowman : Warrior
    {
        public override int Hp { get; set; } = 90;
        public Bowman(int defence = 4, int power = 16)
        {
            Defence = defence;
            Power = power;
        }
        public override string ToString()
        {
            return $"Bowman---Hp: {Hp}, Defence : {Defence}, Power: {Power}";
        }
        public override void AddSuperPower(ISuperPower superPower, int power)
        {
            superPower.AddSuperPower(this, power);
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
            return $"Ninja---Hp: {Hp}, Defence : {Defence}, Power: {Power}";
        }
        public override void AddSuperPower(ISuperPower superPower, int power)
        {
            superPower.AddSuperPower(this, power);
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
            return $"Samurai---Hp: {Hp}, Defence : {Defence}, Power: {Power}";
        }
        public override void AddSuperPower(ISuperPower superPower, int power)
        {
            superPower.AddSuperPower(this, power);
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
            return $"Knight---Hp: {Hp}, Defence : {Defence}, Power: {Power}";
        }
        public override void AddSuperPower(ISuperPower superPower, int power)
        {
            superPower.AddSuperPower(this, power);
        }
    }
    //Feature 3
    interface ISuperPower
    {
        void AddSuperPower(Warrior war, int power);
    }

    class SuperHp : ISuperPower
    {
        public void AddSuperPower(Warrior war, int power)
        {
            war.Hp += power;
        }
    }
    class SuperDefence : ISuperPower
    {
        public void AddSuperPower(Warrior war, int power)
        {
            war.Defence += power;
        }
    }
    class SuperPower : ISuperPower
    {
        public void AddSuperPower(Warrior war, int power)
        {
            war.Power += power;
        }
    }
    //Feature 4
    static class Battle
    {
        public static void Fight(Warrior player1, Warrior player2)
        {
            int rountFight = 1;
            do
            {
                Console.WriteLine($"------------------Fight round - {rountFight}-----------------");

                Console.WriteLine("Player 2 attacks -> Player 1");
                player1.Defend(player2.Attack());
                Console.WriteLine($"Player 2 (Power - {player2.Power})\nPlayer 1 (Hp - {player1.Hp})----(Defence - {player1.Defence})");
                if (player1.Hp <= 0)
                {
                    Console.WriteLine($"\nPlayer 2 WIN!!! In {rountFight} round. {player2}");
                    break;
                }

                Console.WriteLine("------------------------------------------------------");

                Console.WriteLine("Player 1 attacks -> Player 2");
                player2.Defend(player1.Attack());
                Console.WriteLine($"Player 1 (Power - {player1.Power})\nPlayer 2 (Hp - {player2.Hp})----(Defence - {player2.Defence})");

                if (player2.Hp <= 0)
                {
                    Console.WriteLine($"\nPlayer 1 WIN!!! In {rountFight} round. {player1}");
                }
                Console.WriteLine();

                rountFight++;
            } while (player1.isAlive && player2.isAlive);
        }
    }

    //Feature 5

    class Program
    {
        public static void AdditionalSuperPower(Warrior player, int power)
        {
            Console.WriteLine($"Generater Super Power for player is {power}");
     
            bool checkInput = true;
            do
            {
                Console.WriteLine("Choose which force it will be applied to : Hp, Defence, Power");
                string input1SuperPower = Console.ReadLine();

                switch (input1SuperPower)
                {
                    case "Hp":
                        player.AddSuperPower(new SuperHp(), power);
                        checkInput = false;
                        break;
                    case "Defence":
                        player.AddSuperPower(new SuperDefence(), power);
                        checkInput = false;
                        break;
                    case "Power":
                        player.AddSuperPower(new SuperPower(), power);
                        checkInput = false;
                        break;
                    default:
                        Console.WriteLine("Try again!");
                        break;
                }
                
            } while (checkInput);
            
        }
        public static Warrior GenerateHero(string question)
        {
            Warrior hero;
            do
            {
                Console.WriteLine(question);
                var response = Console.ReadLine();
                hero = GetHero(response);
                if (hero == null)
                {
                    Console.WriteLine("Try again");
                }
            }
            while (hero == null);
            return hero;
        }

        public static Warrior GetHero(string input)
        {
            if (int.TryParse(input, out int result))
            {
                return result switch
                {
                    1 => new Bowman(),
                    2 => new Ninja(),
                    3 => new Samurai(),
                    4 => new Knight(),
                    _ => null,
                };
            }
            return null;
        }
        static void Main(string[] args)
        {
            string gameContinue;
            do
            {
                Console.WriteLine("Game Start!\n");

                Warrior player1 = GenerateHero("Choose first warrior: 1,2,3,4");
                Console.WriteLine($"{player1}");

                Warrior player2 = GenerateHero("Choose second warrior: 1,2,3,4");
                Console.WriteLine($"{player2}\n");

      
               
                AdditionalSuperPower(player1, SuperPowerGenerator.GenrateAmountSuperPower());
                AdditionalSuperPower(player2, SuperPowerGenerator.GenrateAmountSuperPower());


                Console.WriteLine($"After Super Power: {player1}");
                Console.WriteLine($"After Super Power: {player2}\n");

                 Battle.Fight(player1, player2);
          
                Console.WriteLine($"After fight player 1: {player1}");
                Console.WriteLine($"After fight player 2: {player2}\n");
                Console.WriteLine("Game Over!");


                Console.WriteLine("\nEnter yes if you want to continue.");
                gameContinue = Console.ReadLine();
            } while (gameContinue == "yes");
           

        }
    }
}
