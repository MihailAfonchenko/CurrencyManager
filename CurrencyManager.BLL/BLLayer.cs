using CurrencyManager.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyManager.BLL
{
    public class BLLayer
    {
        private DALayer _currencyDAL;
        public BLLayer()
        {
            _currencyDAL = new DALayer();
        }

        public Task QueryCurrencyToAPI()
        {
            return _currencyDAL.QueryAddCurrencyAndLibrary();
        }

    }
}
