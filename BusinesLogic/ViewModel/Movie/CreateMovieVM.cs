using BusinesLogic.ViewModel.Actor;
using DAL.GeneralClass;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace BusinesLogic.ViewModel.Movie
{
    public class CreateMovieVM
    {
        [Required(ErrorMessage = "Wrong Name of Movie")]
        public string MovieName { get; set; }
        [Required(ErrorMessage = "Wrong duration of Movie"), Range(1, 400, ErrorMessage = "Wrong Duration")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "Wrong Description of movie"), MaxLength(200)]
        public string Desc { get; set; }

        [Required(ErrorMessage = "Wrong date"), DataType(DataType.Date)]
        public DateTime ReliseDate { get; set; }

        [Required(ErrorMessage = "Wrong Raiting"), Range(0, 10, ErrorMessage = "Wrong number")]
        public float Rating { get; set; }

        public IFormFile ImgFile { get; set; }

        public IFormFile VideoFile { get; set; }

        public IFormFile TrailerFile { get; set; }

        public ICollection<DAL.GeneralClass.Language> Language { get; set; }

        public ICollection<ActorVM> Actors { get; set; }

        public ICollection<DAL.GeneralClass.AudioLanguage> AudioLanguages { get; set; }

        public ICollection<DAL.GeneralClass.Category> Categories { get; set; }

        public ICollection<DAL.GeneralClass.Subtitle> Subtitles { get; set; }
    }
}
