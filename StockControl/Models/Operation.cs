using System;
using System.ComponentModel.DataAnnotations;
using StockControl.Models.Enum;

namespace StockControl.Models
{
    public class Operation
    {
        public int Id { get; set; }

        [Display(Name = "Date Trade")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "{0} is required !")]
        public DateTime DateTrade { get; set; }

        [Required(ErrorMessage = "{0} is required !")]
        public string Corretora { get; set; }

        [Required(ErrorMessage = "{0} is required !")]
        public string Stock { get; set; }

        [Display(Name = "Company Name")]
        [Required(ErrorMessage = "{0} is Requerid !")]
        public string CompanyName { get; set; }

        [Display(Name = "Type Operation")]
        [Required(ErrorMessage = "{0} is required !")]
        public TypeOperation TypeOperation { get; set; }

        [Required(ErrorMessage = "{0} is required !")]
        public int Amount { get; set; }

        [Display(Name = "Value Unit")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Required(ErrorMessage = "{0} is required !")]
        public double ValorUnit { get; set; }

        [Display(Name = "Total")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Required(ErrorMessage = "{0} is required !")]
        public double ValorTotalTraded { get; set; }

        [Display(Name = "Status Operation")]
        [Required(ErrorMessage = "{0} is required !")]
        public StatusOperation StatusOperation { get; set; }

        public Operation()
        {
        }

        public Operation(int id, DateTime dateTrade, string corretora, string stock, string companyName, TypeOperation typeOperation,
            int amount, double valorUnit, double valorTotalTraded, StatusOperation statusOperation)
        {
            Id = id;
            DateTrade = dateTrade;
            Corretora = corretora;
            CompanyName = companyName;
            Stock = stock;
            TypeOperation = typeOperation;
            Amount = amount;
            ValorUnit = valorUnit;
            ValorTotalTraded = valorUnit * amount;
            StatusOperation = statusOperation;
        }
    }
}

