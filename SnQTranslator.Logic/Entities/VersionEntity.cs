//@CodeCopy

using SnQTranslator.Contracts;

namespace SnQTranslator.Logic.Entities
{
	internal abstract partial class VersionEntity : IdentityEntity, IVersionable
	{
		public byte[] RowVersion { get; set; }
	}
}
