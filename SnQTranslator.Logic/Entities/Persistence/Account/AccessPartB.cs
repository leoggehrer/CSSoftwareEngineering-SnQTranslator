//@GeneratedCode
namespace SnQTranslator.Logic.Entities.Persistence.Account
{
    partial class Access
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("IdentityId")]
        public SnQTranslator.Logic.Entities.Persistence.Account.Identity Identity
        {
            get;
            set;
        }
    }
}
