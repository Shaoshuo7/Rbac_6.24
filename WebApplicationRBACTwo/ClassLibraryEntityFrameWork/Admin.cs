using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ClassLibraryEntityFrameWork
{
    /// <summary>
    /// 管理员
    /// </summary>
    [Table("Admin")]
    public class Admin : BaseClass
    {
        [Key]
        public int AdminId { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public string AdmName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string AdmPassWord { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string AdmEmail { get; set; }

        public DateTime LastDateTime { get; set; }
        public string LastLoginIP { get; set; }
        public bool IsLock { get; set; }
        //public List<AdminAndRole> AdminAndRole { get; set; }
    }
}
