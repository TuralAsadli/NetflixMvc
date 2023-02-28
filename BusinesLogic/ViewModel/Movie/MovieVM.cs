using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BusinesLogic.ViewModel.Movie
{
    public class MovieVM
    {
        [Required(ErrorMessage = "Movie Name is required")]
        public string MovieName { get; set; }
        

        [Required(ErrorMessage = "Description is required"), MaxLength(200)]
        public string Desc { get; set; }

        [Required(ErrorMessage = "Wrong date"), DataType(DataType.Date)]
        public DateTime ReliseDate { get; set; }

        public string? Raiting { get; set; }

        public string? Duration { get; set; }

        public IFormFile ImgFile { get; set; }

        public IFormFile VideoFile { get; set; }

        public IFormFile TrailerFile { get; set; }

        public ICollection<int> MovieLanguagesId { get; set; }

        public ICollection<int> MovieSubtitlesId { get; set; }

        public ICollection<int> MovieAudioLanguagesId { get; set; }

        public ICollection<int> MovieCategoriesId { get; set; }

        public ICollection<int> MovieActorsId { get; set; }
    }
}
