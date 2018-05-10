using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Eagles.Application.Model.Test;
using Eagles.Base.Configuration;
using Eagles.Interface.Core.Test;
using Eagles.Interface.Infrastructure.DataAccess;
using DBModel= Ealges.Infrastructure.DataBaseModel.Model;

namespace Eagles.DomainService.Core.Test
{
    public class TestHandler: ITestHandler
    {
        private readonly IAreaDataAccess areaData;

        private readonly IConfigurationManager configurationManager;

        public TestHandler(IAreaDataAccess areaData, IConfigurationManager configurationManager)
        {
            this.areaData = areaData;
            this.configurationManager = configurationManager;
        }

        public TestResponse Porcess(TestRequest request)
        {
            var s=configurationManager.GetConfiguration<TestConfig>();
            var areaInfo = areaData.GetAreas(request.Id);
            var result = new TestResponse()
            {
                AreaInfo = new List<AreaInfo>()
                {

                },
                DateTime = DateTime.Now,
                TestNode = s.TestNode
            };
            areaInfo.ForEach(x => result.AreaInfo.Add(ConvertAreaInfo(x)));
            return result;
        }

        private AreaInfo ConvertAreaInfo(DBModel.Area areaInfo)
        {
            return new AreaInfo
            {
                AreaId = areaInfo.AreaId,
                AreaName =areaInfo.AreaName
            };
        }
    }

    [XmlRoot("Configuration")]
    [XmlPath("/Configuration/Test.config")]
    public class TestConfig
    {
        public string TestNode { get; set; }
    }
}
