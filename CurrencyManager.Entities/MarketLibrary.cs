using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyManager.Entities
{
    [Table("MarketLibrary")]
    public class MarketLibrary
    {
        private string id;
        private string name;
        private string engName;
        private int numCode;
        private string charCode;


        [Required]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        [Required]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        [Required]
        public string EngName
        {
            get { return engName; }
            set { engName = value; }
        }
        [Required]
        public int NumCode
        {
            get { return numCode; }
            set { numCode = value; }
        }
        [Required]
        public string CharCode
        {
            get { return charCode; }
            set { charCode = value; }
        }
        public ICollection<CurrencyMarket> CurrencyMarkets { get; set; }

        public MarketLibrary()
        {
            CurrencyMarkets = new List<CurrencyMarket>();
        }
    }
}
