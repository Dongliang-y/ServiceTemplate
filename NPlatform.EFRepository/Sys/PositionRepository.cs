/***********************************************************
**项目名称:ZJJWFoundationPlatform.Dto                                                             	
**功能描述:	数据传输层
**作    者: 	codesmith脚本生成                                         			   
**版 本 号:	1.0          
**创建日期： 2022-01-24 16:12
**修改历史：
************************************************************/

namespace   NPlatform.Repositories.Sys
{
	using System;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;
    using System.Threading.Tasks;
    using NPlatform;
    using NPlatform.Domains.Entity.Sys;
    using NPlatform.Repositories.IRepositories;


    /// <summary>
    /// Position仓储
    /// </summary>
    public partial class PositionRepository
    {
        public override Task<int> RemoveAsync(Expression<Func<Position, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
