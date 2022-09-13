using System.Text.Json;

namespace Finance
{
    public static class Stonks
    {
        public static async Task GetData(string fileName)
        {
            List<CurrencyData> CurrenceDataItems = new List<CurrencyData>();
            using (StreamReader sr = new StreamReader(fileName, System.Text.Encoding.Default))
            {
                string? line;
                while ((line = await sr.ReadLineAsync()) != null)
                {
                    var data = JsonSerializer.Deserialize<CurrencyData>(line);
                    CurrenceDataItems.Add(data);
                }
            }
            CountStonks(CurrenceDataItems);
        }

        // продажа - покупка - продажа - покупка 
        public static void CountStonks(List<CurrencyData> items)
        {
            for(int i = 0; i < items.Count - 3; i++)
            {
                // Продаем 1

                for(int k = i + 1; k < items.Count - 2; k++)
                {
                    // Покупаем 2

                    for(int n = k + 1; n < items.Count - 1; n++)
                    {
                        // Продаем 3

                        for (int m = n + 1; n < items.Count; m++)
                        {
                            // Покупаем 4


                        }
                    }
                }
            }
        }
    }
}