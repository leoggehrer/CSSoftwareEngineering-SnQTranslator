//@CodeCopy
//MdStart
#if ACCOUNT_ON
using Microsoft.EntityFrameworkCore;
using SnQTranslator.Logic.Entities.Persistence.Account;
using System.Linq;
using System.Threading.Tasks;

namespace SnQTranslator.Logic.Controllers.Persistence.Account
{
    partial class IdentityXRoleController
	{
		public Task<Role[]> QueryIdentityRolesAsync(int identityId)
		{
			return QueryableSet().Where(e => e.IdentityId == identityId)
								 .Include(e => e.Role)
								 .Select(e => e.Role)
								 .ToArrayAsync();
		}
	}
}
#endif
//MdEnd
