using System.Web.Http;

namespace Eagles.Application
{
    public class TestController: ApiController
    {
        [HttpGet]
        [Route("api/test")]
        public string TestDemo()
        {
            return "hello web api";
        }
    }
}
