using CurrencyManager.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CurrencyManager.DAL
{
    public class ParseXmlCurrency
    {
        public IEnumerable ParseXmlCurrencyMarket(XmlDocument xdoc)
        {
            List<CurrencyMarket> listCurrency = new List<CurrencyMarket>();
            CurrencyMarket currencyEnt;
            XmlElement xRoot = xdoc.DocumentElement;
            var dateXml = xRoot.Attributes.GetNamedItem("Date").Value;
            if (xRoot.ChildNodes.Count > 0)
            {
                foreach (XmlNode xNode in xRoot)
                {
                    currencyEnt = new CurrencyMarket();
                    currencyEnt.Date = DateTime.Parse(dateXml);
                    foreach (XmlNode item in xNode)
                    {
                        if (item.Name == "CharCode")
                        {
                            currencyEnt.Code = item.InnerText;
                        }
                        if (item.Name == "Value")
                        {
                            currencyEnt.Rate = Convert.ToSingle(item.InnerText/*.Replace(',', '.')*/);
                        }
                    }
                    yield return currencyEnt;
                    //listCurrency.Add(currencyEnt);
                }
            }
            //return listCurrency;
        }
    }
}
