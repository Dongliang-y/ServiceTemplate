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
	/// Country，国家，ADD命令
	/// </summary>
    [DataContract]
    public partial class CountryAdd:CountryDto,ICommand
	{
        public CType CommandType=> CType.ADD;
        public  CountryAdd(string aggregateId) : base(aggregateId)
        {
        }
	}
    
    	/// <summary>
	/// Country，国家，EDIT命令
	/// </summary>
    [DataContract]
    public partial class CountryEdit:CountryDto,ICommand
	{
        public CType CommandType=> CType.EDIT;
        public  CountryEdit(string aggregateId) : base(aggregateId)
        {
        }
	}
    
    	/// <summary>
	/// Country，国家，DELETE 命令
	/// </summary>
    [DataContract]
    public partial class CountryDelete:CountryDto,ICommand
	{
        public Expression<Func<CountryDelete, bool>> filter;
        public CType CommandType=> CType.DELETE;
        public  CountryDelete(string aggregateId) : base(aggregateId)
        {
        }
	}
}
