//@CodeCopy
//MdStart
using SnQTranslator.Contracts.Modules.Common;

namespace SnQTranslator.Contracts.ThirdParty
{
    public interface ITranslation : IVersionable, ICopyable<ITranslation>
    {
        string AppName { get; set; }
        LanguageCode KeyLanguage { get; set; }
        string Key { get; set; }
        LanguageCode ValueLanguage { get; set; }
        string Value { get; set; }
    }
}
//MdEnd
