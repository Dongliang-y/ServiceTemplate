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
	/// Country，国家，数据传输对象
	/// </summary>
    [DataContract]
    public partial class CountryDto:BaseDto,IDto
	{
    	public CountryDto()
		{
		}
        public  CountryDto(string aggregateId):base(aggregateId)
		{ }
        
		/// <summary>
		/// ID
		/// </summary>
        [Display(Name ="ID")]
		[StringLength(96)]
		[DataMember(Name= "id")]
        public string id { get; set; }

		/// <summary>
		/// 国家编码
		/// </summary>
        [Display(Name ="国家编码")]
		[StringLength(150)]
		[DataMember(Name= "code")]
        public string code { get; set; }

		/// <summary>
		/// 国家全称
		/// </summary>
        [Display(Name ="国家全称")]
		[StringLength(600)]
		[DataMember(Name= "all_name")]
        public string all_name { get; set; }

		/// <summary>
		/// 国家名称
		/// </summary>
        [Display(Name ="国家名称")]
		[StringLength(600)]
		[DataMember(Name= "name")]
        public string name { get; set; }

		/// <summary>
		/// 国家分类（DICT）
		/// </summary>
        [Display(Name ="国家分类（DICT）")]
		[StringLength(600)]
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

		/// <summary>
		/// 排序号
		/// </summary>
        [Display(Name ="排序号")]
		[DataMember(Name= "sorted_num")]
        public int sorted_num { get; set; }

		/// <summary>
		/// 国际域名缩写
		/// </summary>
        [Display(Name ="国际域名缩写")]
		[StringLength(600)]
		[DataMember(Name= "dnsname")]
        public string dnsname { get; set; }

		/// <summary>
		/// 时差
		/// </summary>
        [Display(Name ="时差")]
		[StringLength(600)]
		[DataMember(Name= "time_diff")]
        public string time_diff { get; set; }
	}
}
