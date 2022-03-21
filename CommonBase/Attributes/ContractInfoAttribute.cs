﻿//@CodeCopy
//MdStart
using System;

namespace CommonBase.Attributes
{
    /// <summary>
    /// These attributes serve to enrich the interface with additional 
    /// information for the generation.
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface)]
    public partial class ContractInfoAttribute : Attribute
    {
        private bool hasWebApiAccess = true;

        public ContextType ContextType { get; init; } = ContextType.Table;
        public string SchemaName { get; init; }
        public string ContextName { get; init; }
        public string KeyName { get; init; }
        public string Description { get; init; }
        public Type DelegateType { get; init; }
        public bool HasLogicAccess { get; init; } = true;
        public bool HasWebApiAccess
        {
            get { return hasWebApiAccess && HasLogicAccess; }
            set { hasWebApiAccess = value; }
        }
    }
}
//MdEnd
