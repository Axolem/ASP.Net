using Hands_on_5_Entity_Framework_Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hands_on_5_Entity_Framework_Core.Controllers
{
    public class BookController : Controller
    {
        public async Task<IActionResult> Index()
        {
            using EFCoreWebDemoContext context = new();
            var model  = await context.Autors.Include(a => a.Books).AsNoTracking().ToListAsync();
            return View(model);
        }

        public async Task<IActionResult> Create([Bind("Title, Description, AuthorId")] BookController book)
        {
            using EFCoreWebDemoContext context = new();
            context.Add(book);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
