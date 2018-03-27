using Eagles.Interface.Core;

namespace Eagles.DomainService.Model
{
    public class TestIoc: ITestIOC
    {
        public string Test(string id)
        {
            return id + "is done";
        }
    }
}
