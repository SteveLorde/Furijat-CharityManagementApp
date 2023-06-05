using BackEndAPI.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using BackEndAPI.Models;

namespace BackEndAPI.Controllers
{
    [Route("api/generatepdf")]
    [ApiController]
    public class ExportToPDF : ControllerBase
    {
        private readonly IAppDbContext _context;

        public ExportToPDF(IAppDbContext context)
        {
            _context = context;
        }

        [HttpGet("CharityDebtors")]
        public IActionResult CharityDebtorsReport()
        {

            var charitydebtors = _context.Cases.All.ToList();

            //var charityname = context.Charities.Find(e => e.Id == id);
            //string chdebtors = charitydebtors.ToString();
            //var charitydebtorsstring = string.Join(",", charitydebtors.Select(p => $"{p.Id}: {p.FirstName} {p.TotalAmount} (${p.LastName}"));
            //.Where(p => p.Charity.Id == id).ToList();

            var doc = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(9));

                    page.Header()
                        .Text("Hello PDF!")
                        .SemiBold().FontSize(36).FontColor(Colors.Blue.Medium);

                    page.Content()
                    .Column(x =>
                    {
                        x.Item().Text("List of Cases in Charity").FontSize(36);
                        foreach (var entity in charitydebtors )
                        {
                            string thisEntity = $"Name:{entity.FirstName} Description:{entity.Description} Total Amount of Money Needed:{entity.TotalAmount}";

                            x.Item().Row(row =>
                            {
                                row.RelativeItem().Text(thisEntity);
                            });
                        }
                    }
                    );
                       

                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Page ");
                            x.CurrentPageNumber();
                        });
                });
            });

            byte[] data = doc.GeneratePdf();

            return File(data, "application/octet-stream", "testreport.pdf");

            //return Ok(charitydebtors);
        }
    }
}
