using WebApplication1.Models;
using WebApplication1.Models.ViewModel;

namespace WebApplication1.Adapter
{
    public class ArticleAdapter : IArticleAdapter
    {
        public Article GetArticle(ArticleDto articleDto)
        {
            var article = new Article()
            {
                Id = articleDto.Id,
                Title = articleDto.Title,
                Body = articleDto.Body,
                Is_Deleted = articleDto.Is_Deleted
            };
            
            return article;
        }

        public ArticleDto GetArticleDto(Article article)
        {
            var articleDto = new ArticleDto()
            {
                Id = article.Id,
                Title = article.Title,
                Body = article.Body,
                Is_Deleted = article.Is_Deleted
            };

            return articleDto;
        }

        public List<ArticleDto> GetArticleDtos(List<Article> articles)
        {
            var articleDtos = new List<ArticleDto>();

            foreach (var article in articles)
            {
                articleDtos.Add(
                    new ArticleDto
                    {
                        Id = article.Id,
                        Title = article.Title,
                        Body = article.Body,
                        Is_Deleted = article.Is_Deleted
                    });
            }

            return articleDtos;
        }

        public List<Article> GetArticles(List<ArticleDto> articleDtos)
        {
            var articles = new List<Article>();

            foreach (var articleDto in articleDtos)
            {
                articles.Add(
                    new Article
                    {
                        Id = articleDto.Id,
                        Title = articleDto.Title,
                        Body = articleDto.Body,
                        Is_Deleted = articleDto.Is_Deleted
                    });
            }

            return articles;
        }
    }
}
