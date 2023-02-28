using System.ComponentModel.DataAnnotations;

namespace BusinesLogic.ViewModel.Actor
{
    public class ActorVM
    {
        [Required(ErrorMessage = "Pls Write Name"), MaxLength(25, ErrorMessage = "Very long name of Actor")]
        public string ActorName { get; set; }

        [Required(ErrorMessage = "Pls Write Surname"), MaxLength(25, ErrorMessage = "Very long name of Actor")]
        public string ActorSurname { get; set; }
    }
}
