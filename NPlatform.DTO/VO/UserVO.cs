/**************************************************************
 *  Filename:    UserVO.cs
 *  Copyright:    Co., Ltd.
 *
 *  Description: UserVO ClassFile.
 *
 *  @author:     Dongliang Yi
 *  @version     2022/2/15 9:10:18  @Reviser  Initial Version
 **************************************************************/
using NPlatform.Dto.Sys;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NPlatform.DTO.VO
{
    [DataContract]
    public class UserVO : UserDto, IVO
    {
        /// <summary>
        /// 登录密码
        /// </summary>
        [Display(Name = "登录密码")]
        [StringLength(150)]
        public new string password { private get; set; }
    }
}
