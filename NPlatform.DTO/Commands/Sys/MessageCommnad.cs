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
	/// Message，消息表，ADD命令
	/// </summary>
    [DataContract]
    public partial class MessageAdd:MessageDto,ICommand
	{
        public CType CommandType=> CType.ADD;
        public  MessageAdd(string aggregateId) : base(aggregateId)
        {
        }
	}
    
    	/// <summary>
	/// Message，消息表，EDIT命令
	/// </summary>
    [DataContract]
    public partial class MessageEdit:MessageDto,ICommand
	{
        public CType CommandType=> CType.EDIT;
        public  MessageEdit(string aggregateId) : base(aggregateId)
        {
        }
	}
    
    	/// <summary>
	/// Message，消息表，DELETE 命令
	/// </summary>
    [DataContract]
    public partial class MessageDelete:MessageDto,ICommand
	{
        public Expression<Func<MessageDelete, bool>> filter;
        public CType CommandType=> CType.DELETE;
        public  MessageDelete(string aggregateId) : base(aggregateId)
        {
        }
	}
}
