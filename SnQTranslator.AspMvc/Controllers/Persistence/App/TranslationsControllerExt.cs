﻿using CommonBase.Extensions;
using Microsoft.AspNetCore.Mvc;
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
        public override Task<IActionResult> IndexAsync()
        {
            var page = SessionWrapper.GetStringValue("page", "A");
            var appName = SessionWrapper.GetStringValue("appname");

            return Task.Run<IActionResult>(() => RedirectToAction("IndexByPage", new { appName, page }));
        }

        [ActionName("IndexByPage")]
        public async Task<IActionResult> IndexByPageAsync(string appName, string page)
        {
            using var translationsCtrl = CreateController();
            using var appItemsCtrl = CreateController<Contracts.Business.App.IAppItem>();
            var entities = default(IEnumerable<Contracts.Persistence.App.ITranslation>);
            var appItems = await appItemsCtrl.GetAllAsync().ConfigureAwait(false);
            var predicate = string.Empty;

            page = page?.ToLower();
            ViewData[nameof(Models.Business.App.AppItem)] = new string[] { "" }.Union(appItems.Select(e => e.Name)).ToArray();
            SessionWrapper.SetStringValue(nameof(page), page);

            appName = appName != null && appName.Equals("*") ? String.Empty : appName;
            if (string.IsNullOrEmpty(appName) == false)
            {
                predicate = $"AppName.Equals(\"{appName}\")";
            }
            if (string.IsNullOrEmpty(page) == false)
            {
                if (predicate.Length == 0)
                {
                    predicate = $"Key.ToLower().StartsWith(\"{page}\")";
                }
                else
                {
                    predicate = $"{predicate} && Key.ToLower().StartsWith(\"{page}\")";
                }
            }

            if (string.IsNullOrEmpty(predicate))
            {
                entities = await translationsCtrl.GetAllAsync().ConfigureAwait(false);
            }
            else
            {
                entities = await translationsCtrl.QueryAllAsync(predicate).ConfigureAwait(false);
            }
            var models = entities.OrderBy(e => e.Key)
                                 .Select(e => ToModel(e));

            models = BeforeView(models, ActionMode.Index);
            models = await BeforeViewAsync(models, ActionMode.Index).ConfigureAwait(false);
            return ReturnIndexView(models);
        }

        [ActionName("IndexByAppName")]
        public IActionResult IndexByAppName(string appName)
        {
            var page = SessionWrapper.GetStringValue("page");

            SessionWrapper.SetStringValue("appname", appName);
            return RedirectToAction("IndexByPage", new { appName, page });
        }

        protected override async Task<Model> CreateModelAsync()
        {
            var appName = SessionWrapper.GetStringValue("appname");
            var result = await base.CreateModelAsync().ConfigureAwait(false);

            if (appName != null && appName.Equals("*") == false)
            {
                result.AppName = appName;
            }
            return result;
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
            using var ctrl = CreateController();
            var entities = (await ctrl.GetAllAsync().ConfigureAwait(false)).Select(e => ToModel(e));

            return ExportDefault(CsvHeader, entities, fileName);
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