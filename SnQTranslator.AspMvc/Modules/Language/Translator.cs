//@CodeCopy
//MdStart

namespace SnQTranslator.AspMvc.Modules.Language
{
	public partial class Translator
	{
        static Translator()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();

        private Translator()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        protected static Translator instance = null;
        public static Translator Instance => instance ??= new Translator();

		protected virtual string Translate(string key) => key;
        protected virtual string Translate(string key, string defaultValue) => defaultValue;

        public static string TranslateIt(string key) => Instance.Translate(key);
        public static string TranslateIt(string key, string defaultValue) => Instance.Translate(key);
    }
}
//MdEnd
