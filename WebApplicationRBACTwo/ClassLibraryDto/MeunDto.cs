using System;
using System.Collections.Generic;

namespace ClassLibraryDto
{
    public class MeunDto
    {
        public int MeunId { get; set; }
        public string MeunName { get; set; }
        public string MeunLink { get; set; }
        public List<MeunDto> children { get; set; } = new List<MeunDto>();
    }
}
