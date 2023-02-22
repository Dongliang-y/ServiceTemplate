/*********************************************************** 
**项目名称:	 NPlatform.IServices                                                               				   
**功能描述:	  RoleServices 的摘要说明 
**作    者: 	此代码由CodeSmith生成。                                         			    
**版 本 号:	1.0                                           			
**修改历史： 
************************************************************/ 
namespace  NPlatform.Domains.Services.Sys
{ 
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using NPlatform.Domains.Entity.Sys;
    using NPlatform.Domains.IService.Sys;
    using NPlatform.Domains.Service;
    using NPlatform.Dto.Sys;
    using NPlatform.Commands.Sys;


    /// <summary> 
    ///    Role  业务层
    /// </summary> 
    public partial class RoleService : HandlerBase<RoleAdd,RoleDelete,RoleEdit>,IRoleService
    {  
        public override string GetDomainShortName()
        {
            return "Role";
        }
    } 
} 
 
