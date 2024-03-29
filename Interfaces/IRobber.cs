namespace heist_part_II
{
    public interface IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public void PerformSkill(Bank _bank);
        public void PrintProfile();
    }
}