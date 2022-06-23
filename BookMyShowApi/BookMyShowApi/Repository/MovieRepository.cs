using BookMyShowApi.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BookMyShowApi.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private IDbConnection _db;

        public MovieRepository(IConfiguration configuration)
        {
            _db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public MoviesModel AddMovie(MoviesModel movie)
        {
            var query = "INSERT INTO Movies (Title,ReleaseDate,Duration,Description,Cast,Crew) VALUES (@Title,@ReleaseDate,@Duration,@Description,@Cast,@Crew);" +
                "SELECT CAST(SCOPE_IDENTITY() as int);";
            var id = _db.Query<int>(query, new
            {
                @Title=  movie.Title,
                @ReleaseDate=movie.ReleaseDate,
                @Duration=movie.Duration,   
                @Description=movie.Description,
                @Cast=movie.Cast,
                @Crew=movie.Crew,
                @ImageURL=movie.ImageURL
                

            }).Single();

            movie.Id = id;
            return movie;
        }

       public List<MoviesModel> GetAll()
        {
            var query = "select * from Movies";
            return _db.Query<MoviesModel>(query).ToList();
        }

       public MoviesModel GetMovieById(int id)
        {
            var query = "select * from Movies where Id=@id";
            return _db.Query<MoviesModel>(query, new { @id = id }).Single();
        }

        public void Delete(int id)
        {
            var query = "Delete From Movies Where Id=@Id";
            _db.Execute(query, new
            {
                @Id = id
            });
        }

        public MoviesModel Update(MoviesModel movie)
        {
            var query = "Update Movies Set Title=@Title,ReleaseDate=@ReleaseDate,Duration=@Duration,Description=@Description,Cast=@Cast,Crew=@Crew,ImageURL=@ImageURL WHERE Id=@Id";
            _db.Execute(query, movie);
            return movie;
        }
    }
}
