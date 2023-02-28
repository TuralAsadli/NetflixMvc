using System.ComponentModel.DataAnnotations;

namespace NetflixMVC.ViewModel
{
    public class UserLogInVM
    {
        [Required]
        public string UserNameOdEmail { get; set; }
        [DataType(DataType.Password),Required]
        public string Password { get; set; }
        public bool IsPersistance { get; set; }

    }
}
