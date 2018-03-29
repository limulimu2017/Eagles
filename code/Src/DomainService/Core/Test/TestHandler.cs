using System;
using System.Collections.Generic;
using Eagles.Application.Model.Test;
using Eagles.Interface.Core.Test;
using Eagles.Interface.Infrastructure.DataAccess;
using DBModel= Ealges.Infrastructure.DataBaseModel.Model;

namespace Eagles.DomainService.Core.Test
{
    public class TestHandler: ITestHandler
    {
        private readonly IAreaDataAccess areaData;

        public TestHandler(IAreaDataAccess areaData)
        {
            this.areaData = areaData;
        }

        public TestResponse Porcess(TestRequest request)
        {
            var areaInfo = areaData.GetAreas(request.Id);
            var result = new TestResponse()
            {
                AreaInfo = new List<AreaInfo>()
                {
                    
                },
                DateTime = DateTime.Now
            };
            areaInfo.ForEach(x=>result.AreaInfo.Add(ConvertAreaInfo(x)));
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
}
