using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLogic.ViewModel.TvShow.Seria
{
    public class SeriaVM
    {
        [Required(ErrorMessage = "Seria Name is required")]
        public string SeriesName { get; set; }

        [Required(ErrorMessage = "Duration is required"), Range(1, 400, ErrorMessage = "Wrong Duration")]
        public string duration { get; set; }
        public IFormFile HoverImgFile { get; set; }
        public IFormFile VideoFile { get; set; }

        [NotMapped]
        public int SeasonId { get; set; }
        [NotMapped]
        public DAL.TvShows.Season Seasons { get; set; }
    }
}
