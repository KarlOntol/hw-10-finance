namespace Finance
{
    public class ReportItems
    {
        public DateTime firstDate { get; set; }
        public DateTime secondDate { get; set; }
        public DateTime thirdDate { get; set; }
        public DateTime fourthDate { get; set; }
        public decimal totalBalance { get; set; }

        public override string ToString()
        {
            return($"Первая дата (продажа) - {firstDate}, Вторая дата (покупка) - {secondDate}, " +
                   $"Третья дата (продажа) - {thirdDate}, Четвертая дата (покупка) - {fourthDate}, " +
                   $"Баланс - {totalBalance}");
        }

        public static bool operator >(ReportItems item1, ReportItems item2)
        {
            return item1.totalBalance > item2.totalBalance;
        }
        public static bool operator <(ReportItems item1, ReportItems item2)
        {
            return item1.totalBalance < item2.totalBalance;        
        }
    }
}
