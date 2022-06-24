using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDto
{
    public class CreateDto
    {
        public int value { get; set; }
        public string label { get; set; }
        public List<CreateDto> children { get; set; } = new List<CreateDto>();
    }
}
