using BackEndAPI.Data;
using BackEndAPI.Data.Models;

namespace BackEndAPI.Services.NewsService;

public class NewsService : INewsService
{
    private DataContext _db;
    public NewsService(DataContext db)
    {
        _db = db;
    }
    public async Task<List<News>> GetNews()
    {

        List<News> news = _db.News.ToList();
        return news;
        
    }

    public async Task<string> AddNews(Data.Models.News newstoadd)
    {
        bool checkadd = _db.News.AddAsync(newstoadd).IsCompletedSuccessfully;
        if (checkadd)
        {
            return "Adding News done successfully";
        }
        else
        {
            return "Adding News Failed";
        }
    }
    
}