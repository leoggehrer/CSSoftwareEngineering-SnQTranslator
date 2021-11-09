using SnQTranslator.Contracts.Persistence.App;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnQTranslator.Logic.Controllers.Persistence.App
{
    internal partial class TranslationController
    {
        [Modules.Security.AllowAnonymous]
        public override Task<int> CountAsync()
        {
            return ExecuteCountAsync();
        }
        [Modules.Security.AllowAnonymous]
        public override Task<int> CountByAsync(string predicate)
        {
            return ExecuteCountByAsync(predicate);
        }
        [Modules.Security.AllowAnonymous]
        public override async Task<IEnumerable<ITranslation>> GetAllAsync()
        {
            return await ExecuteGetEntityAllAsync().ConfigureAwait(false);
        }
        [Modules.Security.AllowAnonymous]
        public override async Task<IEnumerable<ITranslation>> QueryAllAsync(string predicate)
        {
            return await ExecuteQueryEntityAllAsync(predicate).ConfigureAwait(false);
        }
        [Modules.Security.AllowAnonymous]
        public override async Task<ITranslation> CreateAsync()
        {
            var result = await base.CreateAsync().ConfigureAwait(false);

            result.KeyLanguage = Contracts.Modules.Common.LanguageCode.En;
            result.ValueLanguage = Contracts.Modules.Common.LanguageCode.De;
            return result;
        }
    }
}
