using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using StockControl.Models.Enum;

namespace StockControl.Models
{
    public class Operation
    {
        public int Id { get; set; }

        [Display(Name = "Date Trade")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime DateTrade { get; set; }

        public string Corretora { get; set; }

        public ICollection<Stock> StockList { get; set; } = new List<Stock>();

        [Display(Name = "Type Operation")]
        public TypeOperation TypeOperation { get; set; }

        public int Amount { get; set; }

        [Display(Name = "Value Unit")]
        public double ValorUnit { get; set; }

        [Display(Name = "Total")]
        public double ValorTotalTraded { get; set; }

        [Display(Name = "Status Operation")]
        public StatusOperation StatusOperation { get; set; }

        [Display(Name = "Tax Operation")]
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

