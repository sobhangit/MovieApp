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
        //new comment add
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

            var movies = _movieRepository.GetAllMovies();
            var movieDtos = new List<MovieDto>();

            if (!String.IsNullOrEmpty(searchedWord))
            {
                var moviesFounded = _movieRepository.GetMoviesByName(searchedWord);
                movieDtos = _movieAdapter.GetDtos(moviesFounded);

                return View(movieDtos);
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

            _movieService.AddMovieToDatabase(moviedto);

            ModelState.Clear();

            return View();
        }

        public IActionResult GetMovie(int id)
        {
            var movieDto = _movieService.GetMovieById(id);

            if (movieDto == null)
            {
                return NotFound();
            }

            return View(movieDto);
        }

        [HttpGet]
        public IActionResult EditMovie(int id)
        {

            var movieDto = _movieService.GetMovieById(id);

            if (movieDto != null)
            {
                return View(movieDto);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult EditMovie(MovieDto movieDto)
        {
            if (ModelState.IsValid == false)
            {
                return View(movieDto);
            }

            _movieService.UpdateMovie(movieDto);


            ModelState.Clear();


            return RedirectToAction("Index");
        }

        public IActionResult DeleteMovie(int id)
        {
            var movie = _movieRepository.GetMovieById(id);

            MovieDto movieDto = new();

            if (movie == null)
            {
                return NotFound();
            }

            return View(movieDto);
        }

        public IActionResult ConfirmDeleteMovie(int id)
        {
            _movieRepository.DeleteMovie(id);
            _movieRepository.Save();
            
            return RedirectToAction("Index");
        }

    }
}
