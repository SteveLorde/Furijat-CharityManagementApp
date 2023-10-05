using BackEndAPI.Data.Models;

namespace BackEndAPI.Services.NewsService;

public interface INewsService
{
    public Task<List<News>> GetNews();
    public Task<string> AddNews(News newstoadd);
    
}