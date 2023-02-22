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
	/// Unit，单位，ADD命令
	/// </summary>
    [DataContract]
    public partial class UnitAdd:UnitDto,ICommand
	{
        public CType CommandType=> CType.ADD;
        public  UnitAdd(string aggregateId) : base(aggregateId)
        {
        }
	}
    
    	/// <summary>
	/// Unit，单位，EDIT命令
	/// </summary>
    [DataContract]
    public partial class UnitEdit:UnitDto,ICommand
	{
        public CType CommandType=> CType.EDIT;
        public  UnitEdit(string aggregateId) : base(aggregateId)
        {
        }
	}
    
    	/// <summary>
	/// Unit，单位，DELETE 命令
	/// </summary>
    [DataContract]
    public partial class UnitDelete:UnitDto,ICommand
	{
        public Expression<Func<UnitDelete, bool>> filter;
        public CType CommandType=> CType.DELETE;
        public  UnitDelete(string aggregateId) : base(aggregateId)
        {
        }
	}
}
