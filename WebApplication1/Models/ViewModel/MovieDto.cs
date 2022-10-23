using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.ViewModel
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string? Genre { get; set; }
        public decimal Price { get; set; }
        public bool Is_Deleted { get; set; }
    }
}
