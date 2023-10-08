using BackEndAPI.Data;
using BackEndAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

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
        var news = await _db.News.ToListAsync();
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