namespace QuoteCalculatorMVC.Models
{
    public class TotalPaymentModel
    {
        public decimal TotalRepayments { get; set; }
        public decimal Principal { get; set; }
        public decimal EstablishmentFee { get; set; }
        public decimal MonthlyPayments { get; set; }
        public decimal InterestFee { get; set; }
    }
}
