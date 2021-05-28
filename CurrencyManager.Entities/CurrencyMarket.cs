using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyManager.Entities
{
    [Table("CurrencyMarket")]
    public class CurrencyMarket
    {
        private int id;
        private string code;
        private DateTime date;
        private float rate;

        [Key]
        [Index]
        [Required]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [Required]
        public DateTime Date
        {
            get { return date; }
            set { date = value.Date; }
        }
        [Required]
        public string Code
        {
            get { return code; }
            set { code = value; }
        }
        [Required]
        public float Rate
        {
            get { return rate; }
            set { rate = value; }
        }

        public int? LibraryID { get; set; }
        public MarketLibrary Library { get; set; }
    }
}
