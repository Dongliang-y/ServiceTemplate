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
	/// Region，行政区划，ADD命令
	/// </summary>
    [DataContract]
    public partial class RegionAdd:RegionDto,ICommand
	{
        public CType CommandType=> CType.ADD;
        public  RegionAdd(string aggregateId) : base(aggregateId)
        {
        }
	}
    
    	/// <summary>
	/// Region，行政区划，EDIT命令
	/// </summary>
    [DataContract]
    public partial class RegionEdit:RegionDto,ICommand
	{
        public CType CommandType=> CType.EDIT;
        public  RegionEdit(string aggregateId) : base(aggregateId)
        {
        }
	}
    
    	/// <summary>
	/// Region，行政区划，DELETE 命令
	/// </summary>
    [DataContract]
    public partial class RegionDelete:RegionDto,ICommand
	{
        public Expression<Func<RegionDelete, bool>> filter;
        public CType CommandType=> CType.DELETE;
        public  RegionDelete(string aggregateId) : base(aggregateId)
        {
        }
	}
}
