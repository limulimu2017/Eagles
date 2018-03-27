using Eagles.Application.Model;
using System.Web.Http;
using Eagles.Interface.Core;

namespace Eagles.Host.Controllers
{
    public class TestController : ApiController
    {
        private readonly ITestIOC testIoc;

        private readonly ITestIOC2 testIoc2;

        public TestController(ITestIOC testIoc, ITestIOC2 testIoc2)
        {
            this.testIoc = testIoc;
            this.testIoc2 = testIoc2;
        }

        [Route("api/test")]
        [HttpGet]
        public TestModel Demo()
        {
            var s = testIoc.Test("id");
            var name=testIoc2.Get();
            return new TestModel()
            {
                Id = s,
                Name = name
            };
        }
    }
}
