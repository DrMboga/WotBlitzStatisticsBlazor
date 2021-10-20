﻿// <auto-generated/>
#nullable enable

namespace WotBlitzStatisticsPro.Blazor.GraphQl
{
    /// <summary>
    /// Represents the operation service of the WargamingAuthenticationQuery GraphQL operation
    /// <code>
    /// query WargamingAuthenticationQuery($realmType: RealmType!) {
    ///   loginUrl(realmType: $realmType)
    /// }
    /// </code>
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.2.2.0")]
    public partial class WargamingAuthenticationQueryQueryDocument : global::StrawberryShake.IDocument
    {
        private WargamingAuthenticationQueryQueryDocument()
        {
        }

        public static WargamingAuthenticationQueryQueryDocument Instance { get; } = new WargamingAuthenticationQueryQueryDocument();
        public global::StrawberryShake.OperationKind Kind => global::StrawberryShake.OperationKind.Query;
        public global::System.ReadOnlySpan<global::System.Byte> Body => new global::System.Byte[]{0x71, 0x75, 0x65, 0x72, 0x79, 0x20, 0x57, 0x61, 0x72, 0x67, 0x61, 0x6d, 0x69, 0x6e, 0x67, 0x41, 0x75, 0x74, 0x68, 0x65, 0x6e, 0x74, 0x69, 0x63, 0x61, 0x74, 0x69, 0x6f, 0x6e, 0x51, 0x75, 0x65, 0x72, 0x79, 0x28, 0x24, 0x72, 0x65, 0x61, 0x6c, 0x6d, 0x54, 0x79, 0x70, 0x65, 0x3a, 0x20, 0x52, 0x65, 0x61, 0x6c, 0x6d, 0x54, 0x79, 0x70, 0x65, 0x21, 0x29, 0x20, 0x7b, 0x20, 0x6c, 0x6f, 0x67, 0x69, 0x6e, 0x55, 0x72, 0x6c, 0x28, 0x72, 0x65, 0x61, 0x6c, 0x6d, 0x54, 0x79, 0x70, 0x65, 0x3a, 0x20, 0x24, 0x72, 0x65, 0x61, 0x6c, 0x6d, 0x54, 0x79, 0x70, 0x65, 0x29, 0x20, 0x7d};
        public global::StrawberryShake.DocumentHash Hash { get; } = new global::StrawberryShake.DocumentHash("md5Hash", "f467abbe316298d2d118610155cfcc64");
        public override global::System.String ToString()
        {
#if NETSTANDARD2_0
        return global::System.Text.Encoding.UTF8.GetString(Body.ToArray());
#else
            return global::System.Text.Encoding.UTF8.GetString(Body);
#endif
        }
    }
}
