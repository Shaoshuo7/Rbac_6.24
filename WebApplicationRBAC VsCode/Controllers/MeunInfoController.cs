using ClassLibraryEntityFrameWork;
using IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApplicationRBAC.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MeunInfoController : ControllerBase
    {
        public MeunInfoController(IMeunService meunservice)
        { 
            IMeunService = meunservice;
        }
        public IMeunService IMeunService { get;}

        [HttpGet]
        public List<Meun> GetMeun(int MeunId)
        {
            return IMeunService.GetMeun(MeunId);
        }
    }
}
