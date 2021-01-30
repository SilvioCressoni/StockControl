using System;
using StockControl.Models.Enum;

namespace StockControl.Models
{
    public class Operation
    {
        public int Id { get; set; }
        public DateTime DateTrade { get; set; }
        public string Corretora { get; set; }
        public TypeOperation TypeOperation { get; set; }
        public int Amount { get; set; }
        public double ValorUnit { get; set; }
        public double ValorTotalTraded { get; set; }
        public StatusOperation StatusOperation { get; set; }

        public Operation()
        {
        }
    }
}

