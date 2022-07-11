using AddGetUser_API.BE.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AddGetUser_API.BE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AnotherPolicy")]
    public class HomeController : ControllerBase
    {
        public string file = @"..\AddGetUser_API.BE\DB\DB.json";

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [EnableCors("AnotherPolicy")]
        [HttpGet] 
        public IEnumerable<UsersParametors> Get()
        { 
            List<UsersParametors> resultRows = new List<UsersParametors>();
            using (StreamReader r = new StreamReader(file))
            {
                string json = r.ReadToEnd();
                resultRows = JsonConvert.DeserializeObject<List<UsersParametors>>(json);
            } 
            // string json = JavaScriptSerializer.Serialize(new { UsersParametors = resultRows });
            return resultRows; 
        }

        [EnableCors("AnotherPolicy")]
        [HttpPost] 
        public void Post([FromBody] UsersParametors p)
        { 
            List<UsersParametors> resultRows = new List<UsersParametors>();
            using (StreamReader r = new StreamReader(file))
            {
                string readjson = r.ReadToEnd();
                resultRows = JsonConvert.DeserializeObject<List<UsersParametors>>(readjson);
            } 
            resultRows.Add(p);
            string json = JsonConvert.SerializeObject(resultRows.ToArray());
            System.IO.File.WriteAllText(file, json); 
        } 
    }
}
