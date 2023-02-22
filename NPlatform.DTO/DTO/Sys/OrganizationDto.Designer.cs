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
	/// Organization，机构，数据传输对象
	/// </summary>
    [DataContract]
    public partial class OrganizationDto:BaseDto,IDto
	{
    	public OrganizationDto()
		{
		}
        public  OrganizationDto(string aggregateId):base(aggregateId)
		{ }
        
		/// <summary>
		/// 机构编码
		/// </summary>
        [Display(Name ="机构编码")]
		[StringLength(150)]
		[DataMember(Name= "id")]
        public string id { get; set; }

		/// <summary>
		/// 机构名称
		/// </summary>
        [Display(Name ="机构名称")]
		[StringLength(3000)]
		[DataMember(Name= "name")]
        public string name { get; set; }

		/// <summary>
		/// 机构简称
		/// </summary>
        [Display(Name ="机构简称")]
		[StringLength(3000)]
		[DataMember(Name= "short_name")]
        public string short_name { get; set; }

		/// <summary>
		/// 机构英文名称
		/// </summary>
        [Display(Name ="机构英文名称")]
		[StringLength(3000)]
		[DataMember(Name= "english_name")]
        public string english_name { get; set; }

		/// <summary>
		/// 机构全拼名称
		/// </summary>
        [Display(Name ="机构全拼名称")]
		[StringLength(3000)]
		[DataMember(Name= "pingyin")]
        public string pingyin { get; set; }

		/// <summary>
		/// 机构简拼名称
		/// </summary>
        [Display(Name ="机构简拼名称")]
		[StringLength(3000)]
		[DataMember(Name= "short_pingyin")]
        public string short_pingyin { get; set; }

		/// <summary>
		/// 多机构类型(DICT)
		/// </summary>
        [Display(Name ="多机构类型(DICT)")]
		[StringLength(300)]
		[DataMember(Name= "multi_org_type")]
        public string multi_org_type { get; set; }

		/// <summary>
		/// 机构组织类型(DICT)
		/// </summary>
        [Display(Name ="机构组织类型(DICT)")]
		[StringLength(300)]
		[DataMember(Name= "organization_type")]
        public string organization_type { get; set; }

		/// <summary>
		/// 机构业务类型(DICT)
		/// </summary>
        [Display(Name ="机构业务类型(DICT)")]
		[StringLength(300)]
		[DataMember(Name= "buz_type")]
        public string buz_type { get; set; }

		/// <summary>
		/// 机构所在地点
		/// </summary>
        [Display(Name ="机构所在地点")]
		[StringLength(1500)]
		[DataMember(Name= "address")]
        public string address { get; set; }

		/// <summary>
		/// 是否虑机构
		/// </summary>
        [Display(Name ="是否虑机构")]
		[DataMember(Name= "virtualed")]
        public int virtualed { get; set; }

		/// <summary>
		/// 机构层级编码
		/// </summary>
        [Display(Name ="机构层级编码")]
		[StringLength(1500)]
		[DataMember(Name= "level_code")]
        public string level_code { get; set; }

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

		/// <summary>
		/// 排序号
		/// </summary>
        [Display(Name ="排序号")]
		[DataMember(Name= "sorted_num")]
        public int sorted_num { get; set; }

		/// <summary>
		/// 第一负责人
		/// </summary>
        [Display(Name ="第一负责人")]
		[StringLength(1500)]
		[DataMember(Name= "principal")]
        public string principal { get; set; }

		/// <summary>
		/// 父机构ID
		/// </summary>
        [Display(Name ="父机构ID")]
		[StringLength(150)]
		[DataMember(Name= "parent_id")]
        public string parent_id { get; set; }
	}
}
