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
	/// Group，用户组，ADD命令
	/// </summary>
    [DataContract]
    public partial class GroupAdd:GroupDto,ICommand
	{
        public CType CommandType=> CType.ADD;
        public  GroupAdd(string aggregateId) : base(aggregateId)
        {
        }
	}
    
    	/// <summary>
	/// Group，用户组，EDIT命令
	/// </summary>
    [DataContract]
    public partial class GroupEdit:GroupDto,ICommand
	{
        public CType CommandType=> CType.EDIT;
        public  GroupEdit(string aggregateId) : base(aggregateId)
        {
        }
	}
    
    	/// <summary>
	/// Group，用户组，DELETE 命令
	/// </summary>
    [DataContract]
    public partial class GroupDelete:GroupDto,ICommand
	{
        public Expression<Func<GroupDelete, bool>> filter;
        public CType CommandType=> CType.DELETE;
        public  GroupDelete(string aggregateId) : base(aggregateId)
        {
        }
	}
}
