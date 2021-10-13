//@GeneratedCode
namespace SnQTranslator.Logic.Entities.Persistence.Account
{
    partial class IdentityXRole
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("IdentityId")]
        public SnQTranslator.Logic.Entities.Persistence.Account.Identity Identity
        {
            get;
            set;
        }
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("RoleId")]
        public SnQTranslator.Logic.Entities.Persistence.Account.Role Role
        {
            get;
            set;
        }
    }
}
