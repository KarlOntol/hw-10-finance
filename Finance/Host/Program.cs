namespace Finance
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string fileName = "rates.json";
            // await CurrencyParser.GetData("USD", 2022, fileName);
            await Stonks.GetData(fileName);
        }
    }
}
