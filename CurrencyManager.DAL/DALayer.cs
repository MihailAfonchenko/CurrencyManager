using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyManager.Entities;

namespace CurrencyManager.DAL
{
    public class DALayer
    {
        private RequestCurrencyAPI _requestCur;
        private ParseXmlCurrency _parseCur;
        private RequestLibraryAPI _requestLib;
        private ParseXmlLibrary _parseLib;

        public DALayer()
        {
            _parseLib = new ParseXmlLibrary();
            _requestLib = new RequestLibraryAPI();
            _requestCur = new RequestCurrencyAPI();
            _parseCur = new ParseXmlCurrency();
        }

        public Task QueryAddCurrencyAndLibrary()
        {
            try
            {
                using (CurrencyMarketContext db = new CurrencyMarketContext())
                {
                    Dictionary<string, MarketLibrary> dictCode = new Dictionary<string, MarketLibrary>();
                    var xmlDataLib = _requestLib.getDataAPI();
                    var listLibrary = _parseLib.ParseXmlMarketLib(xmlDataLib);
                    foreach (var item in listLibrary)
                        if (!dictCode.Keys.Contains(item.CharCode))
                            dictCode.Add(item.CharCode, item);

                    foreach (MarketLibrary item in listLibrary)
                        if (!String.IsNullOrWhiteSpace(item.CharCode))
                            db.Libraries.Add(item);

                    var xmlDataCur = _requestCur.getDataAPI();
                    foreach (CurrencyMarket item in _parseCur.ParseXmlCurrencyMarket(xmlDataCur))
                    {
                        if (dictCode.ContainsKey(item.Code))
                            item.Library = dictCode[item.Code];
                        db.Currencies.Add(item);
                    }

                    db.SaveChanges();
                }
                return Task.CompletedTask;
            }
            catch (Exception exc)
            {
                return Task.FromException(exc);
            }
        }

        //public Task QueryAddLibrary()
        //{
        //    try
        //    {
        //        var xmlData = _requestCur.getDataAPI();
        //        using (CurrencyMarketContext db = new CurrencyMarketContext())
        //        {
        //            foreach (MarketLibrary item in _parseLib.ParseXmlMarketLib(xmlData))
        //                db.Libraries.Add(item);

        //            db.SaveChanges();
        //        }
        //        return Task.CompletedTask;
        //    }
        //    catch (Exception exc)
        //    {
        //        return Task.FromException(exc);
        //    }
        //}
    }
}
