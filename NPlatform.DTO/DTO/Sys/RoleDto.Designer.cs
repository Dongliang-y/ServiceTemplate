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
	/// Role，角色，数据传输对象
	/// </summary>
    [DataContract]
    public partial class RoleDto:BaseDto,IDto
	{
    	public RoleDto()
		{
		}
        public  RoleDto(string aggregateId):base(aggregateId)
		{ }
        
		/// <summary>
		/// 编码
		/// </summary>
        [Display(Name ="编码")]
		[StringLength(150)]
		[DataMember(Name= "id")]
        public string id { get; set; }

		/// <summary>
		/// 名称
		/// </summary>
        [Display(Name ="名称")]
		[StringLength(1500)]
		[DataMember(Name= "name")]
        public string name { get; set; }

		/// <summary>
		/// 角色分类id
		/// </summary>
        [Display(Name ="角色分类id")]
		[StringLength(150)]
		[DataMember(Name= "role_type_id")]
        public string role_type_id { get; set; }

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
	}
}
