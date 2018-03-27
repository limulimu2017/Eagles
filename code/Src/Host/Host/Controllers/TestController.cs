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

        [Route("api/test")]
        [HttpGet]
        public TestResponse Demo(TestRequest request)
        {
            return testHandler.Porcess(request);
        }
    }
}
