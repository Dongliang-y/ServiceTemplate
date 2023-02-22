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
	/// Position，岗位，ADD命令
	/// </summary>
    [DataContract]
    public partial class PositionAdd:PositionDto,ICommand
	{
        public CType CommandType=> CType.ADD;
        public  PositionAdd(string aggregateId) : base(aggregateId)
        {
        }
	}
    
    	/// <summary>
	/// Position，岗位，EDIT命令
	/// </summary>
    [DataContract]
    public partial class PositionEdit:PositionDto,ICommand
	{
        public CType CommandType=> CType.EDIT;
        public  PositionEdit(string aggregateId) : base(aggregateId)
        {
        }
	}
    
    	/// <summary>
	/// Position，岗位，DELETE 命令
	/// </summary>
    [DataContract]
    public partial class PositionDelete:PositionDto,ICommand
	{
        public Expression<Func<PositionDelete, bool>> filter;
        public CType CommandType=> CType.DELETE;
        public  PositionDelete(string aggregateId) : base(aggregateId)
        {
        }
	}
}
