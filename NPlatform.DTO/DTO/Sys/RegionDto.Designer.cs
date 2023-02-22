/***********************************************************
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
	/// Region，行政区划，数据传输对象
	/// </summary>
    [DataContract]
    public partial class RegionDto:BaseDto,IDto
	{
    	public RegionDto()
		{
		}
        public  RegionDto(string aggregateId):base(aggregateId)
		{ }
        
		/// <summary>
		/// 区划id
		/// </summary>
        [Display(Name ="区划id")]
		[StringLength(150)]
		[DataMember(Name= "id")]
        public string id { get; set; }

		/// <summary>
		/// 名称
		/// </summary>
        [Display(Name ="名称")]
		[StringLength(600)]
		[DataMember(Name= "name")]
        public string name { get; set; }

		/// <summary>
		/// 简称
		/// </summary>
        [Display(Name ="简称")]
		[StringLength(600)]
		[DataMember(Name= "short_name")]
        public string short_name { get; set; }

		/// <summary>
		/// 全称
		/// </summary>
        [Display(Name ="全称")]
		[StringLength(600)]
		[DataMember(Name= "all_name")]
        public string all_name { get; set; }

		/// <summary>
		/// 等级
		/// </summary>
        [Display(Name ="等级")]
		[DataMember(Name= "at_level")]
        public int at_level { get; set; }

		/// <summary>
		/// 编码
		/// </summary>
        [Display(Name ="编码")]
		[StringLength(150)]
		[DataMember(Name= "code")]
        public string code { get; set; }

		/// <summary>
		/// 上级区划Id
		/// </summary>
        [Display(Name ="上级区划Id")]
		[StringLength(150)]
		[DataMember(Name= "parent_id")]
        public string parent_id { get; set; }

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
		/// 所在国家Id
		/// </summary>
        [Display(Name ="所在国家Id")]
		[StringLength(96)]
		[DataMember(Name= "country_id")]
        public string country_id { get; set; }
	}
}
