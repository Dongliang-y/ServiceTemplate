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
	/// Region仓储
	/// </summary>
    public partial class RegionRepository
	{
        ILogger<RegionRepository> logService;
        public override async Task<int> RemoveAsync(Expression<Func<Region, bool>> filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }
            var entitys = await this.GetListByExpAsync(filter);
            var removeCount = 0;
            var enabled = this.Options.QueryFilters.ContainsKey(nameof(LogicDeleteFilter));
            using (var unitwork = new UnitOfWork(Options))
            {
                if (typeof(ILogicDelete).IsAssignableFrom(typeof(Region)) && enabled)
                {

                    try
                    {
                        foreach (var entity in entitys)
                        {
                            var subRegions = entity.SubRegion;
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
                        this.logService.LogTrace("{0}-逻辑删除数据：{1}，", typeof(Region).Name, ids);
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
                    logService.LogTrace("{0}-物理删除数据：{1}", typeof(Region).Name, filter.ToString());

                    foreach (var region in entitys)
                    {
                        removeCount += await unitwork.RemoveAsync(region.SubRegion);
                    }
                    removeCount += await unitwork.RemoveAsync(entitys);
                    return removeCount;
                }
            }
        }
    }
}
