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
        public bool isAlive
        {
            get
            {
                return this.Hp > 0 ? true : false;
            }
        }
        public virtual void AddSuperPower(ISuperPower superPower, int power) { }

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
                return 0;
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
            return $"Hp: {Hp}, Defence : {Defence}, Power: {Power}";
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
            return $"Hp: {Hp}, Defence : {Defence}, Power: {Power}";
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
            return $"Hp: {Hp}, Defence : {Defence}, Power: {Power}";
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
                if (player2.Power > 0)
                {
                    player1.Defend(player2.Attack());
                }
                else
                {
                    Console.WriteLine("Player 2 doesn't have power to attack!!!");
                }
                Console.WriteLine($"Player 2 (Power - {player2.Power})\nPlayer 1 (Hp - {player1.Hp})----(Defence - {player1.Defence})");
                Console.WriteLine("------------------------------------------------------");
                if (player1.Hp <= 0)
                {
                    Console.WriteLine($"\nPlayer 2 WIN!!! In {rountFight} round.");
                    break;
                }

                Console.WriteLine("Player 1 attacks -> Player 2");
                if (player1.Power > 0)
                {
                    player2.Defend(player1.Attack());
                }
                else
                {
                    Console.WriteLine("Player 1 doesn't have power to attack!!!");
                }
                Console.WriteLine($"Player 1 (Power - {player1.Power})\nPlayer 2 (Hp - {player2.Hp})----(Defence - {player2.Defence})");

                if (player2.Hp <= 0)
                {
                    Console.WriteLine($"\nPlayer 1 WIN!!! In {rountFight} round.");
                }
                if (player1.Power <= 0 && player2.Power <= 0)
                {
                    Console.WriteLine("Draw!!!");
                }
                Console.WriteLine();

                rountFight++;
            } while (player1.isAlive && player2.isAlive);

        }


    }

    //Feature 5

    class Program
    {
        public static Warrior CreateWarrior(string nameWarrior)
        {
            switch (nameWarrior)
            {
                case "Bowman": return new Bowman();
                case "Ninja": return new Ninja();
                case "Samurai": return new Samurai();
                case "Knight": return new Knight();
                default: throw new Exception();
            }
        }
        public static void AdditionalSuperPower(Warrior player, int power, string choseSuperPower)
        {
            switch (choseSuperPower)
            {
                case "Hp":
                    ISuperPower superPowerHp = new SuperHp();
                    superPowerHp.AddSuperPower(player, power);
                    break;
                case "Defence":
                    ISuperPower superPowerDef = new SuperDefence();
                    superPowerDef.AddSuperPower(player, power);
                    break;
                case "Power":
                    ISuperPower superPowerPow = new SuperPower();
                    superPowerPow.AddSuperPower(player, power);
                    break;
                default: throw new Exception();
            }
        }
        static void Main(string[] args)
        {
            var a = new SuperPowerGenerator();
            Console.WriteLine(a.GenrateAmountSuperPower());
            Console.WriteLine(a.GenrateAmountSuperPower());
            Console.WriteLine("Game Start!\n");
            var generateSuperPower = new SuperPowerGenerator();
            Console.WriteLine("Choose first warrior: Bowman, Ninja, Samurai, Knight");
            string inputPlayer1 = Console.ReadLine();
            Warrior player1 = CreateWarrior(inputPlayer1);
            Console.WriteLine($"First player chose {inputPlayer1}");
            Console.WriteLine($"{player1.ToString()}");

            Console.WriteLine("\nChoose second warrior: Bowman, Ninja, Samurai, Knight");
            string inputPlayer2 = Console.ReadLine();
            Warrior player2 = CreateWarrior(inputPlayer2);
            Console.WriteLine($"Second player chose {inputPlayer2}");
            Console.WriteLine($"{player2.ToString()}\n");

            int player1SuperPower = generateSuperPower.GenrateAmountSuperPower();
            Console.WriteLine($"Generater Super Power for player 1 is {player1SuperPower} \nChoose which force it will be applied to : Hp, Defence, Power");
            string input1SuperPower = Console.ReadLine();
            AdditionalSuperPower(player1, player1SuperPower, input1SuperPower);


            int player2SuperPower = generateSuperPower.GenrateAmountSuperPower();
            Console.WriteLine($"Generater Super Power for player 2 is {player2SuperPower} \nChoose which force it will be applied to : Hp, Defence, Power");
            string input2SuperPower = Console.ReadLine();
            AdditionalSuperPower(player2, player2SuperPower, input2SuperPower);

            Console.WriteLine($"After Super Power: {player1.ToString()}");
            Console.WriteLine($"After Super Power: {player2.ToString()}\n");

            Battle.Fight(player1, player2);
            Console.WriteLine("Game Over!");

        }
    }
}
