﻿//@CodeCopy
//MdStart

namespace SnQTranslator.AspMvc.Models
{
    public class MasterDetailModel : ModelObject
	{
        public IdentityModel Master { get; set; }
        public IdentityModel Detail { get; set; }
    }
}
//MdEnd
