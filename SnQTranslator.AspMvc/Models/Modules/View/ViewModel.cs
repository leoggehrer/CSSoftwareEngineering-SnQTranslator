﻿//@CodeCopy
//MdStart
using CommonBase.Extensions;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SnQTranslator.AspMvc.Models.Modules.View
{
    public abstract partial class ViewModel
    {
        public List<string> HiddenNames { get; } = new List<string>()
        {
            nameof(IdentityModel.Id),
            nameof(VersionModel.RowVersion),
        };
        public List<string> IgnoreNames { get; } = new List<string>()
        {
            nameof(IdentityModel.Id),
            nameof(VersionModel.RowVersion),
            nameof(ModelObject.ViewBagInfo)
        };
        public List<string> DisplayNames { get; } = new List<string>()
        {
        };

        public abstract Type ModelType { get; }
        public virtual List<PropertyInfo> HiddenProperties { get; } = new List<PropertyInfo>();
        public virtual List<PropertyInfo> DisplayProperties { get; } = new List<PropertyInfo>();
        protected ViewModel(string[] hiddenNames, string[] ignoreNames, string[] displayNames)
        {
            if (hiddenNames != null)
                HiddenNames.AddRange(hiddenNames);

            if (ignoreNames != null)
                IgnoreNames.AddRange(ignoreNames);

            if (displayNames != null)
                DisplayNames.AddRange(displayNames);
        }

        public virtual string GetLabel(PropertyInfo propertyInfo)
        {
            propertyInfo.CheckArgument(nameof(propertyInfo));

            return propertyInfo.Name;
        }
    }
}
//MdEnd
