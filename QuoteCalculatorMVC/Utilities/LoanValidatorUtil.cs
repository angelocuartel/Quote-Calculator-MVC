namespace QuoteCalculatorMVC.Utilities
{
    public static class LoanValidatorUtil
    {
        private const short _legalAge = 18;
        public static bool IsLegalAge(DateTime birthDate)
        {
            DateTime dateNow = DateTime.Now;

            int ageByYear =  dateNow.Year - birthDate.Year;

            if(!((dateNow.Day >= birthDate.Day && dateNow.Month >= birthDate.Month) || dateNow.Month > birthDate.Month))
            {
                ageByYear--;
            }

            return ageByYear >= _legalAge;
        }

    }
}
