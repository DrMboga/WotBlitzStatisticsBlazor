﻿// <auto-generated/>
#nullable enable

namespace WotBlitzStatisticsPro.Blazor.GraphQl.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "12.12.1.0")]
    public partial class WargamingOpenIdAuthenticationResultInfo : global::StrawberryShake.IOperationResultDataInfo
    {
        private readonly global::System.Collections.Generic.IReadOnlyCollection<global::StrawberryShake.EntityId> _entityIds;
        private readonly global::System.UInt64 _version;
        public WargamingOpenIdAuthenticationResultInfo(global::WotBlitzStatisticsPro.Blazor.GraphQl.State.WargamingProlongInfoData prolongAuthToken, global::System.Collections.Generic.IReadOnlyCollection<global::StrawberryShake.EntityId> entityIds, global::System.UInt64 version)
        {
            ProlongAuthToken = prolongAuthToken;
            _entityIds = entityIds ?? throw new global::System.ArgumentNullException(nameof(entityIds));
            _version = version;
        }

        /// <summary>
        /// Prolongates Wargaming authentication token
        /// </summary>
        public global::WotBlitzStatisticsPro.Blazor.GraphQl.State.WargamingProlongInfoData ProlongAuthToken { get; }

        public global::System.Collections.Generic.IReadOnlyCollection<global::StrawberryShake.EntityId> EntityIds => _entityIds;
        public global::System.UInt64 Version => _version;
        public global::StrawberryShake.IOperationResultDataInfo WithVersion(global::System.UInt64 version)
        {
            return new WargamingOpenIdAuthenticationResultInfo(ProlongAuthToken, _entityIds, version);
        }
    }
}
