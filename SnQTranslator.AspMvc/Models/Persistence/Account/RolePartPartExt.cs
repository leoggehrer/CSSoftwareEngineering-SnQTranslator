﻿//@CodeCopy
//MdStart
#if ACCOUNT_ON

using System.Collections.Generic;

namespace SnQTranslator.AspMvc.Models.Persistence.Account
{
    public partial class Role
    {
        public bool Assigned { get; set; }
        public IEnumerable<Role> AssignedRoles { get; set; }
    }
}
#endif
//MdEnd
