/***********************************************************
**项目名称:ZJJWFoundationPlatform.Dto                                                             	
**功能描述:	数据传输层
**作    者: 	codesmith脚本生成                                         			   
**版 本 号:	1.0          
**创建日期： 2022-01-24 16:12
**修改历史：
************************************************************/

namespace NPlatform.Domains.Services.Sys
{
    using System;
    using System.Runtime.Serialization;
    using NPlatform.Domains.Service;
    using NPlatform.Domains.Entity.Sys;
    using NPlatform.Dto.Sys;
    using MediatR;
    using System.Threading.Tasks;
    using System.Threading;
    using NPlatform.Result;
    using NPlatform.Domains.IRepositories.Sys;
    using Microsoft.Extensions.Logging;
    using System.Net;
    using NPlatform.Domains.Entity;
    using NPlatform.Commands.Sys;
    using NPlatform.Extends;

    /// <summary>
    /// Country服务，默认基于Command实现
    /// </summary>
    public partial class CountryService 
    {
        public ILogger<CountryService> Loger { get; set; }
        public ICountryRepository Repository { get; set; }

        public async override Task<INPResult> Add(CountryAdd addCommand)
        {
            var vRst = addCommand.Validates();
            if (vRst.StatusCode != HttpStatusCode.OK.ToInt())
            {
                return vRst;
            }

            var country = this.mapperService.Map<Country>(addCommand);
            var rst = await Repository.AddAsync(country);
            return Success(rst.Id);
        }

        public async override Task<INPResult> Delete(CountryDelete deleteCommand)
        {
            var vRst = deleteCommand.Validates();
            if (vRst.StatusCode != HttpStatusCode.OK.ToInt())
            {
                return vRst;
            }
            var rstCount = 0;
            if (!string.IsNullOrWhiteSpace(deleteCommand.id))
            {
                rstCount = await this.Repository.RemoveAsync(deleteCommand.id);
            }
            else if (deleteCommand.filter != null)
            {
                // Func<Country, bool>
                 rstCount =await this.Repository.RemoveAsync(deleteCommand.filter.ConvertTo<CountryDelete, Country>());
            }

            return new SuccessResult<int>(rstCount);
        }

        public async override Task<INPResult> Edit(CountryEdit editCommand)
        {
            var vRst = editCommand.Validates();
            if (vRst.StatusCode != HttpStatusCode.OK.ToInt())
            {
                return vRst;
            }

            var country = this.mapperService.Map<Country>(editCommand);
            var rstCount =  await this.Repository.AddOrUpdate(country);
            return new SuccessResult<int>(rstCount);
        }
    }
}
