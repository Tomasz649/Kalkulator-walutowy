using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp4;

namespace WinFormsApp4
{
    //enum Currency
    //{
    //    PLN,
    //    EUR,
    //    USD,
    //    GBP
    //}
    internal class CurrencyExchange
    {
        //konstuktory - domyślny
        public CurrencyExchange()
        {
            GetFromAPI();
        }
        //Dictionary<Currency, double> rates = new Dictionary<Currency, double>()
        //{
        //    { Currency.PLN, 1.00 },
        //    { Currency.EUR, 4.19 },
        //    { Currency.USD, 3.62 },
        //    { Currency.GBP, 4.92 }
        //};
        List<Currency> currencies = new List<Currency>()
        {
            new Currency("polski złoty", "PLN", 1.00),
            new Currency("euro", "EUR", 4.19),
            new Currency("dolar amerykański", "USD", 3.62),
            new Currency("funt brytyjski", "GBP", 4.92)
        };

        public double ToPLN(double amount, Currency from)
        {
            return amount * from.rate;
        }

        public Currency? GetFromCode(string code)
        {
            Currency? currency = currencies.Find(c => c.code == code);
            if (currency == null) throw new Exception("Nie znaleziono waluty o podanym kodzie");
            return currency;
        }
        public void GetFromAPI()
        {
            string json;
            using (HttpClient client = new HttpClient())
            {
                json = client.GetStringAsync("https://api.nbp.pl/api/exchangerates/tables/A/").Result;
            }
            APIresponse response = JsonConvert.DeserializeObject<APIresponse[]>(json)[0];

            foreach (Rate rate in response.rates)
            {

                Currency? currency = currencies.Find(c => c.code == rate.code);
                if (currency != null)
                {
                    currency.rate = rate.mid;
                }
                else
                {
                    currencies.Add(new Currency(rate.currency, rate.code, rate.mid));
                }
            }
        }
        public List<Currency> GetCurrencies()
        {
            return currencies;
        }
        public double Convert(double amount, Currency from, Currency to)
        {
            if (from.code == "PLN" && to.code != "PLN")
            {
                double adjustedRate = to.rate * 1.02;
                double amountInPLN = amount; 
                return amountInPLN / adjustedRate;
            }
            else if (to.code == "PLN" && from.code != "PLN")
            {
                double adjustedRate = from.rate * 0.98;
                return amount * adjustedRate;
            }
            else
            {
                double amountInPLN = ToPLN(amount, from);
                return amountInPLN / to.rate;
            }
        }
    }
    
}