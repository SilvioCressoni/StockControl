using System;
namespace StockControl.Models
{
    public class TaxOperation
    {
        public int Id { get; set; }
        public double ValorCblc { get; set; }
        public double ValorEmolumentos { get; set; }
        public double ValorCorretagem { get; set; }
        public double ValorIss { get; set; }
        public double ValorIrrf { get; set; }
        public double ValorTotalTax { get; set; }
        

        public TaxOperation()
        {
        }

        public TaxOperation(int id, double valorCblc, double valorEmolumentos, double valorCorretagem,
            double valorIss, double valorIrrf)
        {
            Id = id;
            ValorCblc = valorCblc;
            ValorEmolumentos = valorEmolumentos;
            ValorCorretagem = valorCorretagem;
            ValorIss = valorIss;
            ValorIrrf = valorIrrf;
      
        }
    }
}
