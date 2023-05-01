using QuoteCalculatorMVC.Models;

namespace QuoteCalculatorMVC.Utilities
{
    public static class QuoteCalculatorUtil
    {
        private const decimal _interestRate = 0.1004M;
        private const decimal _establishmentFee = 300;

        private const int _monthsPerYear = 12;

        public static TotalPaymentModel GetTotalPayment(decimal principal, int monthsToPay)
        {
            decimal monthlyPayments = (principal * (_interestRate/_monthsPerYear) / (decimal)(1 - Math.Pow(1+(double)(_interestRate/_monthsPerYear) , (-_monthsPerYear) * ((double)monthsToPay / _monthsPerYear))));

            decimal totalRepayments = (monthlyPayments * monthsToPay) + _establishmentFee;

            decimal interestToPay = (totalRepayments - principal) - _establishmentFee;

            return new TotalPaymentModel
            {
                InterestFee = interestToPay,
                EstablishmentFee = _establishmentFee,
                Principal = principal,
                TotalRepayments = totalRepayments,
                MonthlyPayments = totalRepayments / monthsToPay
            };
        }
    }
}
