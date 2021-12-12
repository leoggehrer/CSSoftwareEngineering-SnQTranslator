﻿//@CodeCopy
//MdStart
#if ACCOUNT_ON

using Microsoft.AspNetCore.Mvc;
using SnQTranslator.AspMvc.Models.Persistence.Account;

namespace SnQTranslator.AspMvc.Controllers.Persistence.Account
{
    public partial class IdentitiesController
    {
        protected override IActionResult ReturnAfterCreate(bool hasError, Identity model)
        {
            IActionResult result;

            if (hasError)
            {
                result = base.ReturnAfterCreate(hasError, model);
            }
            else
            {
                var redirectController = SessionInfo.GetStringValue(StaticLiterals.RedirectControllerKey);

                if (string.IsNullOrEmpty(redirectController))
                {
                    result = RedirectToAction("Index", "IdentityUsers");
                }
                else
                {
                    SessionInfo.SetStringValue(StaticLiterals.RedirectControllerKey, string.Empty);
                    result = RedirectToAction("Index", redirectController);
                }
            }
            return result;
        }
    }
}
#endif
//MdEnd
