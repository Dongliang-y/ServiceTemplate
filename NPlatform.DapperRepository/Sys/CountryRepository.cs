/***********************************************************
**项目名称:ZJJWFoundationPlatform.Dto                                                             	
**功能描述:	数据传输层
**作    者: 	codesmith脚本生成                                         			   
**版 本 号:	1.0          
**创建日期： 2022-01-25 15:03
**修改历史：
************************************************************/

namespace   NPlatform.Repositories.Sys
{
	using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using NPlatform;
    using NPlatform.Domains.Entity.Sys;
    using NPlatform.Filters;
    using NPlatform.Repositories.IRepositories;


    /// <summary>
    /// Country仓储
    /// </summary>
    public partial class CountryRepository
    {
        ILogger<CountryRepository> logService;
        public override async Task<int> RemoveAsync(Expression<Func<Country, bool>> filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }
            var entitys =await this.GetListByExpAsync(filter);
            var removeCount = 0;
            var enabled = this.Options.QueryFilters.ContainsKey(nameof(LogicDeleteFilter));
            using (var unitwork = new UnitOfWork(Options))
            {
                if (typeof(ILogicDelete).IsAssignableFrom(typeof(Country)) && enabled)
                {

                    try
                    {
                        foreach (var entity in entitys)
                        {
                            var subRegions = entity.Regions;
                            foreach (var reg in subRegions)
                            {
                                ((ILogicDelete)reg).IsDeleted = true;
                                await unitwork.ChangeAsync(reg);
                                removeCount++;
                            }

                            ((ILogicDelete)entity).IsDeleted = true;
                            await unitwork.ChangeAsync(entity);
                            removeCount++;
                        }
                        var keys = entitys.Select(t => t.Id);
                        var ids = string.Join(",", keys);
                        this.logService.LogTrace("{0}-逻辑删除数据：{1}，", typeof(Country).Name, ids);
                        unitwork.Commit();
                        return removeCount;
                    }
                    catch
                    {
                        unitwork.Rollback();
                        throw;
                    }
                }
                else
                {
                    logService.LogTrace("{0}-物理删除数据：{1}", typeof(Country).Name, filter.ToString());

                    foreach(var country in entitys)
                    {
                        removeCount+= await unitwork.RemoveAsync<Region>(country.Regions);
                    }
                    removeCount+=await unitwork.RemoveAsync<Country>(entitys);
                    return removeCount;
                }
            }
        }

    }
}
