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
	/// Resources，资源，ADD命令
	/// </summary>
    [DataContract]
    public partial class ResourcesAdd:ResourcesDto,ICommand
	{
        public CType CommandType=> CType.ADD;
        public  ResourcesAdd(string aggregateId) : base(aggregateId)
        {
        }
	}
    
    	/// <summary>
	/// Resources，资源，EDIT命令
	/// </summary>
    [DataContract]
    public partial class ResourcesEdit:ResourcesDto,ICommand
	{
        public CType CommandType=> CType.EDIT;
        public  ResourcesEdit(string aggregateId) : base(aggregateId)
        {
        }
	}
    
    	/// <summary>
	/// Resources，资源，DELETE 命令
	/// </summary>
    [DataContract]
    public partial class ResourcesDelete:ResourcesDto,ICommand
	{
        public Expression<Func<ResourcesDelete, bool>> filter;
        public CType CommandType=> CType.DELETE;
        public  ResourcesDelete(string aggregateId) : base(aggregateId)
        {
        }
	}
}
