using Metadata_Viewer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Metadata_Viewer.Controllers
{
    public class MetadataController : Controller
    {
        public IActionResult Index()
        {
            MetadataModel metadata = new()
            {

                ApplicationName = System.Reflection.Assembly.GetEntryAssembly().GetName().Name,

                ApplicationBasePath = System.AppContext.BaseDirectory,

                TargetFramework = GetTargetFramework(),

                Version = System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString()

            };


            return View(metadata);
        }

        private string GetTargetFramework()

        {

            System.Reflection.Assembly? entryAssembly = System.Reflection.Assembly.GetEntryAssembly();

            System.Runtime.Versioning.TargetFrameworkAttribute? targetFramework = entryAssembly.GetCustomAttributes(typeof(System.Runtime.Versioning.TargetFrameworkAttribute), true)[0] as System.Runtime.Versioning.TargetFrameworkAttribute;


            return targetFramework.FrameworkName;

        }
    }
}
