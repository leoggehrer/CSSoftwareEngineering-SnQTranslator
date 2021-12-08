﻿//@CodeCopy
//MdStart
using CommonBase.Extensions;
using SnQTranslator.AspMvc.Modules.View;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SnQTranslator.AspMvc.Models.Modules.View
{
    public class IndexDisplayViewModel : ViewModel, IDisplayViewModel
    {
        private ModelObject model;
        private ModelObject displayModel;
        private IEnumerable<PropertyInfo> displayProperties;

        public ModelObject Model
        {
            get => model;
            set
            {
                model = value ?? model;
            }
        }
        public ModelObject DisplayModel
        {
            get => displayModel ?? model;
            set => displayModel = value;
        }
        public IEnumerable<PropertyInfo> DisplayProperties 
        {
            get => displayProperties; 
            set => displayProperties = value ?? displayProperties; 
        }

        public IndexDisplayViewModel(ViewBagWrapper viewBagInfo, Type modelType, Type displayType, ModelObject model, IEnumerable<PropertyInfo> displayProperties)
            : base(viewBagInfo, modelType, displayType)
        {
            model.CheckArgument(nameof(model));
            displayProperties.CheckArgument(nameof(displayProperties));

            Model = model;
            DisplayProperties = displayProperties;
        }
        public virtual IEnumerable<PropertyInfo> GetDisplayProperties()
        {
            return DisplayProperties;
        }

        public virtual object GetValue(PropertyInfo propertyInfo)
        {
            return GetValue(DisplayModel, propertyInfo);
        }
        public virtual string GetDisplayValue(PropertyInfo propertyInfo)
        {
            return GetDisplayValue(DisplayModel, propertyInfo);
        }
    }
}
//MdEnd
