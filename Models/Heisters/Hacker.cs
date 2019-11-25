using System;

namespace heist_part_II
{

    public class Hacker : IRobber
    {
        public Hacker(string _name, int _skillLevel, int _PercentageCut)
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
            _bank.alarmScore -= SkillLevel;
            Console.WriteLine($"{Name} hacks the bank's camera by {SkillLevel} points.");
        }
    }
}