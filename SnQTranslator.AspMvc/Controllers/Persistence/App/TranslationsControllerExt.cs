using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnQTranslator.AspMvc.Controllers.Persistence.App
{
    partial class TranslationsController
    {
        public override Task<IActionResult> IndexAsync()
        {
            return base.IndexAsync();
        }

        [ActionName("IndexByPage")]
        public async Task<IActionResult> IndexByPageAsync(string page)
        {
            page = page?.ToLower();
            SessionWrapper.SetStringValue(nameof(page), page);

            using var ctrl = CreateController();
            var entities = default(IEnumerable<Contracts.Persistence.App.ITranslation>);

            if (string.IsNullOrEmpty(page))
            {
                entities = await ctrl.GetAllAsync().ConfigureAwait(false);
            }
            else
            {
                entities = await ctrl.QueryAllAsync($"Key.ToLower().StartsWith(\"{page}\")").ConfigureAwait(false);
            }
            var models = entities.OrderBy(e => e.Key)
                                 .Select(e => ToModel(e));

            models = BeforeView(models, Action.Index);
            models = await BeforeViewAsync(models, Action.Index).ConfigureAwait(false);
            return View("Index", models);
        }
    }
}
