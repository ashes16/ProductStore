using Microsoft.AspNetCore.Mvc;
using PractProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractProject.Controllers
{
    public class PersonController : Controller
    {
        [Route("api/Person")]
        [HttpPost]
        public ActionResult Person([FromBody] Person person)
        {
            Console.WriteLine(person.First_Name);

            //do stuff
            return Content(person.First_Name);
        }

    }
}
