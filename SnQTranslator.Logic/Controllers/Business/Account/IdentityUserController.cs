//@GeneratedCode
namespace SnQTranslator.Logic.Controllers.Business.Account
{
    sealed partial class IdentityUserController : GenericOneToAnotherController<SnQTranslator.Contracts.Business.Account.IIdentityUser, Entities.Business.Account.IdentityUser, SnQTranslator.Contracts.Persistence.Account.IIdentity, SnQTranslator.Logic.Entities.Persistence.Account.Identity, SnQTranslator.Contracts.Persistence.Account.IUser, SnQTranslator.Logic.Entities.Persistence.Account.User>
    {
        static IdentityUserController()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public IdentityUserController(DataContext.IContext context)
        :base(context)
        {
            Constructing();
            oneEntityController = new SnQTranslator.Logic.Controllers.Persistence.Account.IdentityController(this);
            anotherEntityController = new SnQTranslator.Logic.Controllers.Persistence.Account.UserController(this);
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        public IdentityUserController(ControllerObject controller)
        :base(controller)
        {
            Constructing();
            oneEntityController = new SnQTranslator.Logic.Controllers.Persistence.Account.IdentityController(this);
            anotherEntityController = new SnQTranslator.Logic.Controllers.Persistence.Account.UserController(this);
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
        private SnQTranslator.Logic.Controllers.Persistence.Account.UserController anotherEntityController = null;
        protected override GenericController<SnQTranslator.Contracts.Persistence.Account.IUser, SnQTranslator.Logic.Entities.Persistence.Account.User> AnotherEntityController
        {
            get => anotherEntityController;
            set => anotherEntityController = value as SnQTranslator.Logic.Controllers.Persistence.Account.UserController;
        }
    }
}
