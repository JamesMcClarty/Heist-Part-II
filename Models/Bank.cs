namespace heist_part_II
{
    public class Bank
    {
        public Bank (int _cash, int _alarm, int _vault, int _security){
            cashOnHand = _cash;
            alarmScore = _alarm;
            vaultScore = _vault;
            securityGuardScore = _security;
        }
        public int cashOnHand { get; set; }
        public int alarmScore { get; set; }
        public int vaultScore { get; set; }
        public int securityGuardScore { get; set; }
        public bool IsSecure()
        {
            if (alarmScore <= 0 && vaultScore <= 0 && securityGuardScore <= 0)
            {
                return false;
            }

            else
            {
                return true;
            }
        }
    }
}