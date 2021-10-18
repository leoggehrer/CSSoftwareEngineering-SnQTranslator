//@CodeCopy
//MdStart
using Microsoft.AspNetCore.Mvc;
using SnQTranslator.AspMvc.Modules.Session;

namespace SnQTranslator.AspMvc.Controllers
{
	public class MvcController : Controller
	{
        private string lastError;
        protected string LastError
        {
            get => lastError;
            set
            {
                lastError = value;
                Modules.Handler.ErrorHandler.LastError = value;
            }
        }
        protected bool HasError => string.IsNullOrEmpty(LastError) == false;

        #region SessionWrapper
        public bool IsSessionAvailable => HttpContext?.Session != null;
        private ISessionWrapper sessionWrapper = null;
        internal ISessionWrapper SessionWrapper => sessionWrapper ?? (sessionWrapper = new SessionWrapper(HttpContext.Session));
        #endregion
    }
}
//MdEnd
