using BookMyShowApi.Models;

namespace BookMyShowApi.Repository
{
    public interface IBookingRepository
    {

         public BookingModel BookTicket(BookingModel ticket );

        public List<BookingModel> GetAll();

        public BookingModel GetTicketById(int id);

        void Delete(int id);

        public BookingModel Update(BookingModel ticket);

    }
}
