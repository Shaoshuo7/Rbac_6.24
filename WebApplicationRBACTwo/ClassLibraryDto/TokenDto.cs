using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDto
{
    public class TokenDto : ResultDto
    {
        /// <summary>
        /// Jwt token
        /// </summary>
        public string Token { get; set; }
    }
}
