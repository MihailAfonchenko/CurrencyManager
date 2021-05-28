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
    public class ParseXmlLibrary
    {
        public List<MarketLibrary> ParseXmlMarketLib(XmlDocument xdoc)
        {
            List<MarketLibrary> listMarketLib = new List<MarketLibrary>();
            MarketLibrary marketLibEnt;
            XmlElement xRoot = xdoc.DocumentElement;
            if (xRoot.ChildNodes.Count > 0)
            {
                foreach (XmlNode xNode in xRoot)
                {
                    marketLibEnt = new MarketLibrary();
                    marketLibEnt.Id = xNode.Attributes.GetNamedItem("ID").Value;
                    foreach (XmlNode item in xNode)
                    {
                        switch (item.Name)
                        {
                            case ("Name"):
                                marketLibEnt.Name = item.InnerText;
                                break;
                            case ("EngName"):
                                marketLibEnt.EngName = item.InnerText;
                                break;
                            case ("ISO_Num_Code"):
                                marketLibEnt.NumCode = !String.IsNullOrEmpty(item.InnerText) ? int.Parse(item.InnerText) : 0;
                                break;
                            case ("ISO_Char_Code"):
                                marketLibEnt.CharCode = item.InnerText;
                                break;
                        }
                    }
                    //yield return marketLibEnt;
                    listMarketLib.Add(marketLibEnt);
                }
            }
            return listMarketLib;
        }
    }
}
