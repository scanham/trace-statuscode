using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace trace_statuscode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("error-middleware/{id}")]
        public ActionResult<string> ErrorMiddleware(int id)
        {
            throw new Exception(id.ToString());
        }

        [HandleExceptionFilter]
        [Route("error-filter/{id}")]
        public ActionResult<string> ErrorFilter(int id)
        {
            throw new Exception(id.ToString());
        }

        [Route("error-method/{id}")]
        public ActionResult<string> ErrorMethod(int id)
        {
            try 
            {
                throw new Exception(id.ToString());
            }
            catch(Exception ex)
            {
                Response.StatusCode = Int32.Parse(ex.Message);
                return ex.Message;
            }
        }
    }
}
