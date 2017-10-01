using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using Wondertree.Models;
using Newtonsoft.Json;

namespace Wondertree.Controllers
{
    [Produces("application/json")]
    [Route("Dashboard")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            Dashboard db = new Dashboard();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://wondertreetest.azurewebsites.net");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                               

                ICollection<KeyValuePair> datapoints = JsonConvert.DeserializeObject<ICollection<KeyValuePair>>(GetResponse(client, "/api/test/makegraph"));
                db.DataPoints = datapoints;

                string userstring = GetResponse(client, "/api/test/getuser");
                User user = JsonConvert.DeserializeObject<User>(userstring);
                db.User = user;

                Status status = JsonConvert.DeserializeObject<Status>(GetResponse(client, "/api/test/checkstatus"));
                db.Status = status;
            }
            return View(db);
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

        private string GetResponse(HttpClient client, string uri)
        {
            HttpResponseMessage response;
            string checkstatus;
            do
            {
                response = client.GetAsync(uri).Result;
                checkstatus = response.Content.ReadAsStringAsync().Result;
            } while (!response.IsSuccessStatusCode);

            return checkstatus;
        }
    }
}
