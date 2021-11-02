using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnQTranslator.ConApp
{
    internal partial class Program
    {
        private static async Task ImportDataAsync()
        {
            using var translationCtrl = Create<Contracts.Persistence.App.ITranslation>();
            var translationData = File.ReadAllLines("Data\\WordsDeToEn.csv", Encoding.Default)
                                      .Select(l => l.Split(";"))
                                      .Where(d => d.Length == 2)
                                      .Select(d =>
            {
                var wordDe = d[0].Split(",")[0];
                var wordEn = d[1].Split(",")[0];

                return new
                {
                    Data = d,
                    Entity = new Transfer.Models.Persistence.App.Translation
                    {
                        KeyLanguage = Contracts.Modules.Common.LanguageCode.En,
                        Key = wordEn,
                        ValueLanguage = Contracts.Modules.Common.LanguageCode.De,
                        Value = wordDe
                    }
                };
            });

            // import translations
            //foreach (var item in translationData)
            //{
            //    await translationCtrl.InsertAsync(item.Entity);
            //}
            await translationCtrl.InsertAsync(translationData.Select(td => td.Entity));
        }
    }
}
