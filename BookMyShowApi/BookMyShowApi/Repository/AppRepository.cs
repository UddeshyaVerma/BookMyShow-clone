using BookMyShowApi.Data;
using BookMyShowApi.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BookMyShowApi.Repository
{

    public class AppRepository : IAppRepository
    {

        private IDbConnection _db;

        public AppRepository(IConfiguration configuration)
        {
            _db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public void Delete(int id)
        {
            var query = "Delete From Users Where Id=@Id";
            _db.Execute(query, new
            {
                @Id = id
            });
            
        }

       public List<UserModel> Get()
        {
            var query = "select * from Users";
            return _db.Query<UserModel>(query).ToList();
        }

       public UserModel GetOne(int id)
        {
            var query = "select * from Users where Id=@id";
            return _db.Query<UserModel>(query, new { @id = id }).Single();
        }

        //public UserModel Register(UserModel user)
        //{
        //    var query = "INSERT INTO Users (UserName,FullName,Email,Phone,City,Password) VALUES (@UserName,@FullName,@Email,@Phone,@City,@Password);" +
        //        "SELECT CAST(SCOPE_IDENTITY() as int);";
        //    var id = _db.Query<int>(query, new
        //    {
        //        @UserName = user.UserName,
        //        @FullName = user.FullName,
        //        @Email = user.Email,
        //        @Phone=user.Phone,
        //        @City=user.City,
        //        @Password=user.Password,

        //    }).Single();

        //    user.Id = id;
        //    return user;
        //}
    }
}
