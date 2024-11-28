using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    Dictionary<string, float> tassiConversione;

    public float ConvertiValuta(float importo, valute da, valute a)
    {
        if (da == a) return importo;

        float importoEUR = importo / tassiConversione.ElementAt((int)da).Value;

        return importoEUR * tassiConversione.ElementAt((int)a).Value;
    }

    public string[] TassiConversione()
    {
        return tassiConversione
            .Where(w=>w.Key != "EUR")
            .Select(s => "1 EUR = " + s.Value + " " + s.Key)
            .ToArray();
    }

    public Service()
    {
        tassiConversione = new Dictionary<string, float>();
        tassiConversione.Add("EUR", 1f);
        tassiConversione.Add("ITL", 1936.27f);
        tassiConversione.Add("DEM", 1.95583f);
        tassiConversione.Add("FRF", 6.55957f);
    }
}
