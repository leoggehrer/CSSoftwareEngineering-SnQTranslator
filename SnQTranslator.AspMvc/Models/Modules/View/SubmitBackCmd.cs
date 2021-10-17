//@CodeCopy
//MdStart

namespace SnQTranslator.AspMvc.Models.Modules.View
{
    public partial class SubmitBackCmd : SubmitCmd
    {
        public SubmitBackCmd()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();

        public string BackText { get; set; } = "Back to List";
        public string BackAction { get; set; } = "Index";
        public string BackController { get; set; }
        public string BackCss { get; set; } = "btn btn-outline-dark";
        public string BackStyle { get; set; } = "min-width: 8em;";
    }
}
//MdEnd
