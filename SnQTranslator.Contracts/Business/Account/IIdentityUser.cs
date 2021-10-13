//@CodeCopy
//MdStart
#if ACCOUNT_ON
using SnQTranslator.Contracts.Persistence.Account;

namespace SnQTranslator.Contracts.Business.Account
{
    public partial interface IIdentityUser : IOneToAnother<IIdentity, IUser>, ICopyable<IIdentityUser>
    {
    }
}
#endif
//MdEnd
