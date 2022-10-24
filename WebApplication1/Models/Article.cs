using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{

    public class Article {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public bool Is_Deleted {get;set;}
        public DateTime CreateDate {get;set;} = DateTime.Now;

    }

}