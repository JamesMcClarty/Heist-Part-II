using System;
using System.Collections.Generic;
using System.Linq;

namespace heist_part_II
{
    class Program
    {
        static void Main(string[] args)
        {
            //Heisters
            Hacker Wolf = new Hacker("Wolf", 38, 15);
            Hacker Dallas = new Hacker("Dallas", 80, 30);
            Muscle Chains = new Muscle("Chains", 65, 20);
            Muscle Jacket = new Muscle("Jacket", 90, 40);
            LockSpecialist Houston = new LockSpecialist("Houston", 35, 10);
            LockSpecialist Hoxton = new LockSpecialist("Hoxton", 70, 30);

            //Rolodex
            List<IRobber> rolodex = new List<IRobber>();
            rolodex.Add(Wolf);
            rolodex.Add(Dallas);
            rolodex.Add(Chains);
            rolodex.Add(Jacket);
            rolodex.Add(Houston);
            rolodex.Add(Hoxton);

            Console.WriteLine("The heisters on the rolodex are: ");
            foreach (IRobber robber in rolodex)
            {
                Console.WriteLine($"{robber.Name}");
            }

            //Character Creation
            while (true)
            {

                int jobNum = 0;
                string name = "";
                int skillNum = -1;
                int cutNum = -1;

                Console.WriteLine("What is the name of your new heister? Enter nothing to stop.");
                name = Console.ReadLine();
                if (name == "")
                {
                    break;
                }

                while (jobNum <= 0 || jobNum > 3)
                {
                    Console.WriteLine("What profession is the heister in? The options are: ");
                    Console.WriteLine("1: Hacker");
                    Console.WriteLine("2: Muscle");
                    Console.WriteLine("3: LockSpecialist");
                    Console.WriteLine("Enter a number.");
                    try
                    {
                        jobNum = int.Parse(Console.ReadLine());
                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("Error. Try again.");
                    }
                    if (jobNum <= 0 || jobNum > 3)
                    {
                        Console.WriteLine("Sorry. That's not a valid job number.");
                    }
                }

                while (skillNum <= -1 || skillNum > 100)
                {
                    Console.WriteLine("Select a skill level between 0 to 100.");
                    try
                    {
                        skillNum = int.Parse(Console.ReadLine());
                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("Error. Try again.");
                    }
                    if (skillNum <= 0 || skillNum > 3)
                    {
                        Console.WriteLine("Sorry. That's not a valid skill number.");
                    }
                }

                while (cutNum <= -1 || cutNum > 100)
                {
                    Console.WriteLine("Select the percentage of their cut of the profits.");
                    try
                    {
                        cutNum = int.Parse(Console.ReadLine());
                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("Error. Try again.");
                    }
                    if (cutNum <= 0 || cutNum > 3)
                    {
                        Console.WriteLine("Sorry. That's not a valid cut number.");
                    }
                }

                switch (jobNum)
                {
                    case 1:
                        Hacker newHeister1 = new Hacker(name, skillNum, cutNum);
                        rolodex.Add(newHeister1);
                        break;
                    case 2:
                        Muscle newHeister2 = new Muscle(name, skillNum, cutNum);
                        rolodex.Add(newHeister2);
                        break;
                    case 3:
                        LockSpecialist newHeister3 = new LockSpecialist(name, skillNum, cutNum);
                        rolodex.Add(newHeister3);
                        break;
                }                                   
            }

            //Bank Creation
            Random random = new Random();
            Bank bank = new Bank(random.Next(50000,1000000), random.Next(0,100), random.Next(0,100), random.Next(0,100));
            


            Console.WriteLine("Bain did his research.");
            Console.WriteLine("The");

        }
    }
}