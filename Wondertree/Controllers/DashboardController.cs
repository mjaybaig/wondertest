using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Wondertree.Controllers
{
    [Produces("application/json")]
    [Route("Dashboard")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://wondertreetest.azurewebsites.net");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);

                HttpResponseMessage response =  client.GetAsync("/api/test/checkstatus").Result;
                string checkstatus = response.Content.ReadAsStringAsync().Result;
                ViewData["checkstatus"] = checkstatus;
                response = client.GetAsync("/api/test/getuser").Result;
                ViewData["user"] = response.Content.ReadAsStringAsync().Result;
                //List<Customer> data = JsonConvert.DeserializeObject<List<Customer>>(stringData);
                return View();
            }
        }
        // GET: api/Dashboard
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Dashboard/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Dashboard
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Dashboard/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
