using WebApplication1.Models;
using WebApplication1.Models.ViewModel;

namespace WebApplication1.Adapter
{
    public class MovieAdapter : IMovieAdapter
    {

        public MovieDto GetDto(Movie movie)
        {
            MovieDto movieDto = new MovieDto();
            movieDto.Title = movie.Title;
            movieDto.Price = movie.Price;
            movieDto.Id = movie.Id;
            movieDto.ReleaseDate = movie.ReleaseDate;
            movieDto.Genre = movie.Genre;
            movieDto.Is_Deleted = movie.Is_Deleted;


            return movieDto;
        }

        public List<MovieDto> GetDtos(List<Movie> movies)
        {
            List<MovieDto> movieDtos = new List<MovieDto>();
            foreach (Movie movie in movies)
            {
                movieDtos.Add(new MovieDto
                    {
                        Title = movie.Title,
                        Price = movie.Price,
                        Id = movie.Id,
                        ReleaseDate = movie.ReleaseDate,
                        Genre = movie.Genre,
                        Is_Deleted = movie.Is_Deleted
                    }
                );
            }
        
            return movieDtos;
        }

        public Movie GetMovie(MovieDto movieDto)
        {
            Movie movie = new Movie();
            movie.Title = movieDto.Title;
            movie.Price = movieDto.Price;
            movie.Id = movieDto.Id;
            movie.ReleaseDate = movieDto.ReleaseDate;
            movie.Genre = movieDto.Genre;
            movie.Is_Deleted = movieDto.Is_Deleted;


            return movie;
        }

        public List<Movie> GetMovies(List<MovieDto> movieDtos)
        {
            List<Movie> movies = new List<Movie>();

            foreach (var movieDto in movieDtos)
            {
                movies.Add(new Movie
                    {
                        Title = movieDto.Title,
                        Price = movieDto.Price,
                        Id = movieDto.Id,
                        ReleaseDate = movieDto.ReleaseDate,
                        Genre = movieDto.Genre,
                        Is_Deleted = movieDto.Is_Deleted
                    }
                );
            }
            
            return movies;
        }
    }
}
