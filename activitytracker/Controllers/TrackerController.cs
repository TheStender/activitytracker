using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace activitytracker.Controllers
{
    [Produces("application/json")]
    [Route("api/Tracker")]
    public class TrackerController : Controller
    {
        // GET: api/Tracker
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Tracker/5
        [HttpGet("{id}", Name = "Get")]
        public int Get(int id)
        {
            return id;
        }

        // POST: api/Tracker
        [HttpPost]
        public object Post(PostData data)
        {
            //TODO: Save some stuff to a database
            var sqlTest = new SQLTest();
            sqlTest.saveTimeTracker(data.ActivityType, data.ActivityName, data.CurrentTime, data.TotalTime);
            return new { Success = true};
        }

        // PUT: api/Tracker/5
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

    public class PostData
    {
        public string ActivityType { get; set; }
        public string ActivityName { get; set; }
        public int CurrentTime { get; set; }
        public int TotalTime { get; set; }
    }
}
