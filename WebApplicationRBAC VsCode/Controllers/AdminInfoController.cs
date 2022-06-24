using ClassLibraryEntityFrameWork;
using IService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationRBAC.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminInfoController : ControllerBase
    {
        public AdminInfoController(IAdminService adminservice)
        { 
            IAdminService = adminservice;
        }

        public IAdminService IAdminService { get; set; }

        [HttpGet]
        public int AdminDel(int id)
        {
            return IAdminService.AdminDel(id);
        }

        [HttpGet]
        public Admin AdminFanT(int id)
        {
            return IAdminService.AdminFanT(id);
        }

        [HttpGet]
        public List<Admin> AdminShow()
        {
            return IAdminService.AdminShow();
        }

        [HttpPost]
        public int AdminUpd(Admin c)
        {
            return IAdminService.AdminUpd(c);
        }
    }
}
