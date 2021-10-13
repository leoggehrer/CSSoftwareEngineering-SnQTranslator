//@GeneratedCode
namespace SnQTranslator.Logic.Entities.Persistence.Account
{
    using System;
    partial class User : SnQTranslator.Contracts.Persistence.Account.IUser
    {
        static User()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public User()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        public System.Int32 IdentityId
        {
            get;
            set;
        }
        public System.String Firstname
        {
            get;
            set;
        }
        public System.String Lastname
        {
            get;
            set;
        }
        public void CopyProperties(SnQTranslator.Contracts.Persistence.Account.IUser other)
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
                IdentityId = other.IdentityId;
                Firstname = other.Firstname;
                Lastname = other.Lastname;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(SnQTranslator.Contracts.Persistence.Account.IUser other, ref bool handled);
        partial void AfterCopyProperties(SnQTranslator.Contracts.Persistence.Account.IUser other);
        public override bool Equals(object obj)
        {
            if (obj is not SnQTranslator.Contracts.Persistence.Account.IUser instance)
            {
                return false;
            }
            return base.Equals(instance) && Equals(instance);
        }
        protected bool Equals(SnQTranslator.Contracts.Persistence.Account.IUser other)
        {
            if (other == null)
            {
                return false;
            }
            return IdentityId == other.IdentityId
            && IsEqualsWith(Firstname, other.Firstname)
            && IsEqualsWith(Lastname, other.Lastname);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(IdentityId, Firstname, Lastname);
        }
        public static Persistence.Account.User Create()
        {
            BeforeCreate();
            var result = new Persistence.Account.User();
            AfterCreate(result);
            return result;
        }
        public static Persistence.Account.User Create(object other)
        {
            BeforeCreate(other);
            CommonBase.Extensions.ObjectExtensions.CheckArgument(other, nameof(other));
            var result = new Persistence.Account.User();
            CommonBase.Extensions.ObjectExtensions.CopyFrom(result, other);
            AfterCreate(result, other);
            return result;
        }
        public static Persistence.Account.User Create(SnQTranslator.Contracts.Persistence.Account.IUser other)
        {
            BeforeCreate(other);
            var result = new Persistence.Account.User();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate();
        static partial void AfterCreate(Persistence.Account.User instance);
        static partial void BeforeCreate(object other);
        static partial void AfterCreate(Persistence.Account.User instance, object other);
        static partial void BeforeCreate(SnQTranslator.Contracts.Persistence.Account.IUser other);
        static partial void AfterCreate(Persistence.Account.User instance, SnQTranslator.Contracts.Persistence.Account.IUser other);
    }
}
