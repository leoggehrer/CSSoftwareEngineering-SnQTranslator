//@CodeCopy
//MdStart
using CommonBase.Extensions;
using CommonBase.Modules.Configuration;
using SnQTranslator.AspMvc.Models.ThirdParty;
using SnQTranslator.AspMvc.Modules.Handler;
using SnQTranslator.Contracts.Modules.Common;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SnQTranslator.AspMvc.Modules.ThirdPartyServices

{
    public class StaticPageService
    {
        public static StaticPage GetPageContent(string pageName)
        {
            return GetPageContent(nameof(SnQTranslator), pageName);
        }
        public static StaticPage GetPageContent(string appName, string pageName)
        {
            var result = default(StaticPage);
            var htmlStoreServer = AppSettings.Configuration[StaticLiterals.EnvironmentHtmlStoreServerKey];

            if (htmlStoreServer.HasContent())
            {
                var ctrl = Adapters.Factory.CreateThridParty<Contracts.ThirdParty.IStaticPage>(htmlStoreServer);
                var predicate = $"{nameof(StaticPage.AppName)} == \"{appName}\" AND {nameof(StaticPage.Key)} == \"{pageName}\" AND {nameof(StaticPage.State)} == \"{State.Active}\"";

                try
                {
                    var qry = Task.Run(async () =>
                    {
                        return await ctrl.QueryAllAsync(predicate).ConfigureAwait(false);
                    }).Result;

                    if (qry.Any())
                    {
                        result = StaticPage.Create(qry.ElementAt(0));
                    }
                }
                catch (Exception ex)
                {
                    ErrorHandler.LastLogicError = $"{System.Reflection.MethodBase.GetCurrentMethod().Name}: {ex.GetError()}";
                    System.Diagnostics.Debug.WriteLine(ErrorHandler.LastLogicError);
                }
            }
            return result;
        }

        public static string GetHtmlElement(string key, string defaultContent)
        {
            return GetHtmlElement(nameof(SnQTranslator), key, defaultContent);
        }
        public static string GetHtmlElement(string appName, string key, string defaultContent)
        {
            var result = defaultContent;
            var htmlStoreServer = AppSettings.Configuration[StaticLiterals.EnvironmentHtmlStoreServerKey];

            if (htmlStoreServer.HasContent())
            {
                var ctrl = Adapters.Factory.CreateThridParty<Contracts.ThirdParty.IHtmlElement>(htmlStoreServer);
                var predicate = $"{nameof(StaticPage.AppName)} == \"{appName}\" AND {nameof(StaticPage.Key)} == \"{key}\" AND {nameof(StaticPage.State)} == \"{State.Active}\"";

                try
                {
                    var qry = Task.Run(async () =>
                    {
                        return await ctrl.QueryAllAsync(predicate).ConfigureAwait(false);
                    }).Result;

                    if (qry.Any())
                    {
                        result = qry.ElementAt(0).Content;
                    }
                }
                catch (Exception ex)
                {
                    ErrorHandler.LastLogicError = $"{System.Reflection.MethodBase.GetCurrentMethod().Name}: {ex.GetError()}";
                    System.Diagnostics.Debug.WriteLine(ErrorHandler.LastLogicError);
                }
            }
            return result;
        }

        public static string GetHtmlAttribute(string key, string defaultContent)
        {
            return GetHtmlAttribute(nameof(SnQTranslator), key, defaultContent);
        }
        public static string GetHtmlAttribute(string appName, string key, string defaultContent)
        {
            var result = defaultContent;
            var htmlStoreServer = AppSettings.Configuration[StaticLiterals.EnvironmentHtmlStoreServerKey];

            if (htmlStoreServer.HasContent())
            {
                var ctrl = Adapters.Factory.CreateThridParty<Contracts.ThirdParty.IHtmlAttribute>(htmlStoreServer);
                var predicate = $"{nameof(StaticPage.AppName)} == \"{appName}\" AND {nameof(StaticPage.Key)} == \"{key}\" AND {nameof(StaticPage.State)} == \"{State.Active}\"";

                try
                {
                    var qry = Task.Run(async () =>
                    {
                        return await ctrl.QueryAllAsync(predicate).ConfigureAwait(false);
                    }).Result;

                    if (qry.Any())
                    {
                        result = qry.ElementAt(0).Content;
                    }
                }
                catch (Exception ex)
                {
                    ErrorHandler.LastLogicError = $"{System.Reflection.MethodBase.GetCurrentMethod().Name}: {ex.GetError()}";
                    System.Diagnostics.Debug.WriteLine(ErrorHandler.LastLogicError);
                }
            }
            return result;
        }
    }
}
//MdEnd
