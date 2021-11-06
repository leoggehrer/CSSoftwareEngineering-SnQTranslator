﻿//@CodeCopy
//MdStart
#if ACCOUNT_ON
using CommonBase.Attributes;
using SnQTranslator.Contracts.Modules.Common;

namespace SnQTranslator.Contracts.Persistence.Account
{
    [ContractInfo]
    public partial interface IIdentity : IVersionable, ICopyable<IIdentity>
    {
        [ContractPropertyInfo(Required = true, MaxLength = 36)]
        string Guid { get; }
        [ContractPropertyInfo(Required = true, MaxLength = 128, IsUnique = true)]
        string Name { get; set; }
        [ContractPropertyInfo(Required = true, MaxLength = 128, IsUnique = true, ContentType = ContentType.EmailAddress)]
        string Email { get; set; }
        [ContractPropertyInfo(NotMapped = true, ContentType = ContentType.Password)]
        string Password { get; set; }
        [ContractPropertyInfo(DefaultValue = "30")]
        int TimeOutInMinutes { get; set; }
        bool EnableJwtAuth { get; set; }
        int AccessFailedCount { get; set; }
        [ContractPropertyInfo(DefaultValue = "Contracts.Modules.Common.State.Active")]
        State State { get; set; }
    }
}
#endif
//MdEnd
