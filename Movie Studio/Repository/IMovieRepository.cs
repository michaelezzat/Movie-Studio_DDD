using Movie_Studio.Entities;

namespace Movie_Studio.Repository
{
    public interface IMovieRepository
    {
        void Save(Movie movie);
        Movie GetById(int movieId);
        List<Movie> GetAll();
    }
}
