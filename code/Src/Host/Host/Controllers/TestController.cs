using System.Web.Http;
using Eagles.Application.Model.Test;
using Eagles.Interface.Core.Test;

namespace Eagles.Host.Controllers
{
    public class TestController : ApiController
    {
        private ITestHandler testHandler;

        public TestController(ITestHandler testHandler)
        {
            this.testHandler = testHandler;
        }

        /// <summary>
        /// Demo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("api/test")]
        [HttpPost]
        public TestResponse Demo(TestRequest request)
        {
            return testHandler.Porcess(request);
        }
    }
}
