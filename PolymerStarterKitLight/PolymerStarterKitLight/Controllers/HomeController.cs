using PolymerStarterKitLight.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace PolymerStarterKitLight.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: Elements
        public ActionResult Elements()
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            IEnumerable<Tuple<string, string>> actions = executingAssembly.GetTypes()
                .Where(type => typeof(Controller).IsAssignableFrom(type))
                .SelectMany(type => type.GetMethods())
                .Where(method => method.IsPublic && method.IsDefined(typeof(ElementAttribute)))
                .Select(method => Tuple.Create(method.Name, method.DeclaringType.Name.Replace("Controller", string.Empty)));
            this.ViewBag.Actions = actions;
            return View();
        }
    }
}