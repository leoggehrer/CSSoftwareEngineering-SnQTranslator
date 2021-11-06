using Microsoft.EntityFrameworkCore;
using SnQTranslator.Contracts.Business.App;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnQTranslator.Logic.Controllers.Business.App
{
    partial class AppItemController
    {
        [Attributes.ControllerManagedField]
        private Persistence.App.TranslationController translationController = null;

        public override async Task<IEnumerable<IAppItem>> GetAllAsync()
        {
            var counter = 0;
            var query = await translationController.QueryableSet()
                                                   .Where(e => e.AppName != null)
                                                   .ToListAsync()
                                                   .ConfigureAwait(false);

            return query.GroupBy(e => e.AppName)
                        .Select(e => new Entities.Business.App.AppItem { Id = ++counter, Name = e.Key });
        }
    }
}
