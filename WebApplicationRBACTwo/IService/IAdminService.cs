using ClassLibraryEntityFrameWork;
using System;
using System.Collections.Generic;

namespace IService
{
    public interface IAdminService
    {
        /// <summary>
        /// 用户管理
        /// </summary>
        /// <returns></returns>
        public List<Admin> AdminShow();

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int AdminDel(int id);

        /// <summary>
        /// 反填用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Admin AdminFanT(int id);

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public int AdminUpd(Admin c);
    }
}
