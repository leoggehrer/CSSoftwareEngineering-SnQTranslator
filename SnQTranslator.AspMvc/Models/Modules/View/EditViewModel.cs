﻿//@CodeCopy
//MdStart
using CommonBase.Extensions;
using SnQTranslator.AspMvc.Modules.View;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SnQTranslator.AspMvc.Models.Modules.View
{
    public partial class EditViewModel : ViewModel
    {
        public IdentityModel Model { get; init; }
        public override Type ModelType => Model.GetType();

        public EditViewModel(ViewBagWrapper viewBagWrapper, IdentityModel model)
            : base(viewBagWrapper)
        {
            model.CheckArgument(nameof(model));

            Model = model;
        }

        public virtual IEnumerable<PropertyInfo> GetHiddenProperties()
        {
            return GetHiddenProperties(ModelType);
        }
        public virtual IEnumerable<PropertyInfo> GetDisplayProperties()
        {
            return GetDisplayProperties(ModelType);
        }
        public virtual object GetValue(PropertyInfo propertyInfo)
        {
            propertyInfo.CheckArgument(nameof(propertyInfo));

            return propertyInfo.GetValue(Model);
        }
        public virtual string GetDisplayValue(PropertyInfo propertyInfo)
        {
            propertyInfo.CheckArgument(nameof(propertyInfo));

            var value = propertyInfo.GetValue(Model);

            return value != null ? value.ToString() : string.Empty;
        }
    }
}
//MdEnd
