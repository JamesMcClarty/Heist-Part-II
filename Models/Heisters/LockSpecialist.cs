using System;

namespace heist_part_II
{

    public class LockSpecialist : IRobber
    {
        public LockSpecialist(string _name, int _skillLevel, int _PercentageCut)
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
            _bank.vaultScore -= SkillLevel;
            Console.WriteLine($"{Name} picks the lock of the vault by {SkillLevel} points.");
        }
    }
}