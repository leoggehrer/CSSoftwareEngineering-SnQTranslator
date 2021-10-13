//@GeneratedCode
namespace SnQTranslator.Logic.Controllers.Persistence.App
{
    sealed partial class TranslationController : GenericPersistenceController<SnQTranslator.Contracts.Persistence.App.ITranslation, Entities.Persistence.App.Translation>
    {
        static TranslationController()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        internal TranslationController(DataContext.IContext context)
        :base(context)
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        internal TranslationController(ControllerObject controller)
        :base(controller)
        {
            Constructing();
            Constructed();
        }
    }
}
