using Challenge.Operation;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Challenge.Controllers
{
    public class PremiumController : ApiController
    {

        /// <summary>
        /// GET Premium
        /// </summary>
        /// <remarks>
        ///     Content Type": "application/json"
        /// </remarks>
        /// <param name="dateOfBirth"></param>
        /// <param name="state"></param>    
        /// <param name="age"></param>    
        /// <param name="plan"></param>    
        [HttpGet, Route("getPremium")]
        public HttpResponseMessage getPremium(string plan, string state, string dateOfBirth, int age)
        {             
            var response = OperationClass.getPremium(plan, state, dateOfBirth, age);
            var httpStatusCode  = HttpStatusCode.OK;

            return Request.CreateResponse(httpStatusCode, response);
        }

        [HttpGet, Route("getStates")]
        public IHttpActionResult getStates()
        {
            var response = OperationClass.getStates();
            return Ok(response);
        }


    }
}
