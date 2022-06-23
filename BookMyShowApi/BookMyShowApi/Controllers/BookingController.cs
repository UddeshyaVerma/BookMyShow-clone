using BookMyShowApi.Models;
using BookMyShowApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShowApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _repo;
        

        public BookingController(IBookingRepository repo)
        {
            _repo = repo;
           
        }



        [HttpGet]
        [Route("/tickets")]

        public List<BookingModel> getAll()
        {
            return _repo.GetAll();
        }

        [HttpPost]
        [Route("/bookTickets")]

        public BookingModel post(BookingModel ticket)

        {
            return _repo.BookTicket(ticket);

        }

        [HttpDelete]
        [Route("/delete/{id}")]

        public void delete(int id)
        {
            _repo.Delete(id);
        }

        [HttpGet]
        [Route("/getTicket/{id}")]

        public BookingModel getone(int id)
        {
            return _repo.GetTicketById(id);
        }

    }
}
