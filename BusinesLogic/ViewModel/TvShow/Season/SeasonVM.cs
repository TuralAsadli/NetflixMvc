using DAL.TvShows;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLogic.ViewModel.TvShow.Season
{
    public class SeasonVM
    {
        [Required(ErrorMessage = "Season Name is required")]
        public string SeasonName { get; set; }

        [Required(ErrorMessage = "Wrong date"), DataType(DataType.Date)]
        public DateTime ReliseTime { get; set; }

        [Required(ErrorMessage = "Wrong Raiting"), Range(0, 10, ErrorMessage = "Raiting can be between 0 - 10")]
        public float Rating { get; set; }

        public IFormFile TrailerVideoFile { get; set; }

        [NotMapped]
        public int TvshowId { get; set; }
        [NotMapped]
        public DAL.TvShows.TvShow TvShows { get; set; }
    }
}
