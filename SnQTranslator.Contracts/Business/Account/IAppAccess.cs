//@CodeCopy
//MdStart
#if ACCOUNT_ON
using SnQTranslator.Contracts.Persistence.Account;

namespace SnQTranslator.Contracts.Business.Account
{
    public partial interface IAppAccess : IOneToMany<IIdentity, IRole>, ICopyable<IAppAccess>
    {

    }
}
#endif
//MdEnd
