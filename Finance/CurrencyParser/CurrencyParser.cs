using System.Text.Json;

namespace Finance
{
    public static class CurrencyParser
    {
        static readonly HttpClient client;

        static CurrencyParser()
        {
            client = new HttpClient();
        }

        public static async Task GetData(string currency, int year, string fileName)
        {
            int lastMonth = 12;
            if (year > DateTime.Now.Year)
            {
                throw new Exception("Отчетный год не может быть больше текущего.");
            }
            else if (year == DateTime.Now.Year)
            {
                lastMonth = DateTime.Now.Month;
            }

            string url;
            using (StreamWriter sw = new StreamWriter(fileName, true, System.Text.Encoding.Default))
            {
                for (int i = 1; i <= lastMonth; i++)
                {
                    try
                    {
                        url = @"https://www.nbrb.by/api/exrates/rates/" + $"{currency}" + "?parammode=2&ondate=" + $"{year}" + "-" + $"{i}";
                        var response = await client.GetAsync(url);
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(responseBody);
                        await sw.WriteLineAsync(responseBody);
                    }
                    catch (HttpRequestException e)
                    {
                        Console.WriteLine("Ошибка запроса страницы");
                    }
                }
            }
        }
    }
}
