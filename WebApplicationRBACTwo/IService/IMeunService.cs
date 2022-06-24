using ClassLibraryEntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IService
{
    public interface IMeunService
    {
        public List<Meun> GetMeun(int MeunId);
    }
}
