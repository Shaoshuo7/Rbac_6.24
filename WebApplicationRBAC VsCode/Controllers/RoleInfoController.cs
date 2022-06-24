using ClassLibraryEntityFrameWork;
using IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApplicationRBAC.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleInfoController : ControllerBase
    {
        public RoleInfoController(IRoleService roleservice)
        {
            IRoleService = roleservice;
        }

        public IRoleService IRoleService { get; set; }

        [HttpGet]
        public List<Role> RoleShow()
        {
            return IRoleService.RoleShow();
        }
    }
}
