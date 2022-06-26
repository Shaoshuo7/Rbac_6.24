using Application;
using ClassLibraryDto;
using ClassLibraryEntityFrameWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApplicationRBAC.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class MeunInfoController : ControllerBase
    {
        private readonly IMeunService meunService;

        public MeunInfoController(IMeunService meunService)
        {
            this.meunService = meunService;
        }

        [HttpGet]
        public List<MeunDto> MeunAll()
        {
            return meunService.MeunAll();
        }

        [HttpGet]
        public List<CreateDto> Cascading()
        {
            return meunService.Cascading();
        }

        [HttpGet]
        public int Del(int id)
        {
            return meunService.Del(id);
        }

        [HttpPost]
        public int Add(AddDto c)
        {
            return meunService.Add(c);
        }

        [HttpGet]
        public Meun FanT(int id)
        { 
            return  meunService.FanT(id);
        }

        [HttpPost]
        public int Upd(AddDto c)
        {
            return meunService.Upd(c);
        }
    }
  
}
