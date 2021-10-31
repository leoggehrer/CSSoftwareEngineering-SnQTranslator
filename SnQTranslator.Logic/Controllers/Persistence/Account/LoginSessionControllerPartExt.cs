//@CodeCopy
//MdStart
#if ACCOUNT_ON
using Microsoft.EntityFrameworkCore;
using SnQTranslator.Logic.Entities.Persistence.Account;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SnQTranslator.Logic.Controllers.Persistence.Account
{
    partial class LoginSessionController
	{
		protected override Task<LoginSession> BeforeInsertAsync(LoginSession entity)
		{
			entity.LoginTime = DateTime.Now;
			entity.LastAccess = entity.LoginTime;
			entity.SessionToken = Guid.NewGuid().ToString();
			return base.BeforeInsertAsync(entity);
		}

		public Task<LoginSession[]> QueryOpenLoginSessionsAsync()
		{
			return QueryableSet().Where(e => e.LogoutTime.HasValue == false)
								 .Include(e => e.Identity)
								 .ToArrayAsync();
		}
	}
}
#endif
//MdEnd
