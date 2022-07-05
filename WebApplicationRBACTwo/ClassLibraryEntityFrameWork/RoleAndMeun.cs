using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClassLibraryEntityFrameWork
{
    [Table("RoleAndMeun")]
    public class RoleAndMeun
    {
        [Key]
        public int RoleAndMeunId { get; set; }
        public int RoleId { get; set; }
        public int MeunId { get; set; }
    }
}
