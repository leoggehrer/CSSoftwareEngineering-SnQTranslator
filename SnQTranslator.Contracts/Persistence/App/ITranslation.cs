
using CommonBase.Attributes;
using SnQTranslator.Contracts.Modules.Common;

namespace SnQTranslator.Contracts.Persistence.App
{
    [ContractInfo(ContextType = ContextType.Table)]
	public interface ITranslation : IVersionable, ICopyable<ITranslation>
	{
        [ContractPropertyInfo(MaxLength = 128, HasUniqueIndexWithName = true, IndexName = "UX_Translation", IndexColumnOrder = 1)]
        string AppName { get; set; }
        [ContractPropertyInfo(DefaultValue = "Contracts.Modules.Common.LanguageCode.En", HasUniqueIndexWithName = true, IndexName = "UX_Translation", IndexColumnOrder = 2)]
        LanguageCode KeyLanguage { get; set; }
        [ContractPropertyInfo(MaxLength = 1024, HasUniqueIndexWithName = true, IndexName = "UX_Translation", IndexColumnOrder = 3)]
        string Key { get; set; }
        [ContractPropertyInfo(DefaultValue = "Contracts.Modules.Common.LanguageCode.De")]
        LanguageCode ValueLanguage { get; set; }
        [ContractPropertyInfo(MaxLength = 1024, DefaultValue = "string.Empty")]
        string Value { get; set; }
    }
}
