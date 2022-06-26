using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDto
{
    public class LoginDto
    {
        public string AdmName { get; set; }
        public string AdmPassWord { get; set; }
        public string ValidateCode { get; set; }
    }
}
