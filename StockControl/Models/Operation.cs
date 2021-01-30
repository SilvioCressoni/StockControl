using System;
using System.Collections.Generic;
using StockControl.Models.Enum;

namespace StockControl.Models
{
    public class Operation
    {
        public int Id { get; set; }
        public DateTime DateTrade { get; set; }
        public string Corretora { get; set; }
        public ICollection<Stock> StockList { get; set; } = new List<Stock>();
        public TypeOperation TypeOperation { get; set; }
        public int Amount { get; set; }
        public double ValorUnit { get; set; }
        public double ValorTotalTraded { get; set; }
        public StatusOperation StatusOperation { get; set; }

        public TaxOperation TaxOperation { get; set; }

        public Operation()
        {
        }

        public Operation(int id, DateTime dateTrade, string corretora, TypeOperation typeOperation,
            int amount, double valorUnit, double valorTotalTraded, StatusOperation statusOperation,
            TaxOperation taxOperation)
        {
            Id = id;
            DateTrade = dateTrade;
            Corretora = corretora;
            TypeOperation = typeOperation;
            Amount = amount;
            ValorUnit = valorUnit;
            ValorTotalTraded = valorTotalTraded;
            StatusOperation = statusOperation;
            TaxOperation = taxOperation;
        }
    }
}

