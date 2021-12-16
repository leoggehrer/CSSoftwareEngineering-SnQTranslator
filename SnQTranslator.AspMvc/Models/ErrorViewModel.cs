//@CodeCopy
//MdStart
namespace SnQTranslator.AspMvc.Models
{
    public partial class ErrorViewModel
	{
		public string RequestId { get; set; }

		public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
	}
}
//MdEnd
