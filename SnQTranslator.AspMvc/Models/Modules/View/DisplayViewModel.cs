﻿//@CodeCopy
//MdStart
using CommonBase.Extensions;
using SnQTranslator.AspMvc.Modules.View;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SnQTranslator.AspMvc.Models.Modules.View
{
    public partial class DisplayViewModel : ViewModel
    {
        public object Model { get; init; }
        public override Type ModelType => Model.GetType();

        public DisplayViewModel(ViewBagWrapper viewBagWrapper, object model)
            : base(viewBagWrapper)
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
