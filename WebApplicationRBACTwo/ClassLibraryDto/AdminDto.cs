using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDto
{
    public class AdminDto
    {
        public int AdmId { get; set; }
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
        /// <summary>
        /// 末次登陆时间
        /// </summary>
        public DateTime? LastDateTime { get; set; }
        /// <summary>
        /// 当前时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
