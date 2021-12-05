//@CodeCopy
//MdStart
using SnQTranslator.Contracts.Modules.Common;

namespace SnQTranslator.Contracts.ThirdParty
{
    public partial interface IHtmlElement : IVersionable, ICopyable<IHtmlElement>
    {
        string AppName { get; set; }
        string Key { get; set; }
        string Description { get; set; }
        string Content { get; set; }
        State State { get; set; }
    }
}
//MdEnd
