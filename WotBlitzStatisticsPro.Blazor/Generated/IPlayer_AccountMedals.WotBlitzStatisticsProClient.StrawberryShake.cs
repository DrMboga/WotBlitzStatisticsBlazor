﻿// <auto-generated/>
#nullable enable

namespace WotBlitzStatisticsPro.Blazor.GraphQl
{
    /// <summary>
    /// Represents information about player's achievements
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "12.12.1.0")]
    public partial interface IPlayer_AccountMedals
    {
        /// <summary>
        /// Player Id
        /// </summary>
        public global::System.Int64 AccountId { get; }

        /// <summary>
        /// Player Achievements by sections
        /// </summary>
        public global::System.Collections.Generic.IReadOnlyList<global::WotBlitzStatisticsPro.Blazor.GraphQl.IPlayer_AccountMedals_Sections>? Sections { get; }
    }
}
