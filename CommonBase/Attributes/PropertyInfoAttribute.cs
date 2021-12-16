﻿//@CodeCopy
//MdStart
using System;

namespace CommonBase.Attributes
{
    /// <summary>
    /// These attributes contain additional information for a 
    /// property that is evaluated during generating.
    /// </summary>
    public abstract partial class PropertyInfoAttribute : Attribute
    {
        private bool notMapped;
        public bool NotMapped
        {
            get => notMapped && HasImplementation == false;
            set => notMapped = value;
        }
        public bool HasImplementation { get; init; }
        public bool IsAutoProperty { get; init; } = true;

        public int Order { get; init; } = 10_000;
        public string ColumnName { get; init; }
        public string NavigationName { get; init; }

        public bool Required { get; init; }
        public bool HasIndex { get; init; }
        public bool IsUnique { get; init; }

        public bool IsFixedLength { get; init; }
        public int Precision { get; init; } = 2;
        public int MinLength { get; init; } = -1;
        public int MaxLength { get; init; } = -1;
        public string RegularExpression { get; init; }
        public ContentType ContentType { get; init; } = ContentType.Undefined;

        public bool HasUniqueIndexWithName { get; init; }
        public string IndexName { get; init; } = string.Empty;
        public int IndexColumnOrder { get; init; }

        public string DefaultValue { get; init; }
        public string DefaultValueSql { get; init; }
        public string Description { get; init; }
    }
}
//MdEnd
