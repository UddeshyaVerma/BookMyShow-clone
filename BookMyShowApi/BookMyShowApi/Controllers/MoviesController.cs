using BookMyShowApi.Models;
using BookMyShowApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace BookMyShowApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {

        private readonly IMovieRepository _repo;
        private readonly IWebHostEnvironment _hostEnvironment;

        public MoviesController(IMovieRepository repo, IWebHostEnvironment hostEnvironment)
        {
            _repo = repo;
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        [Route("/movies")]

        public List<MoviesModel> GetAll()
        {
            return _repo.GetAll();
        }

        [HttpGet]
        [Route("/movie/{id}")]
        public MoviesModel GetOne(int id)
        {
            return _repo.GetMovieById(id);
        }

        [HttpPost]
        [Route("/AddMovies")]

        public ActionResult Post( MoviesModel movie)
        {
              //if (movie.Image.Length > 0)
                //{
                //    if (!Directory.Exists(_hostEnvironment.WebRootPath + "\\Upload\\"))
                //    {
                //        Directory.CreateDirectory(_hostEnvironment.WebRootPath + "\\Upload\\");
                //    }
                //    using (FileStream fileStream = System.IO.File.Create(_hostEnvironment.WebRootPath + "\\Upload\\" + movie.Image.FileName))
                //    {
                //        movie.Image.CopyTo(fileStream);
                //        fileStream.Flush();
                //    }
                        _repo.AddMovie(movie);
                        return Ok(movie);
                //}
                
            
            
        }

        [HttpPost]
        [Route("/DeleteMovie/{id}")]
        public ActionResult Delete(int id)
        {
            _repo.Delete(id);
            return Ok("deleted Successfully");
        }


        [HttpPut]

        [Route("/Update")]

        public async Task<ActionResult> Put( MoviesModel movie)
        {
            _repo.Update(movie);
            return Ok(movie);
        }

    }

}

