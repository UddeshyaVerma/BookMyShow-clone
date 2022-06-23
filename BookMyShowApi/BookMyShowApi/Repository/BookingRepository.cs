using BookMyShowApi.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BookMyShowApi.Repository
{
    public class BookingRepository : IBookingRepository
    {

        private IDbConnection _db;

        public BookingRepository(IConfiguration configuration)
        {
            _db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public BookingModel BookTicket(BookingModel ticket)
        {
            var query = "INSERT INTO Bookings (MovieTitle,SeatNo,HallName) VALUES (@MovieTitle,@SeatNo,@HallName);" +
               "SELECT CAST(SCOPE_IDENTITY() as int);";
            var id = _db.Query<int>(query, new
            {
                @MovieTitle = ticket.MovieTitle,
                @SeatNo = ticket.SeatNo,
                @HallName = ticket.HallName,
                

            }).Single();

            ticket.Id = id;
            return ticket;
        }

        public void Delete(int id)
        {
            var query = "Delete From Bookings Where Id=@Id";
            _db.Execute(query, new
            {
                @Id = id
            });
        }

        public List<BookingModel> GetAll()
        {
            var query = "Select * from Bookings";
            return _db.Query<BookingModel>(query).ToList();
        }

         public BookingModel GetTicketById(int id)
        {

            var query = "select * from Bookings where Id=@id";
            return _db.Query<BookingModel>(query, new { @id = id }).Single();
        }

         public BookingModel Update(BookingModel ticket)
        {
            var query = "Update Bookings Set @MovieTitle,@SeatNo,@HallName  WhERE Id=@Id";
            _db.Execute(query, ticket);
            return ticket;
        }
    }
}
