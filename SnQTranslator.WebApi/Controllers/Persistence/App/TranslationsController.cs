//@GeneratedCode
namespace SnQTranslator.WebApi.Controllers.Persistence.App
{
    using Microsoft.AspNetCore.Mvc;
    using TContract = Contracts.Persistence.App.ITranslation;
    using TModel = Transfer.Models.Persistence.App.Translation;
    [ApiController]
    [Route("Controller")]
    public partial class TranslationsController : WebApi.Controllers.GenericController<TContract, TModel>
    {
    }
}
