using BackEndAPI.Data.Models;
using BackEndAPI.Services.NewsService;
using Microsoft.AspNetCore.Mvc;

namespace BackEndAPI.Controllers;

[ApiController]
public class NewsController : Controller
{
    private INewsService _newsService;

    public NewsController(NewsService newsService)
    {
        _newsService = newsService;
    }
    
    [Route("api/GetNews")]
    [HttpGet]
    // GET
    public async Task<List<News>> GetNews()
    {
        List<News> news = await _newsService.GetNews();
            return news;
    }
    
    [Route("api/AddNews")]
    [HttpPost]
    // GET
    public async Task<string> AddNews(News news)
    {
        var checkoperation = await _newsService.AddNews(news);
        return checkoperation;
    }
    
}