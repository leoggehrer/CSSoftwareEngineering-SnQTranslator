//@GeneratedCode
namespace SnQTranslator.AspMvc.Controllers.Persistence.App
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TContract = Contracts.Persistence.App.ITranslation;
    using TModel = AspMvc.Models.Persistence.App.Translation;
    public partial class TranslationsController : AspMvc.Controllers.GenericController<TContract, TModel>
    {
        static TranslationsController()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public TranslationsController()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
    }
}
