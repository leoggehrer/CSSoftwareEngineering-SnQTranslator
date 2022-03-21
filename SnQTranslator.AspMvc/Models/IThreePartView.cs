//@CodeCopy
//MdStart

namespace SnQTranslator.AspMvc.Models
{
    public interface IThreePartView
    {
        IdentityModel FirstModel { get; }
        IdentityModel SecondModel { get; }
        IdentityModel ThirdModel { get; }
    }
}
//MdEnd
