using System.ComponentModel.DataAnnotations;

namespace NetflixMVC.ViewModel
{
    public class BuySubscribeVM
    {
        public int SubId { get; set; }

        [Required]
        [CreditCard]
        public string CreditCardNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }

        [Required]
        public string CVV { get; set; }

        public string? StripeToken { get; set; }
    }
}
