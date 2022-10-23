using Microsoft.AspNetCore.Mvc;
using WebApplication1.Adapter;
using WebApplication1.DAL;
using WebApplication1.Models;
using WebApplication1.Models.ViewModel;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMovieAdapter _movieAdapter;

        public MovieController(IMovieRepository movieRepository,IMovieAdapter movieAdapter)
        {
            _movieRepository = movieRepository;
            _movieAdapter = movieAdapter;
        }
        public IActionResult Index()
        {
            var movies = _movieRepository.GetAllMovies();
            var movieDtos = _movieAdapter.GetDtos(movies);
            
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

            var movie = _movieAdapter.GetMovie(moviedto);

            _movieRepository.AddMovie(movie);
            _movieRepository.Save();

            ModelState.Clear();

            return View();
        }

        public IActionResult GetMovie(int id)
        {
            var movie = _movieRepository.GetMovieById(id);

            if (movie == null)
            {
                return NotFound();
            }

            var movieDto = _movieAdapter.GetDto(movie);

            return View(movieDto);
        }

        [HttpGet]
        public IActionResult EditMovie(int id)
        {
            var movie = _movieRepository.GetMovieById(id);
            var movieDto = new MovieDto();

            if (movie != null)
            {
                movieDto = _movieAdapter.GetDto(movie);
            }

            return View(movieDto);
        }

        [HttpPost]
        public IActionResult EditMovie(MovieDto movieDto)
        {
            if (ModelState.IsValid == false)
            {
                return View(movieDto);
            }

            var movie = _movieAdapter.GetMovie(movieDto);


            _movieRepository.UpdateMovie(movie);
            _movieRepository.Save();

            ModelState.Clear();


            return RedirectToAction("Index");
        }

        public IActionResult DeleteMovie(int id)
        {
            var movie = _movieRepository.GetMovieById(id);

            MovieDto movieDto = new();

            if (movie != null)
            {
                movieDto = _movieAdapter.GetDto(movie);
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
