using BusinesLogic.Utilites;
using BusinesLogic.ViewModel.Actor;
using BusinesLogic.ViewModel.AudioLanguage;
using BusinesLogic.ViewModel.Category;
using BusinesLogic.ViewModel.Language;
using BusinesLogic.ViewModel.Movie;
using BusinesLogic.ViewModel.Subtitle;
using BusinesLogic.ViewModel.TvShow;
using DAL.GeneralClass;
using DAL.Movies;
using DAL.TvShows;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System.Security.Principal;

namespace NetflixMVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class TvShowController : Controller
    {
        ITvShowService<TvShowVM> _db;
        ICategoryService<CategoryVM> _categories;
        IActorService<ActorVM> _actors;
        ILanguageService<LanguageVM> _language;
        IAudioLanguageService<AudioLanguageVM> _audioLanguages;
        ISubtitleService<SubtitleVM> _subtitles;

        public TvShowController(ITvShowService<TvShowVM> db, ICategoryService<CategoryVM> categories, IActorService<ActorVM> actors, ILanguageService<LanguageVM> language, IAudioLanguageService<AudioLanguageVM> audioLanguages, ISubtitleService<SubtitleVM> subtitles)
        {
            _db = db;
            _categories = categories;
            _actors = actors;
            _language = language;
            _audioLanguages = audioLanguages;
            _subtitles = subtitles;
        }

        public IActionResult Index()
        {
            return View(_db.GetWithId());
        }

        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_categories.GetWithId().ToList(), nameof(Category.Id), nameof(Category.CategoryName));
            ViewBag.Actors = new SelectList(_actors.GetWithId().ToList(), nameof(Actor.Id), nameof(Actor.ActorName));
            ViewBag.Subtitles = new SelectList(_subtitles.GetWithId().ToList(), nameof(Subtitle.Id), nameof(Subtitle.SubtitleName));
            ViewBag.Language = new SelectList(_language.GetWithId().ToList(), nameof(Language.Id), nameof(Language.LanguageName));
            ViewBag.AudioLanguages = new SelectList(_audioLanguages.GetWithId().ToList(), nameof(AudioLanguage.Id), nameof(AudioLanguage.AudioName));


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TvShowVM tvshow)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = new SelectList(_categories.GetWithId().ToList(), nameof(Category.Id), nameof(Category.CategoryName));
                ViewBag.Actors = new SelectList(_actors.GetWithId().ToList(), nameof(Actor.Id), nameof(Actor.ActorName));
                ViewBag.Subtitles = new SelectList(_subtitles.GetWithId().ToList(), nameof(Subtitle.Id), nameof(Subtitle.SubtitleName));
                ViewBag.Language = new SelectList(_language.GetWithId().ToList(), nameof(Language.Id), nameof(Language.LanguageName));
                ViewBag.AudioLanguages = new SelectList(_audioLanguages.GetWithId().ToList(), nameof(AudioLanguage.Id), nameof(AudioLanguage.AudioName));
                return View(tvshow);
            }
            if (!tvshow.ImgFile.CheckImgSize())
            {
                ViewBag.Categories = new SelectList(_categories.GetWithId().ToList(), nameof(Category.Id), nameof(Category.CategoryName));
                ViewBag.Actors = new SelectList(_actors.GetWithId().ToList(), nameof(Actor.Id), nameof(Actor.ActorName));
                ViewBag.Subtitles = new SelectList(_subtitles.GetWithId().ToList(), nameof(Subtitle.Id), nameof(Subtitle.SubtitleName));
                ViewBag.Language = new SelectList(_language.GetWithId().ToList(), nameof(Language.Id), nameof(Language.LanguageName));
                ViewBag.AudioLanguages = new SelectList(_audioLanguages.GetWithId().ToList(), nameof(AudioLanguage.Id), nameof(AudioLanguage.AudioName));
                ModelState.AddModelError("ImgFile", "Wrong img size");
                return View(tvshow);
            }
            if (!tvshow.ImgFile.CheckImgFileType())
            {
                ViewBag.Categories = new SelectList(_categories.GetWithId().ToList(), nameof(Category.Id), nameof(Category.CategoryName));
                ViewBag.Actors = new SelectList(_actors.GetWithId().ToList(), nameof(Actor.Id), nameof(Actor.ActorName));
                ViewBag.Subtitles = new SelectList(_subtitles.GetWithId().ToList(), nameof(Subtitle.Id), nameof(Subtitle.SubtitleName));
                ViewBag.Language = new SelectList(_language.GetWithId().ToList(), nameof(Language.Id), nameof(Language.LanguageName));
                ViewBag.AudioLanguages = new SelectList(_audioLanguages.GetWithId().ToList(), nameof(AudioLanguage.Id), nameof(AudioLanguage.AudioName));

                ModelState.AddModelError("ImgFile", "Wrong Img Type");
                return View(tvshow);
            }

            tvshow.rating = await ImdbApi.GetRating(tvshow.TvShowName);

            _db.Create(tvshow);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var res = _db.FindById(id);
            if (res == null)
            {
                return BadRequest();
            }
            _db.Remove(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {
            var res = _db.FindById(id);
            if (res == null)
            {
                return BadRequest();
            }

            ViewBag.Categories = new SelectList(_categories.GetWithId().ToList(), nameof(Category.Id), nameof(Category.CategoryName));
            ViewBag.Actors = new SelectList(_actors.GetWithId().ToList(), nameof(Actor.Id), nameof(Actor.ActorName));
            ViewBag.Subtitles = new SelectList(_subtitles.GetWithId().ToList(), nameof(Subtitle.Id), nameof(Subtitle.SubtitleName));
            ViewBag.Language = new SelectList(_language.GetWithId().ToList(), nameof(Language.Id), nameof(Language.LanguageName));
            ViewBag.AudioLanguages = new SelectList(_audioLanguages.GetWithId().ToList(), nameof(AudioLanguage.Id), nameof(AudioLanguage.AudioName));

            return View(res);
            
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, TvShowVM tvShow)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = new SelectList(_categories.GetWithId().ToList(), nameof(Category.Id), nameof(Category.CategoryName));
                ViewBag.Actors = new SelectList(_actors.GetWithId().ToList(), nameof(Actor.Id), nameof(Actor.ActorName));
                ViewBag.Subtitles = new SelectList(_subtitles.GetWithId().ToList(), nameof(Subtitle.Id), nameof(Subtitle.SubtitleName));
                ViewBag.Language = new SelectList(_language.GetWithId().ToList(), nameof(Language.Id), nameof(Language.LanguageName));
                ViewBag.AudioLanguages = new SelectList(_audioLanguages.GetWithId().ToList(), nameof(AudioLanguage.Id), nameof(AudioLanguage.AudioName));
                return View(tvShow);
            }
            if (!tvShow.ImgFile.CheckImgSize())
            {
                ViewBag.Categories = new SelectList(_categories.GetWithId().ToList(), nameof(Category.Id), nameof(Category.CategoryName));
                ViewBag.Actors = new SelectList(_actors.GetWithId().ToList(), nameof(Actor.Id), nameof(Actor.ActorName));
                ViewBag.Subtitles = new SelectList(_subtitles.GetWithId().ToList(), nameof(Subtitle.Id), nameof(Subtitle.SubtitleName));
                ViewBag.Language = new SelectList(_language.GetWithId().ToList(), nameof(Language.Id), nameof(Language.LanguageName));
                ViewBag.AudioLanguages = new SelectList(_audioLanguages.GetWithId().ToList(), nameof(AudioLanguage.Id), nameof(AudioLanguage.AudioName));
                ModelState.AddModelError("ImgFile", "Wrong img size");
                return View(tvShow);
            }
            if (!tvShow.ImgFile.CheckImgFileType())
            {
                ViewBag.Categories = new SelectList(_categories.GetWithId().ToList(), nameof(Category.Id), nameof(Category.CategoryName));
                ViewBag.Actors = new SelectList(_actors.GetWithId().ToList(), nameof(Actor.Id), nameof(Actor.ActorName));
                ViewBag.Subtitles = new SelectList(_subtitles.GetWithId().ToList(), nameof(Subtitle.Id), nameof(Subtitle.SubtitleName));
                ViewBag.Language = new SelectList(_language.GetWithId().ToList(), nameof(Language.Id), nameof(Language.LanguageName));
                ViewBag.AudioLanguages = new SelectList(_audioLanguages.GetWithId().ToList(), nameof(AudioLanguage.Id), nameof(AudioLanguage.AudioName));

                ModelState.AddModelError("ImgFile", "Wrong Img Type");
                return View(tvShow);
            }

            tvShow.rating = await ImdbApi.GetRating(tvShow.TvShowName);
            _db.Update(id, tvShow);

            return RedirectToAction(nameof(Index));
        }
    }
}
