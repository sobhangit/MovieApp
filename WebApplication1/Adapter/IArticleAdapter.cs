using WebApplication1.Models;
using WebApplication1.Models.ViewModel;

namespace WebApplication1.Adapter
{
    public interface IArticleAdapter
    {
        List<Article> GetArticles(List<ArticleDto> articleDtos);
        Article GetArticle(ArticleDto articleDto);
        List<ArticleDto> GetArticleDtos(List<Article> articles);
        ArticleDto GetArticleDto(Article article);
    }
}
