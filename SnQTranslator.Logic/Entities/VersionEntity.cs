//@CodeCopy

using SnQTranslator.Contracts;

namespace SnQTranslator.Logic.Entities
{
	internal abstract partial class VersionEntity : IdentityEntity, IVersionable
	{
		public virtual byte[] RowVersion { get; set; }
	}
}
