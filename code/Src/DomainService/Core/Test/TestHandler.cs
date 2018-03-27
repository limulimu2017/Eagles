using System;
using Eagles.Application.Model.Test;
using Eagles.Interface.Core;
using Eagles.Interface.Core.Test;

namespace Eagles.DomainService.Core.Test
{
    public class TestHandler: ITestHandler
    {
        private readonly ITestIOC testIoc;

        private readonly ITestIOC2 testIoc2;

        public TestHandler(ITestIOC testIoc, ITestIOC2 testIoc2)
        {
            this.testIoc = testIoc;
            this.testIoc2 = testIoc2;
        }

        public TestResponse Porcess(TestRequest request)
        {
            var s = testIoc.Test("id");
            var name = testIoc2.Get();
            return new TestResponse()
            {
                Id = s,
                Name = name,
                DateTime = new DateTime()
            };
        }
    }
}
