using ClassLibraryDto;
using ClassLibraryEntityFrameWork;
using System.Collections.Generic;

namespace Application
{
    public interface IMeunService
    {
        List<MeunDto> MeunAll();

        int Del(int id);

        List<CreateDto> Cascading();
        int Add(AddDto c);
        Meun FanT(int id);
        int Upd(AddDto c);
        List<MeunListDto> MeunListAll();
    }
}