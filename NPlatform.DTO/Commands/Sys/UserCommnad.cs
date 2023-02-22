/***********************************************************
**项目名称:ZJJWFoundationPlatform.Dto                                                             	
**功能描述:	数据传输层
**作    者: 	codesmith脚本生成                                         			   
**版 本 号:	1.0                                                  
**修改历史：
************************************************************/

namespace  NPlatform.Commands.Sys
{
	using System;
	using System.Runtime.Serialization;
    using System.ComponentModel.DataAnnotations;
	using NPlatform;
    using NPlatform.Dto.Sys;
    using NPlatform.Enums;
    using System.Linq.Expressions;
    
	/// <summary>
	/// User，用户，ADD命令
	/// </summary>
    [DataContract]
    public partial class UserAdd:UserDto,ICommand
	{
        /// <summary>
		/// 登录密码
		/// </summary>
		[Display(Name = "登录密码")]
        [StringLength(150)]
        [RegularExpression(RegularExpression.PasswordRex)]
        public new string password { get; set; }


        public CType CommandType=> CType.ADD;
        public  UserAdd(string aggregateId) : base(aggregateId)
        {
        }
	}
    
    	/// <summary>
	/// User，用户，EDIT命令
	/// </summary>
    [DataContract]
    public partial class UserEdit:UserDto,ICommand
	{
        public CType CommandType=> CType.EDIT;
        public  UserEdit(string aggregateId) : base(aggregateId)
        {
        }
	}
    
    	/// <summary>
	/// User，用户，DELETE 命令
	/// </summary>
    [DataContract]
    public partial class UserDelete:UserDto,ICommand
	{
        public Expression<Func<UserDelete, bool>> filter;
        public CType CommandType=> CType.DELETE;
        public  UserDelete(string aggregateId) : base(aggregateId)
        {
        }
	}
}
