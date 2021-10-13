//@GeneratedCode
namespace SnQTranslator.Logic.Controllers.Business.Account
{
    [Logic.Modules.Security.Authorize("SysAdmin", "AppAdmin")]
    sealed partial class AppAccessController : GenericOneToManyController<SnQTranslator.Contracts.Business.Account.IAppAccess, Entities.Business.Account.AppAccess, SnQTranslator.Contracts.Persistence.Account.IIdentity, SnQTranslator.Logic.Entities.Persistence.Account.Identity, SnQTranslator.Contracts.Persistence.Account.IRole, SnQTranslator.Logic.Entities.Persistence.Account.Role>
    {
        static AppAccessController()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public AppAccessController(DataContext.IContext context)
        :base(context)
        {
            Constructing();
            oneEntityController = new SnQTranslator.Logic.Controllers.Persistence.Account.IdentityController(this);
            manyEntityController = new SnQTranslator.Logic.Controllers.Persistence.Account.RoleController(this);
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        public AppAccessController(ControllerObject controller)
        :base(controller)
        {
            Constructing();
            oneEntityController = new SnQTranslator.Logic.Controllers.Persistence.Account.IdentityController(this);
            manyEntityController = new SnQTranslator.Logic.Controllers.Persistence.Account.RoleController(this);
            Constructed();
        }
        [Attributes.ControllerManagedField]
        private SnQTranslator.Logic.Controllers.Persistence.Account.IdentityController oneEntityController = null;
        protected override GenericController<SnQTranslator.Contracts.Persistence.Account.IIdentity, SnQTranslator.Logic.Entities.Persistence.Account.Identity> OneEntityController
        {
            get => oneEntityController;
            set => oneEntityController = value as SnQTranslator.Logic.Controllers.Persistence.Account.IdentityController;
        }
        [Attributes.ControllerManagedField]
        private SnQTranslator.Logic.Controllers.Persistence.Account.RoleController manyEntityController = null;
        protected override GenericController<SnQTranslator.Contracts.Persistence.Account.IRole, SnQTranslator.Logic.Entities.Persistence.Account.Role> ManyEntityController
        {
            get => manyEntityController;
            set => manyEntityController = value as SnQTranslator.Logic.Controllers.Persistence.Account.RoleController;
        }
    }
}
