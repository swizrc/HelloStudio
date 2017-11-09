using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloStudio.Controllers
{
    public class HelloController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            Dictionary<string, string> Hellos = new Dictionary<string, string>();
            StringBuilder select = new StringBuilder();
            select.Append("<select name='hellolist' form='form'>");

            Hellos.Add("English", "Hello");
            Hellos.Add("Thai", "Sawadee Khrup");
            Hellos.Add("Mandarin", "Ni Hao");
            Hellos.Add("German", "Guten Tag");
            Hellos.Add("Spanish", "Hola");

            foreach (KeyValuePair<string,string> hello in Hellos)
            {
                select.Append("<option value='" + hello.Value + "'>" + hello.Key + "</option>");
            }
            select.Append("</select>");

            string html = "<form id='form' method='post' action='/Hello/CreateMessage/'>"+
                "<label for=\"name\">Name:</label>"+
                "<input name='name' type='text' id='name'>"+select+
                "<input type='submit'>"+
                "</form>";

            return Content(html,"text/html");
        }
        [HttpPost]
        public IActionResult CreateMessage(string hellolist,string name)
        {
            string html = "<h1>" + hellolist + " " + name + "</h1>";

            return Content(html,"text/html");
        }
    }
}
