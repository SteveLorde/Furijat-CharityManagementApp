using BackEndAPI.Data.Models;
using BackEndAPI.Services.NewsService;
using Microsoft.AspNetCore.Mvc;

namespace BackEndAPI.Controllers;

[ApiController]
public class NewsController : Controller
{
    private INewsService _newsService;

    public NewsController(INewsService newsService)
    {
        _newsService = newsService;
    }
    
    [Route("api/GetNews")]
    [HttpGet]
    // GET
    public async Task<List<News>> GetNews()
    {
        return await _newsService.GetNews();
    }
    
    [Route("api/AddNews")]
    [HttpPost]
    // GET
    public async Task<string> AddNews(News news)
    {
        return await _newsService.AddNews(news);
    }
    
}