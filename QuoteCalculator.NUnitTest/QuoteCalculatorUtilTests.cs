namespace QuoteCalculator.NUnitTest
{
    public class QuoteCalculatorUtilTests
    {
        //All Expected Values are from PMT function


        [Test]
        public void GetTotalPayment_EqualTest1()
        {
            var monthsToPay = 24;
            var result = QuoteCalculatorMVC.Utilities.QuoteCalculatorUtil.GetTotalPayment(5000, monthsToPay);

            Assert.AreEqual(Math.Round(230.82,2), Math.Round(GetPaymentWithoutEstablishmentFee(result.TotalRepayments, monthsToPay), 2));
        }

        [Test]
        public void GetTotalPayment_EqualTest2()
        {
            var monthsToPay = 6;
            var result = QuoteCalculatorMVC.Utilities.QuoteCalculatorUtil.GetTotalPayment(4336, monthsToPay);

            Assert.AreEqual(Math.Round(743.98, 2), Math.Round(GetPaymentWithoutEstablishmentFee(result.TotalRepayments, monthsToPay), 2));
        }

        [Test]
        public void GetTotalPayment_EqualTest3()
        {
            var monthsToPay = 10;
            var result = QuoteCalculatorMVC.Utilities.QuoteCalculatorUtil.GetTotalPayment(1200, monthsToPay);

            Assert.AreEqual(Math.Round(125.59, 2), Math.Round(GetPaymentWithoutEstablishmentFee(result.TotalRepayments, monthsToPay), 2));
        }

        [Test]
        public void GetTotalPayment_EqualTest4()
        {
            var monthsToPay = 15;
            var result = QuoteCalculatorMVC.Utilities.QuoteCalculatorUtil.GetTotalPayment(6522, monthsToPay);
            Assert.AreEqual(Math.Round(464.47, 2), Math.Round(GetPaymentWithoutEstablishmentFee(result.TotalRepayments,monthsToPay), 2));
        }

        private decimal GetPaymentWithoutEstablishmentFee(decimal totalRepayments, int monthsToPay)
        => (totalRepayments - 300) / monthsToPay;
    }
}