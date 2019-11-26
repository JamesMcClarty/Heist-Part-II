using System;

namespace heist_part_II
{

    public class Muscle : IRobber
    {
        public Muscle(string _name, int _skillLevel, int _PercentageCut)
        {
            Name = _name;
            SkillLevel = _skillLevel;
            PercentageCut = _PercentageCut;
        }
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public void PerformSkill(Bank _bank)
        {
            _bank.securityGuardScore -= SkillLevel;
            Console.WriteLine($"{Name} removed the security guards by {SkillLevel} points.");
        }

        public void PrintProfile (){
            Console.WriteLine($"{Name} is a Muscle that has the skill level of {SkillLevel} and demands a cut of {PercentageCut}");
        }
    }
}