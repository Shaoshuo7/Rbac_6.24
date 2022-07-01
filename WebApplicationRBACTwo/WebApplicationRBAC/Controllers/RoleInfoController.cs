using Application;
using ClassLibraryDto;
using ClassLibraryEntityFrameWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApplicationRBAC.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleInfoController : ControllerBase
    {
        private readonly IRoleService role;

        public RoleInfoController(IRoleService role)
        {
            this.role = role;
        }

        [HttpPost]
        public int Add(RoleDto c)
        {
            return role.Add(c);
        }

        [HttpGet]
        public int Del(int id)
        { 
            return role.Del(id);
        }

        [HttpPost]
        public int Upd(RoleDto c)
        { 
            return role.Upd(c);
        }

        [HttpGet]
        public RoleDto FanT(int id)
        { 
            return role.FanT(id);
        }

        [HttpGet]
        public List<RoleDto> GetShow()
        { 
            return role.GetShow();
        }

        //[HttpPost]
        //public int GetAssignment(AssignmentDto c)
        //{ 
        //    return role.GetAssignment(c);
        //}

        [HttpPost]
        public IActionResult Saverp(AssignmentDto c)
        { 
            role.GetAssignment(c);
            return Ok();
        }
    }
}
