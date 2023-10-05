using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace BackEndAPI.Data.Models;
public class News
{
    public int Id { get; set; }
    public string date { get; set; }
    [Required]
    public string title { get; set; }
    public string subtitle { get; set; }
    public string body { get; set; }
}