using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface IArticleRepository
    {
        List<Article> GetAllArticles();
        Article GetArticleById(int id);
        List<Article> GetArticlesByName(string name);
        void AddArticle(Article article);
        void UpdateArticle(Article article);
        void DeleteArticle(int id);
        void Save();
    }
}