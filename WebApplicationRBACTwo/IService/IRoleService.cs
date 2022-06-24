using ClassLibraryEntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IService
{
    public interface IRoleService
    {
        /// <summary>
        /// 用户管理
        /// </summary>
        /// <returns></returns>
        public List<Role> RoleShow();
    }
}
