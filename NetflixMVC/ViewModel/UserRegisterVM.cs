using DAL.Entities.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetflixMVC.ViewModel
{
    public class UserRegisterVM
    {
        [Required, MaxLength(25, ErrorMessage ="Your name is long")]
        public string UserName { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, DataType(DataType.Password),Compare(nameof(Password),ErrorMessage = "the passwords don't match")]
        public string RepitPassword { get; set; }

        public int SubscribeId { get; set; }

    }
}
