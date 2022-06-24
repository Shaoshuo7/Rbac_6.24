using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClassLibraryEntityFrameWork
{
    [Table("AdminAndRole")]
    public class AdminAndRole
    {
        [Key]
        public int AdminAndRoleId { get; set; }
        /// <summary>
        /// 管理员Id
        /// </summary>
        public int AdmId { get; set; }
        /// <summary>
        /// 角色Id
        /// </summary>
        public int RoleId { get; set; }

        [ForeignKey("AdmId")]
        public Admin Admin { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }
    }
}
