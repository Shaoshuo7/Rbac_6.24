using Application;
using ClassLibraryDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApplicationRBAC.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminInfoController : ControllerBase
    {
        private readonly IAdminService adminService;

        public AdminInfoController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        [HttpPost]
        public ResultDto AdminAdd(AdminDto c)
        { 
            return adminService.AdminAdd(c);
        }

        [HttpPost]
        public TokenDto AdmLogin(LoginDto c)
        { 
            return adminService.AdmLogin(c);
        }

        [HttpGet]
        public int Del(int id)
        {
            return adminService.Del(id);
        }

        [HttpPost]
        public int Upd(AdminDto c)
        {
            return adminService.Upd(c);
        }

        [HttpGet]
        public AdminDto FanT(int id)
        {
            return adminService.FanT(id);
        }

        [HttpGet]
        public List<AdminDto> GetShow()
        {
            return adminService.GetShow();
        }
    }
}
