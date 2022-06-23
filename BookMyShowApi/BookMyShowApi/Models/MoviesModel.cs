using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookMyShowApi.Models
{
    public class MoviesModel
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string ReleaseDate { get; set; }

        public string Duration { get; set; }
        public string Description { get; set; }
        
        public string Cast { get; set; }

        public string Crew { get; set; }

        public string ImageURL { get; set; }

    }
}
