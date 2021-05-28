using CurrencyManager.BLL;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyManager.Jobs
{
    public class RequestCurrency : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            var _provider = new BLLayer();
            await _provider.QueryCurrencyToAPI();
        }
    }
}
