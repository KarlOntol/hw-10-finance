namespace Finance
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string fileName = "rates_for_month.json";
            await CurrencyParser.GetData("USD", 2022, fileName);
            await Stonks.GetData(fileName);
        }
    }
}
