using BusinessLogic.Contracts;
using BusinessLogic.Models;
using LabBusinessModel.Data;

namespace BusinessLogic.Services
{
    public class MovieService : IMovieService
    {
        private readonly MovieDbContext _context;

        public MovieService(MovieDbContext context)
        {
            this._context = context;
        }

        public IList<Movie> GetMovies()
        {
            return _context.Movies.ToArray();
        }

        public Movie? GetMovie(int id)
        {
            return _context.Movies.Find(id);
        }

        public void AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }
        public void DeleteMovie(int id)
        {
            _context.Movies.Remove(GetMovie(id));
            _context.SaveChanges();
        }
        public void UpdateMove(Movie movie)
        {
            var existing = _context.Movies.FirstOrDefault(e => e.Id == movie.Id);
            if (existing != null)
            {
                _context.Movies.Update(movie);
                _context.SaveChanges();
            }
        }

    }
}
