//@CodeCopy
//MdStart
using CommonBase.Extensions;
using System;
using System.Linq;
using System.Reflection;

namespace SnQTranslator.AspMvc.Models.Modules.View
{
    public partial class DisplayViewModel : ViewModel
    {
        public object Model { get; init; }
        public override Type ModelType => Model.GetType();

        public DisplayViewModel(object model)
            : this(model, null, null, null)
        {
        }
        public DisplayViewModel(object model, dynamic viewBag)
            : this(model, viewBag.HiddenNames as string[],
                          viewBag.IgnoreNames as string[],
                          viewBag.DisplayNames as string[])
        {
        }
        public DisplayViewModel(object model, string[] hiddenNames, string[] ignoreNames, string[] displayNames)
            : base(hiddenNames, ignoreNames, displayNames)
        {
            model.CheckArgument(nameof(model));

            Model = model;
            Init();
        }
        private void Init()
        {
            foreach (var item in ModelType.GetAllInterfacePropertyInfos())
            {
                if (item.CanRead && HiddenNames.Any(e => e.Equals(item.Name)))
                {
                    HiddenProperties.Add(item);
                }
                if (item.CanRead && DisplayNames.Any(e => e.Equals(item.Name)))
                {
                    DisplayProperties.Add(item);
                }
                else if (item.CanRead && DisplayNames.Count == 0 && IgnoreNames.Any(e => e.Equals(item.Name)) == false)
                {
                    DisplayProperties.Add(item);
                }
            }
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
