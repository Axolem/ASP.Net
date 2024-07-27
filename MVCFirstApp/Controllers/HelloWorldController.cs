using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MVCFirstApp.Controllers
{
    public class HelloWorldController : Controller
    {
        public string Index()
        {
            return "This is a default action...";
        }

        public string Welcome(string name, int number)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, the number is {number}");
        }
    }
}
