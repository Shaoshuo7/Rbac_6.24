using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEntityFrameWork
{
    public class BaseClass
    {
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 最后一次登录时间
        /// </summary>
        public int CreateId { get; set; }
        /// <summary>
        /// 最后一次登录IP
        /// </summary>
        public bool IsDelete { get; set; }
    }
}
