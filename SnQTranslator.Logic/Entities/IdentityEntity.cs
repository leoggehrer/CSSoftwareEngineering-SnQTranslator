//@CodeCopy
//MdStart
using SnQTranslator.Contracts;

namespace SnQTranslator.Logic.Entities
{
    internal abstract partial class IdentityEntity : EntityObject, IIdentifiable
	{
		public virtual int Id { get; set; }
    }
}
//MdEnd
