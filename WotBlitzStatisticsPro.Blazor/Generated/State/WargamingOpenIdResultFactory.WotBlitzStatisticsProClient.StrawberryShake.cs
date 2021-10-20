﻿// <auto-generated/>
#nullable enable

namespace WotBlitzStatisticsPro.Blazor.GraphQl.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.2.2.0")]
    public partial class WargamingOpenIdResultFactory : global::StrawberryShake.IOperationResultDataFactory<global::WotBlitzStatisticsPro.Blazor.GraphQl.WargamingOpenIdResult>
    {
        private readonly global::StrawberryShake.IEntityStore _entityStore;
        public WargamingOpenIdResultFactory(global::StrawberryShake.IEntityStore entityStore)
        {
            _entityStore = entityStore ?? throw new global::System.ArgumentNullException(nameof(entityStore));
        }

        global::System.Type global::StrawberryShake.IOperationResultDataFactory.ResultType => typeof(global::WotBlitzStatisticsPro.Blazor.GraphQl.IWargamingOpenIdResult);
        public WargamingOpenIdResult Create(global::StrawberryShake.IOperationResultDataInfo dataInfo, global::StrawberryShake.IEntityStoreSnapshot? snapshot = null)
        {
            if (snapshot is null)
            {
                snapshot = _entityStore.CurrentSnapshot;
            }

            if (dataInfo is WargamingOpenIdResultInfo info)
            {
                return new WargamingOpenIdResult(info.Logout);
            }

            throw new global::System.ArgumentException("WargamingOpenIdResultInfo expected.");
        }

        global::System.Object global::StrawberryShake.IOperationResultDataFactory.Create(global::StrawberryShake.IOperationResultDataInfo dataInfo, global::StrawberryShake.IEntityStoreSnapshot? snapshot)
        {
            return Create(dataInfo, snapshot);
        }
    }
}