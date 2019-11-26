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
                    if (skillNum <= 0 || skillNum > 100)
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
                    if (cutNum <= 0 || cutNum > 100)
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
            Bank bank = new Bank(random.Next(50000, 1000000), random.Next(0, 100), random.Next(0, 100), random.Next(0, 100));
            Dictionary<string, int> recon = new Dictionary<string, int>();
            recon.Add("Alarm", bank.alarmScore);
            recon.Add("Security Guards", bank.securityGuardScore);
            recon.Add("Vault", bank.vaultScore);
            recon.OrderBy(re => re.Value);

            Console.WriteLine("Bain did his research.");
            Console.WriteLine($"The bank's strength is in {recon.Last().Key}");
            Console.WriteLine($"But the bank's weakness is in {recon.First().Key}");
            Console.WriteLine("///////////////////////////////////////////////////");

            Console.WriteLine("The people in your group are:");
            int i = 1;
            foreach (IRobber heister in rolodex)
            {
                Console.Write($"{i}. ");
                heister.PrintProfile();
                i++;
            }

            List<IRobber> chosenRobbers = new List<IRobber>();

            while (true)
            {
                Console.WriteLine("Please type in the number of heister you'd like to hire. Enter nothing to continue.");
                try
                {
                    string input = Console.ReadLine();
                    if(input == ""){
                        break;
                    }
                    int chosenNum = int.Parse(input) - 1;
                    chosenRobbers.Add(rolodex[chosenNum]);
                    Console.WriteLine($"{rolodex[chosenNum].Name} has been added.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Sorry. That won't work. Try again.");
                }
            }
            foreach (IRobber robber in chosenRobbers)
            {
                robber.PerformSkill(bank);
            }

            if (bank.IsSecure() == false)
            {
                Console.WriteLine("Heist Successful! Just as planned!");
                Console.WriteLine($"You all scored {bank.cashOnHand}!");
                foreach (IRobber robber in chosenRobbers)
                {
                    decimal pay = bank.cashOnHand * robber.PercentageCut / 100;
                    Console.WriteLine($"{robber.Name} earned {pay}");
                    bank.cashOnHand = bank.cashOnHand - pay;
                }
                Console.WriteLine($"You earned {bank.cashOnHand}.");
            }

            else if (bank.IsSecure() == true)
            {
                Console.WriteLine("You've all been apprehended! Try again when Bain bails you out.");
            }
        }

    }
}