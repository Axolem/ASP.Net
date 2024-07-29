using Hands_on_5_Entity_Framework_Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hands_on_5_Entity_Framework_Core.Controllers
{
    public class AuthorController : Controller
    {
        public async Task<IActionResult> Index()
        {
            using EFCoreWebDemoContext context = new();
            List<Author> model = await context.Autors.AsNoTracking().ToListAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create([Bind("FirstName, LastName")] Author author)
        {
            using EFCoreWebDemoContext context = new();
            _ = context.Add(author);
            _ = await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
