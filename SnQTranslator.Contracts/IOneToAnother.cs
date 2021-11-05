﻿//@CodeCopy
//MdStart

namespace SnQTranslator.Contracts
{
    public partial interface IOneToAnother<TOne, TAnother> : IIdentifiable
        where TOne : IIdentifiable
        where TAnother : IIdentifiable
    {
        TOne OneItem { get; }
        TAnother AnotherItem { get; }
    }
}
//MdEnd
