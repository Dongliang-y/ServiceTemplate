/*********************************************************** 
**项目名称:	 NPlatform.IServices                                                               				   
**功能描述:	  UserServices 的摘要说明 
**作    者: 	此代码由CodeSmith生成。                                         			    
**版 本 号:	1.0                                           			    
**创建日期： 2021-12-15 17:26
**修改历史： 
************************************************************/
namespace NPlatform.Domains.Services.Sys
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using NPlatform.Domains.Entity.Sys;
    using NPlatform.Domains.IService.Sys;
    using NPlatform.Domains.Service;
    using NPlatform.Dto.Sys;
    using NPlatform.Result;
    using NPlatform.Dto;
    using Microsoft.Extensions.Logging;
    using System.Threading;
    using NPlatform.Domains.IRepositories.Sys;
    using NPlatform.Query;
    using NPlatform.Commands.Sys;
    using NPlatform.DTO.VO;
    using NPlatform.Extends;

    /// <summary> 
    ///    User  业务层
    /// </summary> 
    public partial class UserService : IUserService
    {
        private const string MsgLoginFail = "用户名或者密码错误";
        private const string MsgUserNull = "用户或者密码不能为空！";

        public ILogger<UserService> Loger { get; set; }
        public IUserRepository Repository { get; set; }

        public async Task<IListResult<UserVO>> GetListAsync(QueryExp exp)
        {
            var vResult = exp.Validates();
            if (vResult.StatusCode == 200)
            {
                var users = await Repository.GetListByExpAsync(exp.GetExp<User>(), exp.GetSelectSorts());
                var userDtos = this.mapperService.Map<IEnumerable<User>, ListResult<UserVO>>(users);
                return userDtos;
            }
            return (IListResult<UserVO>)vResult;
        }
        public async Task<IListResult<UserVO>> GetListAsync(Expression<Func<User, bool>> filter)
        {
            var users = await Repository.GetListByExpAsync(filter);
            var userDtos = mapperService.Map<IEnumerable<User>, IListResult<UserVO>>(users);
            return userDtos;
        }
        public async Task<IListResult<UserVO>> GetPageAsync(QueryPageExp exp)
        {
            var vResult = exp.Validates();
            if (vResult.StatusCode == 200)
            {
                var users = await Repository.GetPagedAsync(exp.PageIndex, exp.PageSize, exp.GetExp<User>(), exp.GetSelectSorts());
                var userDtos = mapperService.Map<IListResult<User>, IListResult<UserVO>>(users);
                return userDtos;
            }
            return (IListResult<UserVO>)vResult;
        }


        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public async Task<INPResult> GetAsync(string userId)
        {
            if(string.IsNullOrEmpty(userId))
            {
                return base.ErrorParams<UserDto>(nameof(userId));
            }

            var user = await Repository.FindByAsync(userId);
            var userVo = mapperService.Map<UserVO>(user);
            return Success(userVo);
        }
        ///// <summary>
        ///// 获取用户
        ///// </summary>
        ///// <param name="userId">用户ID</param>
        ///// <returns></returns>
        //public async Task<INPResult> RemoveAsync(string[] userIds)
        //{
        //    if (userIds.Length==0)
        //    {
        //        return Error<UserDto>($"参数{nameof(userIds)}不能为空！");
        //    }

            
        //    return Success(user);
        //}


        public async Task<INPResult> PostAsync(UserAdd user)
        {
            var vResult = user.Validates();
            if (vResult.StatusCode == 200)
            {
                var userEntity = mapperService.Map<User>(user);
                userEntity.password = this.EncryptionPassword(userEntity.password);

                var userRst = await Repository.AddAsync(userEntity);
                user.id = userRst.Id;
                return Success(user);
            }
            return vResult;
        }

        /// <summary>
        /// password 
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private string EncryptionPassword(string password)
        {
            return HashCryptoHelper.GetSHA256(password);
        }

        public async Task<INPResult> PutAsync(UserEdit user)
        {
            var vResult = user.Validates();
            if (vResult.StatusCode == 200)
            {
                var userPut = mapperService.Map<User>(user);

                var userExit = await Repository.GetFirstOrDefaultAsync(t => t.Id == user.id);

                userPut.password = userExit.password;

                var userRst = await Repository.UpdateAsync(userPut);
                return Success(user);
            }
            return vResult;
        }

        /// <summary>
        /// 使用验证码修改密码
        /// </summary>
        /// <param name="userKey">用户ID、账号、手机号、邮箱</param>
        /// <param name="passwordNew1">新密码1</param>
        /// <param name="passwordNew2">新密码2</param>
        /// <param name="smsCode">短信验证码</param>
        /// <param name="emailCode">邮箱验证码</param>
        /// <param name="checkType">验证类型，1任意一个验证码通过即可，2两个验证码同时通过即可。</param>
        /// <returns></returns>
        public async Task<INPResult> ChangePasswordAsync(string userKey, string passwordNew1, string passwordNew2, string smsCode, string emailCode, int checkType = 1)
        {
            //this.EncryptionPassword(userEntity.password);
            throw new NotImplementedException();
        }

        public override Task<INPResult> Add(UserAdd addCommand)
        {
            throw new NotImplementedException();
        }

        public override Task<INPResult> Delete(UserDelete addCommand)
        {
            throw new NotImplementedException();
        }

        public override Task<INPResult> Edit(UserEdit addCommand)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 用户密码登录校验
        /// </summary>
        /// <param name="user">用户的key（账号、电话、邮箱）</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public async Task<INPResult> LoginValidate(string user,string password)
        {
            if(string.IsNullOrWhiteSpace(user)||string.IsNullOrWhiteSpace(password))
            {
                return Error(MsgUserNull);
            }

            // get user 
            var mdUser=await this.Repository.GetFirstOrDefaultAsync(t=>t.login_name == user||t.mobile_num==user||t.email==user);
            
            if(mdUser==null)
            {
                return Error(MsgLoginFail);
            }

            if(mdUser.password==this.EncryptionPassword(password))
            {
                return Success(mapperService.Map<UserDto>( mdUser));
            }
            else
            {
                return Error(MsgLoginFail);
            }
        }
    }
} 
 
