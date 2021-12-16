﻿//@CodeCopy
//MdStart
using SnQTranslator.AspMvc.Modules.View;
using System;
using System.Reflection;

namespace SnQTranslator.AspMvc.Models.Modules.View
{
    public partial class EditViewModel : ViewModel
    {
        static EditViewModel()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public IdentityModel Model { get; init; }
        public IdentityModel DisplayModel => Model;

        public EditViewModel(ViewBagWrapper viewBagInfo, IdentityModel model, Type modelType, Type displayType)
            : base(viewBagInfo, modelType, displayType)
        {
            model.CheckArgument(nameof(model));

            Constructing();
            Model = model;
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();

        public virtual IEnumerable<PropertyInfo> GetHiddenProperties()
        {
            return GetHiddenProperties(DisplayType);
        }
        public virtual IEnumerable<PropertyInfo> GetDisplayProperties()
        {
            return GetDisplayProperties(DisplayType);
        }
        public virtual object GetValue(PropertyInfo propertyInfo)
        {
            return GetValue(Model, propertyInfo);
        }
        public virtual string GetDisplayValue(PropertyInfo propertyInfo)
        {
            return GetDisplayValue(Model, propertyInfo);
        }
    }
}
//MdEnd
