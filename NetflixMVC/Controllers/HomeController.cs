using BusinesLogic.Utilites;
using BusinesLogic.ViewModel.Movie;
using BusinesLogic.ViewModel.Settings;
using BusinesLogic.ViewModel.TvShow;
using DAL.Movies;
using DAL.TvShows;
using Interfaces.Repository.BaseRepository;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using NetflixMVC.Models;
using NetflixMVC.ViewModel;
using System.Diagnostics;

namespace NetflixMVC.Controllers
{
    public class HomeController : Controller
    {
       
        IMovieService<MovieVM> _db;
        ITvShowService<TvShowVM> _tvShows;
        ISettingsService<SettingVM> _setings;
        IUserFeedbackService<UserFeedBackVM> _userFeedback;
        public HomeController(IMovieService<MovieVM> db, ITvShowService<TvShowVM> tvShows, ISettingsService<SettingVM> setings, IUserFeedbackService<UserFeedBackVM> userFeedback)
        {
            _db = db;
            _tvShows = tvShows;
            _setings = setings;
            _userFeedback = userFeedback;
        }

        public async Task<IActionResult> Index()
        {
            MovieAndTvShowVM movieAndTv = new MovieAndTvShowVM();
            movieAndTv.Movies = (List<Movie>)_db.GetAllWithInclude();
            movieAndTv.TvShows = (List<TvShow>)_tvShows.GetAllWithInclude();
            return View(movieAndTv);
        }
       
       

        public IActionResult Search(string? query)
        {
            if (query == null)
            {
                return RedirectToAction(nameof(Index));
            }
            SearchVM searchVM = new SearchVM();

            searchVM.Movies = (List<Movie>)_db.Search(query);
            searchVM.TvShows = (List<TvShow>)_tvShows.Search(query);
            return View(searchVM);
        }

        public IActionResult ContactUs()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ContactUs(UserFeedBackVM userFeedBackVM)
        {
            if (!ModelState.IsValid)
            {
                return View(userFeedBackVM);
            }
            _userFeedback.Create(userFeedBackVM);
            return RedirectToAction(nameof(Index), "Home");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}