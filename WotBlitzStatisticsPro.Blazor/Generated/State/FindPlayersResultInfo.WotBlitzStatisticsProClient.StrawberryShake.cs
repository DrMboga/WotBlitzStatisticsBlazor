﻿// <auto-generated/>
#nullable enable

namespace WotBlitzStatisticsPro.Blazor.GraphQl.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.2.2.0")]
    public partial class FindPlayersResultInfo : global::StrawberryShake.IOperationResultDataInfo
    {
        private readonly global::System.Collections.Generic.IReadOnlyCollection<global::StrawberryShake.EntityId> _entityIds;
        private readonly global::System.UInt64 _version;
        public FindPlayersResultInfo(global::System.Collections.Generic.IReadOnlyList<global::WotBlitzStatisticsPro.Blazor.GraphQl.State.AccountsSearchResponseItemData> players, global::System.Collections.Generic.IReadOnlyCollection<global::StrawberryShake.EntityId> entityIds, global::System.UInt64 version)
        {
            Players = players;
            _entityIds = entityIds ?? throw new global::System.ArgumentNullException(nameof(entityIds));
            _version = version;
        }

        /// <summary>
        /// Finds Wargaming accounts by nick
        /// </summary>
        public global::System.Collections.Generic.IReadOnlyList<global::WotBlitzStatisticsPro.Blazor.GraphQl.State.AccountsSearchResponseItemData> Players { get; }

        public global::System.Collections.Generic.IReadOnlyCollection<global::StrawberryShake.EntityId> EntityIds => _entityIds;
        public global::System.UInt64 Version => _version;
        public global::StrawberryShake.IOperationResultDataInfo WithVersion(global::System.UInt64 version)
        {
            return new FindPlayersResultInfo(Players, _entityIds, version);
        }
    }
}
