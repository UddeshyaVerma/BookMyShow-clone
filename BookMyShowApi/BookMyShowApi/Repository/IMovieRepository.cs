using BookMyShowApi.Models;

namespace BookMyShowApi.Repository
{
    public interface IMovieRepository
    {
        public MoviesModel AddMovie(MoviesModel movie);

        public List<MoviesModel> GetAll();

        public MoviesModel GetMovieById(int id);

        void Delete(int id);

        public MoviesModel Update(MoviesModel movie);

    }
}
