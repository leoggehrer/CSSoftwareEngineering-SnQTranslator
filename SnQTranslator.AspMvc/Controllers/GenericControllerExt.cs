using SnQTranslator.Contracts.Client;

namespace SnQTranslator.AspMvc.Controllers
{
    partial class GenericController<TContract, TModel>
    {
        partial void AfterCreateController(IAdapterAccess<TContract> controller)
        {
            if (SessionWrapper.LoginSession != null)
            {
                controller.SessionToken = SessionWrapper.SessionToken;
            }
        }
    }
}
