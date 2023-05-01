namespace QuoteCalculatorMVC.Models
{
    public class QuoteInformationModel
    {
        public int Id { get; set; }
        public decimal AmountRequired { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Term { get; set; }
        public string FirstName { get; set; } = string.Empty; 
        public string LastName { get; set; } = string.Empty; 
        public DateTime DateOfBirth { get; set; }
        public string MobileNo { get; set; } = string.Empty; 
        public string Email { get; set; } = string.Empty; 
    } 
}
