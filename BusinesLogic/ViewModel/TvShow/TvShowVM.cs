using BusinesLogic.ViewModel.TvShow.Season;
using DAL.TvShows;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLogic.ViewModel.TvShow
{
    public class TvShowVM
    {
        [Required(ErrorMessage = "TvShow Name is required")]
        public string TvShowName { get; set; }

        [Required(ErrorMessage = "Description is required"), MaxLength(200)]
        public string Desc { get; set; }

        [Required(ErrorMessage = "Wrong date"), DataType(DataType.Date)]
        public DateTime ReliseTime { get; set; }

        
        public string? rating { get; set; }

        public IFormFile ImgFile { get; set; }

        public ICollection<int> LanguagesIds { get; set; }
        public ICollection<int> SubtitleIds { get; set; }
        public ICollection<int> AudioLanguagesIds { get; set; }
        public ICollection<int> CategoriesIds { get; set; }
        public ICollection<int> ActorsIds { get; set; }


    }
}
