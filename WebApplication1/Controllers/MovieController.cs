using Microsoft.AspNetCore.Mvc;
using WebApplication1.Adapter;
using WebApplication1.DAL;
using WebApplication1.Models;
using WebApplication1.Models.ViewModel;
using WebApplication1.Repository;
using WebApplication1.Service.Contract;

namespace WebApplication1.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public IActionResult Index()
        {
            var movieDtos = _movieService.GetAllMovies();
            return View(movieDtos);
        }

        [HttpPost]
        public IActionResult Index(string searchedWord)
        {
            var movieDtos = new List<MovieDto>();
            if (!String.IsNullOrEmpty(searchedWord))
            {
                movieDtos = _movieService.GetMoviesByName(searchedWord);
                if (movieDtos.Any() == true)
                {
                    return View(movieDtos);
                }
            }

            return View(movieDtos);
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(MovieDto moviedto)
        {
            if (ModelState.IsValid == false)
            {
                return View(moviedto);
            }

            var movie_is_added = _movieService.AddMovie(moviedto);
            
            if (true)
            {
                ModelState.Clear();
            }

            //message for movie don't add to database
            
            return View();
        }

        public IActionResult GetMovie(int id)
        {
            var movieDto = _movieService.GetMovieById(id);

            return View(movieDto);
        }

        [HttpGet]
        public IActionResult EditMovie(int id)
        {
            var movieDto = _movieService.GetMovieById(id);

            return View(movieDto);
        }

        [HttpPost]
        public IActionResult EditMovie(MovieDto movieDto)
        {
            if (ModelState.IsValid == false)
            {
                return View(movieDto);
            }

            var movie_is_updated = _movieService.UpdateMovie(movieDto);

            if (movie_is_updated)
            {
                ModelState.Clear();
                return RedirectToAction("Index");
            }

            return View(movieDto);
        }

        public IActionResult DeleteMovie(int id)
        {
            var movieDto = _movieService.GetMovieById(id);

            if (movieDto == null)
            {
                return NotFound();
            }

            return View(movieDto);
        }

        public IActionResult ConfirmDeleteMovie(int id)
        {
            var movie_is_deleted = _movieService.DeleteMovie(id);
            if (movie_is_deleted)
            {
                _movieService.Save();
                return RedirectToAction("Index");
            }

            return RedirectToAction("DeleteMovie",id);
            
        }

    }
}
