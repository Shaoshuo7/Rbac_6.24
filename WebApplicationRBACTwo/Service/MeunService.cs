using ClassLibraryEntityFrameWork;
using IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class MeunService : IMeunService
    {
        public MeunService(MyDbContext myDbContext)
        { 
            MyDbContext = myDbContext;
        }
        public MyDbContext MyDbContext { get;}

        /// <summary>
        /// 查找下一级
        /// </summary>
        /// <param name="MeunId"></param>
        /// <returns></returns>
        public List<Meun> GetMeun(int MeunId)
        {
            var list = MyDbContext.Meun.Where(t => t.MeId == MeunId);

            return list.ToList();
        }
    }
}
