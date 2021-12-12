﻿//@CodeCopy
//MdStart
using Microsoft.AspNetCore.Mvc;
using SnQTranslator.AspMvc.Modules.Language;
using System.Linq;
using System.Threading.Tasks;

namespace SnQTranslator.AspMvc.Controllers
{
    public partial class TranslationsController : MvcController
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

        public IActionResult ReloadTranslations()
        {
            Translator.Instance.ReloadTranslations();

            return RedirectToAction("Index");
        }

        #region Export no translations
        protected override string[] CsvHeader => new string[]
        {
            $"{nameof(Models.ThirdParty.Translation.Id)}",
            $"{nameof(Models.ThirdParty.Translation.AppName)}",
            $"{nameof(Models.ThirdParty.Translation.KeyLanguage)}",
            $"{nameof(Models.ThirdParty.Translation.Key)}",
            $"{nameof(Models.ThirdParty.Translation.ValueLanguage)}",
            $"{nameof(Models.ThirdParty.Translation.Value)}",
        };

        [ActionName("ExportNoTranslations")]
        public Task<FileResult> ExportNoTranslationsAsync()
        {
            var fileName = $"{nameof(SnQTranslator)}NoTranslations.csv";
            var fullItems = Translator.Instance.NoTranslations.Where(i => i.Key.Contains(".")).OrderBy(i => i.Key);
            var partItems = Translator.Instance.NoTranslations.Where(i => i.Key.Contains(".") == false).OrderBy(i => i.Key);
            var allItems = fullItems.Union(partItems);
            
            return Task.Factory.StartNew(() => ExportDefault(CsvHeader, allItems, fileName));
        }
        #endregion Export no translations
    }
}
//MdEnd
