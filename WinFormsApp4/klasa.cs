using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp4;

using Newtonsoft.Json;
using System.Collections.Generic;
using System.Security.Authentication;

enum Currency
{
    USD,
    EUR,
    PLN,
    GBP
}


internal class Klasa
{
    public Klasa()
    {
        GetFromAPI();
    }

    Dictionary<Currency, double> rates = new Dictionary<Currency, double>
    {
        { Currency.USD, 4.00 },
        { Currency.EUR, 4.29 },
        { Currency.PLN, 1.00 },
        { Currency.GBP, 4.82 }
        
    };


    public double toPLN(double amount, Currency from)
    {
        return amount * rates[from];

    }
    public void GetFromAPI()
    {
        string json;

        using (HttpClient client = new HttpClient())
        {
            json = client.GetStringAsync("https://api.nbp.pl/api/exchangerates/tables/A/").Result;
        }

        APIresponse response = JsonConvert.DeserializeObject<APIresponse[]>(json)[0];

        rates[Currency.USD] = response.rates[1].mid;
        rates[Currency.EUR] = response.rates[7].mid;
        rates[Currency.GBP] = response.rates[10].mid;
    }

}




