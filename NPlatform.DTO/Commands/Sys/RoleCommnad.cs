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
	/// Role，角色，ADD命令
	/// </summary>
    [DataContract]
    public partial class RoleAdd:RoleDto,ICommand
	{
        public CType CommandType=> CType.ADD;
        public  RoleAdd(string aggregateId) : base(aggregateId)
        {
        }
	}
    
    	/// <summary>
	/// Role，角色，EDIT命令
	/// </summary>
    [DataContract]
    public partial class RoleEdit:RoleDto,ICommand
	{
        public CType CommandType=> CType.EDIT;
        public  RoleEdit(string aggregateId) : base(aggregateId)
        {
        }
	}
    
    	/// <summary>
	/// Role，角色，DELETE 命令
	/// </summary>
    [DataContract]
    public partial class RoleDelete:RoleDto,ICommand
	{
        public Expression<Func<RoleDelete, bool>> filter;
        public CType CommandType=> CType.DELETE;
        public  RoleDelete(string aggregateId) : base(aggregateId)
        {
        }
	}
}
