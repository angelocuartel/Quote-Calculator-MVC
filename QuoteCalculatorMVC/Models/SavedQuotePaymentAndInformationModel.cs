namespace QuoteCalculatorMVC.Models
{
    public class SavedQuotePaymentAndInformationModel
    {
        public QuoteInformationModel? QuoteInformation { get; set; }
        public TotalPaymentModel? QuotePayment { get; set; }
    }
}
