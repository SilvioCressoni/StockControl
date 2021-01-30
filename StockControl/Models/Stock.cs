
using StockControl.Models.Enum;

namespace StockControl.Models
{
    public class Stock
    {
        public int IdStock { get; set; }
        public string NameCompany { get; set; }
        public StockSector Sector { get; set; }

        public Stock()
        {
        }
    }
}
