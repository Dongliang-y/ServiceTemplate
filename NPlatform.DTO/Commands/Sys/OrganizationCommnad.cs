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
	/// Organization，机构，ADD命令
	/// </summary>
    [DataContract]
    public partial class OrganizationAdd:OrganizationDto,ICommand
	{
        public CType CommandType=> CType.ADD;
        public  OrganizationAdd(string aggregateId) : base(aggregateId)
        {
        }
	}
    
    	/// <summary>
	/// Organization，机构，EDIT命令
	/// </summary>
    [DataContract]
    public partial class OrganizationEdit:OrganizationDto,ICommand
	{
        public CType CommandType=> CType.EDIT;
        public  OrganizationEdit(string aggregateId) : base(aggregateId)
        {
        }
	}
    
    	/// <summary>
	/// Organization，机构，DELETE 命令
	/// </summary>
    [DataContract]
    public partial class OrganizationDelete:OrganizationDto,ICommand
	{
        public Expression<Func<OrganizationDelete, bool>> filter;
        public CType CommandType=> CType.DELETE;
        public  OrganizationDelete(string aggregateId) : base(aggregateId)
        {
        }
	}
}
