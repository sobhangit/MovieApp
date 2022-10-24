using WebApplication1.Models;
using WebApplication1.DAL;


namespace WebApplication1.Repository
{
    public class ArticleRepository : IArticleRepository
    {

        private readonly ApplicationDbContext _context;
        public ArticleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Article> GetAllArticles(){
            return _context.Articles.ToList();
        }
        public Article GetArticleById(int id){
            return _context.Articles.FirstOrDefault(x=>x.Id == id);
        }
        public List<Article> GetArticlesByName(string name){
            return _context.Articles.Where(x=>x.Title!.Contains(name)).ToList();
        }
        public void AddArticle(Article article){

            _context.Articles.Add(article);
            _context.SaveChanges();

        }
        public void UpdateArticle(Article article){
            _context.Articles.Update(article);
        }
        public void DeleteArticle(int id){
            var article = GetArticleById(id);
            article.Is_Deleted = true;
            UpdateArticle(article);
        }
        public void Save(){
            _context.SaveChanges();
        }

    }
}