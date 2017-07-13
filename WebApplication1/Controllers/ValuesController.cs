using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Couchbase.Core;
using Couchbase.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
	    private readonly ILogger<ValuesController> _logger;
	    private readonly IBucket _bucket;

	    public ValuesController(ILogger<ValuesController> logger, IBucketProvider provider)
	    {
		    _logger = logger;
		    _bucket = provider.GetBucket("default");
		}

		// GET api/values
		[HttpGet]
        public IEnumerable<string> Get()
		{
			var result = _bucket.Get<List<string>>("data");
			if (result.Success)
			{
				return result.Value;
			}

			_logger.LogDebug("error retriving items");
			return null;
		}

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
