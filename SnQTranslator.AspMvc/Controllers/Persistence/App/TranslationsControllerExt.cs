using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SnQTranslator.AspMvc.Models.Modules.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model = SnQTranslator.AspMvc.Models.Persistence.App.Translation;

namespace SnQTranslator.AspMvc.Controllers.Persistence.App
{
    public partial class TranslationsController
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (string.IsNullOrEmpty(SessionInfo.SessionToken))
            {
                CheckSessionToken = false;
            }
            base.OnActionExecuting(context);
        }

        #region Export and Import
        protected override string[] CsvHeader => new string[]
        {
            "Id",
            $"{nameof(Model.AppName)}",
            $"{nameof(Model.KeyLanguage)}",
            $"{nameof(Model.Key)}",
            $"{nameof(Model.ValueLanguage)}",
            $"{nameof(Model.Value)}",
        };

        [ActionName("Export")]
        public async Task<FileResult> ExportAsync()
        {
            var fileName = "Translation.csv";
            var entities = await QueryByFilterAndSortAsync().ConfigureAwait(false);
            var models = entities.OrderBy(e => e.Key)
                                 .Select(e => ToModel(e));

            return ExportDefault(CsvHeader, models, fileName);
        }

        [ActionName("Import")]
        public ActionResult ImportAsync(string error = null)
        {
            var model = new Models.Modules.Csv.ImportProtocol() { BackController = ControllerName };

            if (error.HasContent())
                LastViewError = error;

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Import")]
        public async Task<IActionResult> ImportAsync()
        {
            var index = 0;
            var model = new Models.Modules.Csv.ImportProtocol() { BackController = ControllerName };
            var logInfos = new List<Models.Modules.Csv.ImportLog>();
            var importModels = ImportDefault<Model>(CsvHeader);
            using var ctrl = CreateController();

            foreach (var item in importModels)
            {
                index++;
                try
                {
                    if (item.Action == Models.Modules.Csv.ImportAction.Insert)
                    {
                        var entity = await ctrl.CreateAsync();

                        CopyModels(CsvHeader, item.Model, entity);
                        await ctrl.InsertAsync(entity);
                    }
                    else if (item.Action == Models.Modules.Csv.ImportAction.Update)
                    {
                        var entity = await ctrl.GetByIdAsync(item.Id);

                        CopyModels(CsvHeader, item.Model, entity);
                        await ctrl.UpdateAsync(entity);
                    }
                    else if (item.Action == Models.Modules.Csv.ImportAction.Delete)
                    {
                        await ctrl.DeleteAsync(item.Id);
                    }
                    logInfos.Add(new Models.Modules.Csv.ImportLog
                    {
                        IsError = false,
                        Prefix = $"Line: {index} - {item.Action}",
                        Text = "OK",
                    });
                }
                catch (Exception ex)
                {
                    logInfos.Add(new Models.Modules.Csv.ImportLog
                    {
                        IsError = true,
                        Prefix = $"Line: {index} - {item.Action}",
                        Text = ex.Message,
                    });
                }
            }
            model.LogInfos = logInfos;
            return View(model);
        }
        #endregion Export and Import
    }
}