﻿//@CodeCopy
//MdStart

using System;

namespace CSharpCodeGenerator.Logic.Common
{
    [Flags]
    public enum ItemType : ulong
    {
        DbContext = 1,
        Factory = 2,

        BusinessEntity = 32,
        ModuleEntity = 64,
        PersistenceEntity = 128,
        ShadowEntity = 256,
        Entiy = BusinessEntity + ModuleEntity + PersistenceEntity + ShadowEntity,

        BusinessModel = 512,
        ModuleModel = 1024,
        PersistenceModel = 2048,
        ShadowModel = 4096,
        ThridPartyModel = (ulong)8192,
        Model = BusinessModel + ModuleModel + PersistenceModel + ShadowModel,

        LogicController = (ulong)8192 * 2,
        WebApiController = (ulong)8192 * 4,
        AspMvcController = (ulong)8192 * 8,
        Controller = LogicController + WebApiController + AspMvcController,
    }
}
//MdEnd
