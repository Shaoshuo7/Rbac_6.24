using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClassLibraryEntityFrameWork
{
    [Table("Meun")]
    public class Meun : BaseClass
    {
        [Key]
        public int MeunId { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        [StringLength(50)]
        public string MeunName { get; set; }
        /// <summary>
        /// 父Id
        /// </summary>
        public int MeId { get; set; }
        /// <summary>
        /// 菜单连接
        /// </summary>
        public string MeunLink { get; set; }
        public bool IsDefault { get; set; }
    }
}
