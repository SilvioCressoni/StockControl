using StockControl.Models.Enum;

namespace StockControl.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public string StockName { get; set; }
        public string NameCompany { get; set; }
        public StockSector Sector { get; set; }
        public Operation Operation { get; set; }

        public Stock()
        {
        }

        public Stock(int id, string stockName, string nameCompany, StockSector sector, Operation operation)
        {
            Id = id;
            StockName = stockName;
            NameCompany = nameCompany;
            Sector = sector;
            Operation = operation;
        }
    }
}
