﻿/***********************************************************
**项目名称:NPlatform.Entity                                                                				   
**功能描述:	 Group   的摘要说明
**作    者: 	此代码由CodeSmith生成。                                         			   
**版 本 号:	1.0          
**修改历史：
************************************************************/

namespace NPlatform.Domains.Entity.Sys
{
    using NPlatform.Domains.Entity;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
	/// <summary>
	///Group，用户组
	/// </summary>
	[Serializable]
    [Table(name:"sys_group")]
    public partial class Group : EntityBase<string>, ISys
	{
		/// <summary>
		/// 名称
		/// </summary>
		
        [Display(Name = "名称")]
        [StringLength(1500)]
        public string name { get; set; }

		/// <summary>
		/// 描述
		/// </summary>
		
        [Display(Name = "描述")]
        [StringLength(6000)]
        public string descrption { get; set; }

		/// <summary>
		/// 创建时间
		/// </summary>
		
        [Display(Name = "创建时间")]
        public DateTime? create_time { get; set; }

		/// <summary>
		/// 创建人
		/// </summary>
		
        [Display(Name = "创建人")]
        [StringLength(1500)]
        public string create_user { get; set; }
	}
}
