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
	/// Duty，职务，ADD命令
	/// </summary>
    [DataContract]
    public partial class DutyAdd:DutyDto,ICommand
	{
        public CType CommandType=> CType.ADD;
        public  DutyAdd(string aggregateId) : base(aggregateId)
        {
        }
	}
    
    	/// <summary>
	/// Duty，职务，EDIT命令
	/// </summary>
    [DataContract]
    public partial class DutyEdit:DutyDto,ICommand
	{
        public CType CommandType=> CType.EDIT;
        public  DutyEdit(string aggregateId) : base(aggregateId)
        {
        }
	}
    
    	/// <summary>
	/// Duty，职务，DELETE 命令
	/// </summary>
    [DataContract]
    public partial class DutyDelete:DutyDto,ICommand
	{
        public Expression<Func<DutyDelete, bool>> filter;
        public CType CommandType=> CType.DELETE;
        public  DutyDelete(string aggregateId) : base(aggregateId)
        {
        }
	}
}
