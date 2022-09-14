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
            var itemsList = CountStonks(CurrenceDataItems);
            var tuple = GetMinAndMaxItems(itemsList);
            Console.WriteLine($"Минимальное значение баланса:\n{tuple.Item1},\nМаксимальное значение баланса:\n{tuple.Item2}");

        }

        public static List<ReportItems> CountStonks(List<CurrencyData> items)
        {
            var reportList = new List<ReportItems>();

            decimal balance;
            for(int i = 0; i < items.Count - 3; i++)
            {
                balance = 10000m;
                decimal firBalance = balance * items[i].Cur_OfficialRate;

                for (int k = i + 1; k < items.Count - 2; k++)
                {
                    decimal secBalance = firBalance / items[k].Cur_OfficialRate;

                    for (int n = k + 1; n < items.Count - 1; n++)
                    {
                        decimal thiBalance = secBalance * items[n].Cur_OfficialRate;

                        for (int m = n + 1; m < items.Count; m++)
                        {
                            decimal fouBalance = thiBalance / items[m].Cur_OfficialRate;
                            reportList.Add(
                                new ReportItems() 
                                    {
                                        firstDate = items[i].Date,
                                        secondDate = items[k].Date,
                                        thirdDate = items[n].Date,
                                        fourthDate = items[m].Date,
                                        totalBalance = fouBalance
                                }
                                );
                        }
                    }
                }
            }

            return reportList;
        }

        public static (ReportItems, ReportItems) GetMinAndMaxItems(List<ReportItems> items)
        {
            ReportItems minItem = items[0];
            ReportItems maxItem = items[0];
            foreach(var item in items)
            {
                if(item < minItem)
                {
                    minItem = item;
                }
                else if(item > maxItem)
                {
                    maxItem = item;
                }
            }
            return (minItem, maxItem);
        }
    }
}