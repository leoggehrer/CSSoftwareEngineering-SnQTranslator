//@GeneratedCode
namespace SnQTranslator.AspMvc.Models.Persistence.App
{
    using System;
    public partial class Translation : SnQTranslator.Contracts.Persistence.App.ITranslation
    {
        static Translation()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public Translation()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        public System.String AppName
        {
            get;
            set;
        }
        public SnQTranslator.Contracts.Modules.Common.LanguageCode KeyLanguage
        {
            get;
            set;
        }
        = Contracts.Modules.Common.LanguageCode.En;
        public System.String Key
        {
            get;
            set;
        }
        public SnQTranslator.Contracts.Modules.Common.LanguageCode ValueLanguage
        {
            get;
            set;
        }
        = Contracts.Modules.Common.LanguageCode.De;
        public System.String Value
        {
            get;
            set;
        }
        = string.Empty;
        public void CopyProperties(SnQTranslator.Contracts.Persistence.App.ITranslation other)
        {
            if (other == null)
            {
                throw new System.ArgumentNullException(nameof(other));
            }
            bool handled = false;
            BeforeCopyProperties(other, ref handled);
            if (handled == false)
            {
                Id = other.Id;
                RowVersion = other.RowVersion;
                AppName = other.AppName;
                KeyLanguage = other.KeyLanguage;
                Key = other.Key;
                ValueLanguage = other.ValueLanguage;
                Value = other.Value;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(SnQTranslator.Contracts.Persistence.App.ITranslation other, ref bool handled);
        partial void AfterCopyProperties(SnQTranslator.Contracts.Persistence.App.ITranslation other);
        public static Persistence.App.Translation Create()
        {
            BeforeCreate();
            var result = new Persistence.App.Translation();
            AfterCreate(result);
            return result;
        }
        public static Persistence.App.Translation Create(object other)
        {
            BeforeCreate(other);
            CommonBase.Extensions.ObjectExtensions.CheckArgument(other, nameof(other));
            var result = new Persistence.App.Translation();
            CommonBase.Extensions.ObjectExtensions.CopyFrom(result, other);
            AfterCreate(result, other);
            return result;
        }
        public static Persistence.App.Translation Create(SnQTranslator.Contracts.Persistence.App.ITranslation other)
        {
            BeforeCreate(other);
            var result = new Persistence.App.Translation();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate();
        static partial void AfterCreate(Persistence.App.Translation instance);
        static partial void BeforeCreate(object other);
        static partial void AfterCreate(Persistence.App.Translation instance, object other);
        static partial void BeforeCreate(SnQTranslator.Contracts.Persistence.App.ITranslation other);
        static partial void AfterCreate(Persistence.App.Translation instance, SnQTranslator.Contracts.Persistence.App.ITranslation other);
    }
}
