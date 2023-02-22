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
    using System.Linq.Expressions;
    using System.Runtime.Serialization;
    using System.Threading.Tasks;
    using NPlatform;
    using NPlatform.Domains.Entity.Sys;
    using NPlatform.Repositories.IRepositories;


    /// <summary>
    /// Group仓储
    /// </summary>
    public partial class GroupRepository
    {
        public override Task<int> RemoveAsync(Expression<Func<Group, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
