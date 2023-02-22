﻿/***********************************************************
**项目名称:ZJJWFoundationPlatform.Dto                                                             	
**功能描述:	数据传输层
**作    者: 	codesmith脚本生成                                         			   
**版 本 号:	1.0                                                  
**修改历史：
************************************************************/

namespace  NPlatform.Dto.Sys
{
	using System;
	using System.Runtime.Serialization;
	using NPlatform;
    using System.ComponentModel.DataAnnotations;
	/// <summary>
	/// Message，消息表，数据传输对象
	/// </summary>
    [DataContract]
    public partial class MessageDto:BaseDto,IDto
	{
    	public MessageDto()
		{
		}
        public  MessageDto(string aggregateId):base(aggregateId)
		{ }
        
		/// <summary>
		/// 消息主键
		/// </summary>
        [Display(Name ="消息主键")]
		[StringLength(96)]
		[DataMember(Name= "id")]
        public string id { get; set; }

		/// <summary>
		/// 发送用户ID
		/// </summary>
        [Display(Name ="发送用户ID")]
		[StringLength(300)]
		[DataMember(Name= "user_id")]
        public string user_id { get; set; }

		/// <summary>
		/// 消息内容
		/// </summary>
        [Display(Name ="消息内容")]
		[StringLength(65535)]
		[DataMember(Name= "Contents")]
        public string Contents { get; set; }

		/// <summary>
		/// 发送时间
		/// </summary>
        [Display(Name ="发送时间")]
     [DisplayFormat(DataFormatString ="YYYY/MM/dd HH:mm:ss")]
		[DataMember(Name= "send_time")]
        public DateTime send_time { get; set; }

		/// <summary>
		/// 消息类型(DICT)
		/// </summary>
        [Display(Name ="消息类型(DICT)")]
		[StringLength(300)]
		[DataMember(Name= "type")]
        public string type { get; set; }

		/// <summary>
		/// 创建时间
		/// </summary>
        [Display(Name ="创建时间")]
     [DisplayFormat(DataFormatString ="YYYY/MM/dd HH:mm:ss")]
		[DataMember(Name= "create_time")]
        public DateTime create_time { get; set; }

		/// <summary>
		/// 创建人
		/// </summary>
        [Display(Name ="创建人")]
		[StringLength(1500)]
		[DataMember(Name= "create_user")]
        public string create_user { get; set; }
	}
}
