using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AddGetUser_API.BE.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AddGetUser_API.BE.Controllers
{
    [Route("api/[controller]")]
    public class TesterController : Controller
    {
        public string file = @"..\AddGetUser_API.BE\DB\DB.json";

        // GET: api/<controller>
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
         
        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]UsersParametors p)
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
