/*********************************************************** 
**项目名称:	 NPlatform.IServices                                                               				   
**功能描述:	  UserServices 的摘要说明 
**作    者: 	此代码由CodeSmith生成。                                         			    
**版 本 号:	1.0                                           			    
**创建日期： 2022-01-24 16:12
**修改历史： 
************************************************************/ 
namespace  NPlatform.Domains.IService.Sys
{ 
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using NPlatform.Domains.Service;
    using NPlatform.Domains.Entity.Sys;
    using NPlatform.Dto.Sys;
    using Microsoft.Extensions.Logging;
    using NPlatform.Domains.IRepositories.Sys;
    using System.Threading.Tasks;
    using NPlatform.Result;
    using NPlatform.Dto;
    using NPlatform.Query;
    using NPlatform.DTO.VO;
    using NPlatform.Commands.Sys;

    /// <summary> 
    ///    User  业务层
    /// </summary> 
    public partial interface IUserService : IDomainService
    {
        Task<INPResult> ChangePasswordAsync(string userKey, string passwordNew1, string passwordNew2, string smsCode, string emailCode, int checkType = 1);
        Task<IListResult<UserVO>> GetListAsync(Expression<Func<User, bool>> filter);
        Task<IListResult<UserVO>> GetListAsync(QueryExp exp);
        Task<IListResult<UserVO>> GetPageAsync(QueryPageExp exp);

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        Task<INPResult> GetAsync(string userId);

        Task<INPResult> PostAsync(UserAdd user);
        Task<INPResult> PutAsync(UserEdit user);

        /// <summary>
        /// 登录校验
        /// </summary>
        /// <param name="user">登录账号、手机号、邮箱</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        Task<INPResult> LoginValidate(string user,string password);
    } 
} 
 
