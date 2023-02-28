using BusinesLogic.Utilites;
using BusinesLogic.ViewModel.Actor;
using BusinesLogic.ViewModel.AudioLanguage;
using BusinesLogic.ViewModel.Category;
using BusinesLogic.ViewModel.Language;
using BusinesLogic.ViewModel.Movie;
using BusinesLogic.ViewModel.Subtitle;
using DAL.GeneralClass;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NetflixMVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class MovieController : Controller
    {
        ICategoryService<CategoryVM> _categories;
        IActorService<ActorVM> _actors;
        ILanguageService<LanguageVM> _language;
        IAudioLanguageService<AudioLanguageVM> _audioLanguages;
        ISubtitleService<SubtitleVM> _subtitles;
        IMovieService<MovieVM> _db;
        

        public MovieController(IMovieService<MovieVM> db, ICategoryService<CategoryVM> categories, IActorService<ActorVM> actors, ILanguageService<LanguageVM> language, IAudioLanguageService<AudioLanguageVM> audioLanguages, ISubtitleService<SubtitleVM> subtitles)
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
        public async Task<IActionResult> Create(MovieVM movieVM)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = new SelectList(_categories.GetWithId().ToList(), nameof(Category.Id), nameof(Category.CategoryName));
                ViewBag.Actors = new SelectList(_actors.GetWithId().ToList(), nameof(Actor.Id), nameof(Actor.ActorName));
                ViewBag.Subtitles = new SelectList(_subtitles.GetWithId().ToList(), nameof(Subtitle.Id), nameof(Subtitle.SubtitleName));
                ViewBag.Language = new SelectList(_language.GetWithId().ToList(), nameof(Language.Id), nameof(Language.LanguageName));
                ViewBag.AudioLanguages = new SelectList(_audioLanguages.GetWithId().ToList(), nameof(AudioLanguage.Id), nameof(AudioLanguage.AudioName));
                return View(movieVM);
            }
            if (!movieVM.ImgFile.CheckImgSize())
            {
                ViewBag.Categories = new SelectList(_categories.GetWithId().ToList(), nameof(Category.Id), nameof(Category.CategoryName));
                ViewBag.Actors = new SelectList(_actors.GetWithId().ToList(), nameof(Actor.Id), nameof(Actor.ActorName));
                ViewBag.Subtitles = new SelectList(_subtitles.GetWithId().ToList(), nameof(Subtitle.Id), nameof(Subtitle.SubtitleName));
                ViewBag.Language = new SelectList(_language.GetWithId().ToList(), nameof(Language.Id), nameof(Language.LanguageName));
                ViewBag.AudioLanguages = new SelectList(_audioLanguages.GetWithId().ToList(), nameof(AudioLanguage.Id), nameof(AudioLanguage.AudioName));
                ModelState.AddModelError("ImgFile", "Wrong img size");
                return View(movieVM);
            }
            if (!movieVM.ImgFile.CheckImgFileType())
            {
                ViewBag.Categories = new SelectList(_categories.GetWithId().ToList(), nameof(Category.Id), nameof(Category.CategoryName));
                ViewBag.Actors = new SelectList(_actors.GetWithId().ToList(), nameof(Actor.Id), nameof(Actor.ActorName));
                ViewBag.Subtitles = new SelectList(_subtitles.GetWithId().ToList(), nameof(Subtitle.Id), nameof(Subtitle.SubtitleName));
                ViewBag.Language = new SelectList(_language.GetWithId().ToList(), nameof(Language.Id), nameof(Language.LanguageName));
                ViewBag.AudioLanguages = new SelectList(_audioLanguages.GetWithId().ToList(), nameof(AudioLanguage.Id), nameof(AudioLanguage.AudioName));

                ModelState.AddModelError("ImgFile", "Wrong Img Type");
                return View(movieVM);
            }
            if (!movieVM.VideoFile.CheckVideoSize())
            {
                ViewBag.Categories = new SelectList(_categories.GetWithId().ToList(), nameof(Category.Id), nameof(Category.CategoryName));
                ViewBag.Actors = new SelectList(_actors.GetWithId().ToList(), nameof(Actor.Id), nameof(Actor.ActorName));
                ViewBag.Subtitles = new SelectList(_subtitles.GetWithId().ToList(), nameof(Subtitle.Id), nameof(Subtitle.SubtitleName));
                ViewBag.Language = new SelectList(_language.GetWithId().ToList(), nameof(Language.Id), nameof(Language.LanguageName));
                ViewBag.AudioLanguages = new SelectList(_audioLanguages.GetWithId().ToList(), nameof(AudioLanguage.Id), nameof(AudioLanguage.AudioName));

                ModelState.AddModelError("VIdeoFile", "Wrong VIdeo size");
                return View(movieVM);
            }
            if (!movieVM.VideoFile.CheckVideoFileType())
            {
                ViewBag.Categories = new SelectList(_categories.GetWithId().ToList(), nameof(Category.Id), nameof(Category.CategoryName));
                ViewBag.Actors = new SelectList(_actors.GetWithId().ToList(), nameof(Actor.Id), nameof(Actor.ActorName));
                ViewBag.Subtitles = new SelectList(_subtitles.GetWithId().ToList(), nameof(Subtitle.Id), nameof(Subtitle.SubtitleName));
                ViewBag.Language = new SelectList(_language.GetWithId().ToList(), nameof(Language.Id), nameof(Language.LanguageName));
                ViewBag.AudioLanguages = new SelectList(_audioLanguages.GetWithId().ToList(), nameof(AudioLanguage.Id), nameof(AudioLanguage.AudioName));

                ModelState.AddModelError("VideoFile", "Wrong Video Type");
                return View(movieVM);
            }
            if (!movieVM.TrailerFile.CheckVideoSize())
            {
                ViewBag.Categories = new SelectList(_categories.GetWithId().ToList(), nameof(Category.Id), nameof(Category.CategoryName));
                ViewBag.Actors = new SelectList(_actors.GetWithId().ToList(), nameof(Actor.Id), nameof(Actor.ActorName));
                ViewBag.Subtitles = new SelectList(_subtitles.GetWithId().ToList(), nameof(Subtitle.Id), nameof(Subtitle.SubtitleName));
                ViewBag.Language = new SelectList(_language.GetWithId().ToList(), nameof(Language.Id), nameof(Language.LanguageName));
                ViewBag.AudioLanguages = new SelectList(_audioLanguages.GetWithId().ToList(), nameof(AudioLanguage.Id), nameof(AudioLanguage.AudioName));

                ModelState.AddModelError("TrailerFile", "Wrong VIdeo size");
                return View(movieVM);
            }
            if (!movieVM.TrailerFile.CheckVideoFileType())
            {
                ViewBag.Categories = new SelectList(_categories.GetWithId().ToList(), nameof(Category.Id), nameof(Category.CategoryName));
                ViewBag.Actors = new SelectList(_actors.GetWithId().ToList(), nameof(Actor.Id), nameof(Actor.ActorName));
                ViewBag.Subtitles = new SelectList(_subtitles.GetWithId().ToList(), nameof(Subtitle.Id), nameof(Subtitle.SubtitleName));
                ViewBag.Language = new SelectList(_language.GetWithId().ToList(), nameof(Language.Id), nameof(Language.LanguageName));
                ViewBag.AudioLanguages = new SelectList(_audioLanguages.GetWithId().ToList(), nameof(AudioLanguage.Id), nameof(AudioLanguage.AudioName));

                ModelState.AddModelError("TrailerFile", "Wrong Video Type");
                return View(movieVM);
            }

            movieVM.Raiting = await ImdbApi.GetRating(movieVM.MovieName);
            _db.Create(movieVM);

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
        public async Task<IActionResult> Update(int id, MovieVM movieVM)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = new SelectList(_categories.GetWithId().ToList(), nameof(Category.Id), nameof(Category.CategoryName));
                ViewBag.Actors = new SelectList(_actors.GetWithId().ToList(), nameof(Actor.Id), nameof(Actor.ActorName));
                ViewBag.Subtitles = new SelectList(_subtitles.GetWithId().ToList(), nameof(Subtitle.Id), nameof(Subtitle.SubtitleName));
                ViewBag.Language = new SelectList(_language.GetWithId().ToList(), nameof(Language.Id), nameof(Language.LanguageName));
                ViewBag.AudioLanguages = new SelectList(_audioLanguages.GetWithId().ToList(), nameof(AudioLanguage.Id), nameof(AudioLanguage.AudioName));
                return View(movieVM);
            }
            if (!movieVM.ImgFile.CheckImgSize())
            {
                ViewBag.Categories = new SelectList(_categories.GetWithId().ToList(), nameof(Category.Id), nameof(Category.CategoryName));
                ViewBag.Actors = new SelectList(_actors.GetWithId().ToList(), nameof(Actor.Id), nameof(Actor.ActorName));
                ViewBag.Subtitles = new SelectList(_subtitles.GetWithId().ToList(), nameof(Subtitle.Id), nameof(Subtitle.SubtitleName));
                ViewBag.Language = new SelectList(_language.GetWithId().ToList(), nameof(Language.Id), nameof(Language.LanguageName));
                ViewBag.AudioLanguages = new SelectList(_audioLanguages.GetWithId().ToList(), nameof(AudioLanguage.Id), nameof(AudioLanguage.AudioName));
                ModelState.AddModelError("ImgFile", "Wrong img size");
                return View(movieVM);
            }
            if (!movieVM.ImgFile.CheckImgFileType())
            {
                ViewBag.Categories = new SelectList(_categories.GetWithId().ToList(), nameof(Category.Id), nameof(Category.CategoryName));
                ViewBag.Actors = new SelectList(_actors.GetWithId().ToList(), nameof(Actor.Id), nameof(Actor.ActorName));
                ViewBag.Subtitles = new SelectList(_subtitles.GetWithId().ToList(), nameof(Subtitle.Id), nameof(Subtitle.SubtitleName));
                ViewBag.Language = new SelectList(_language.GetWithId().ToList(), nameof(Language.Id), nameof(Language.LanguageName));
                ViewBag.AudioLanguages = new SelectList(_audioLanguages.GetWithId().ToList(), nameof(AudioLanguage.Id), nameof(AudioLanguage.AudioName));

                ModelState.AddModelError("ImgFile", "Wrong Img Type");
                return View(movieVM);
            }
            if (!movieVM.VideoFile.CheckVideoSize())
            {
                ViewBag.Categories = new SelectList(_categories.GetWithId().ToList(), nameof(Category.Id), nameof(Category.CategoryName));
                ViewBag.Actors = new SelectList(_actors.GetWithId().ToList(), nameof(Actor.Id), nameof(Actor.ActorName));
                ViewBag.Subtitles = new SelectList(_subtitles.GetWithId().ToList(), nameof(Subtitle.Id), nameof(Subtitle.SubtitleName));
                ViewBag.Language = new SelectList(_language.GetWithId().ToList(), nameof(Language.Id), nameof(Language.LanguageName));
                ViewBag.AudioLanguages = new SelectList(_audioLanguages.GetWithId().ToList(), nameof(AudioLanguage.Id), nameof(AudioLanguage.AudioName));

                ModelState.AddModelError("VIdeoFile", "Wrong VIdeo size");
                return View(movieVM);
            }
            if (!movieVM.VideoFile.CheckVideoFileType())
            {
                ViewBag.Categories = new SelectList(_categories.GetWithId().ToList(), nameof(Category.Id), nameof(Category.CategoryName));
                ViewBag.Actors = new SelectList(_actors.GetWithId().ToList(), nameof(Actor.Id), nameof(Actor.ActorName));
                ViewBag.Subtitles = new SelectList(_subtitles.GetWithId().ToList(), nameof(Subtitle.Id), nameof(Subtitle.SubtitleName));
                ViewBag.Language = new SelectList(_language.GetWithId().ToList(), nameof(Language.Id), nameof(Language.LanguageName));
                ViewBag.AudioLanguages = new SelectList(_audioLanguages.GetWithId().ToList(), nameof(AudioLanguage.Id), nameof(AudioLanguage.AudioName));

                ModelState.AddModelError("VideoFile", "Wrong Video Type");
                return View(movieVM);
            }
            if (!movieVM.TrailerFile.CheckVideoSize())
            {
                ViewBag.Categories = new SelectList(_categories.GetWithId().ToList(), nameof(Category.Id), nameof(Category.CategoryName));
                ViewBag.Actors = new SelectList(_actors.GetWithId().ToList(), nameof(Actor.Id), nameof(Actor.ActorName));
                ViewBag.Subtitles = new SelectList(_subtitles.GetWithId().ToList(), nameof(Subtitle.Id), nameof(Subtitle.SubtitleName));
                ViewBag.Language = new SelectList(_language.GetWithId().ToList(), nameof(Language.Id), nameof(Language.LanguageName));
                ViewBag.AudioLanguages = new SelectList(_audioLanguages.GetWithId().ToList(), nameof(AudioLanguage.Id), nameof(AudioLanguage.AudioName));

                ModelState.AddModelError("TrailerFile", "Wrong VIdeo size");
                return View(movieVM);
            }
            if (!movieVM.TrailerFile.CheckVideoFileType())
            {
                ViewBag.Categories = new SelectList(_categories.GetWithId().ToList(), nameof(Category.Id), nameof(Category.CategoryName));
                ViewBag.Actors = new SelectList(_actors.GetWithId().ToList(), nameof(Actor.Id), nameof(Actor.ActorName));
                ViewBag.Subtitles = new SelectList(_subtitles.GetWithId().ToList(), nameof(Subtitle.Id), nameof(Subtitle.SubtitleName));
                ViewBag.Language = new SelectList(_language.GetWithId().ToList(), nameof(Language.Id), nameof(Language.LanguageName));
                ViewBag.AudioLanguages = new SelectList(_audioLanguages.GetWithId().ToList(), nameof(AudioLanguage.Id), nameof(AudioLanguage.AudioName));

                ModelState.AddModelError("TrailerFile", "Wrong Video Type");
                return View(movieVM);
            }

            movieVM.Raiting = await ImdbApi.GetRating(movieVM.MovieName);
            _db.Update(id, movieVM);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detail(int id)
        {
            var res = _db.GetWithInclude(id);
            if (res == null)
            {
                return BadRequest();
            }

            return View(res);
        }
    }
}
