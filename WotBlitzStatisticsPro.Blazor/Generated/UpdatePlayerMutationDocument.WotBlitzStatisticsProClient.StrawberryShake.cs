﻿// <auto-generated/>
#nullable enable

namespace WotBlitzStatisticsPro.Blazor.GraphQl
{
    /// <summary>
    /// Represents the operation service of the UpdatePlayer GraphQL operation
    /// <code>
    /// mutation UpdatePlayer($accountId: Long!, $realmType: RealmType!, $requestLanguage: RequestLanguage!) {
    ///   gatherAccountInformation(accountId: $accountId, realmType: $realmType, requestLanguage: $requestLanguage)
    /// }
    /// </code>
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "12.12.1.0")]
    public partial class UpdatePlayerMutationDocument : global::StrawberryShake.IDocument
    {
        private UpdatePlayerMutationDocument()
        {
        }

        public static UpdatePlayerMutationDocument Instance { get; } = new UpdatePlayerMutationDocument();
        public global::StrawberryShake.OperationKind Kind => global::StrawberryShake.OperationKind.Mutation;
        public global::System.ReadOnlySpan<global::System.Byte> Body => new global::System.Byte[]{0x6d, 0x75, 0x74, 0x61, 0x74, 0x69, 0x6f, 0x6e, 0x20, 0x55, 0x70, 0x64, 0x61, 0x74, 0x65, 0x50, 0x6c, 0x61, 0x79, 0x65, 0x72, 0x28, 0x24, 0x61, 0x63, 0x63, 0x6f, 0x75, 0x6e, 0x74, 0x49, 0x64, 0x3a, 0x20, 0x4c, 0x6f, 0x6e, 0x67, 0x21, 0x2c, 0x20, 0x24, 0x72, 0x65, 0x61, 0x6c, 0x6d, 0x54, 0x79, 0x70, 0x65, 0x3a, 0x20, 0x52, 0x65, 0x61, 0x6c, 0x6d, 0x54, 0x79, 0x70, 0x65, 0x21, 0x2c, 0x20, 0x24, 0x72, 0x65, 0x71, 0x75, 0x65, 0x73, 0x74, 0x4c, 0x61, 0x6e, 0x67, 0x75, 0x61, 0x67, 0x65, 0x3a, 0x20, 0x52, 0x65, 0x71, 0x75, 0x65, 0x73, 0x74, 0x4c, 0x61, 0x6e, 0x67, 0x75, 0x61, 0x67, 0x65, 0x21, 0x29, 0x20, 0x7b, 0x20, 0x67, 0x61, 0x74, 0x68, 0x65, 0x72, 0x41, 0x63, 0x63, 0x6f, 0x75, 0x6e, 0x74, 0x49, 0x6e, 0x66, 0x6f, 0x72, 0x6d, 0x61, 0x74, 0x69, 0x6f, 0x6e, 0x28, 0x61, 0x63, 0x63, 0x6f, 0x75, 0x6e, 0x74, 0x49, 0x64, 0x3a, 0x20, 0x24, 0x61, 0x63, 0x63, 0x6f, 0x75, 0x6e, 0x74, 0x49, 0x64, 0x2c, 0x20, 0x72, 0x65, 0x61, 0x6c, 0x6d, 0x54, 0x79, 0x70, 0x65, 0x3a, 0x20, 0x24, 0x72, 0x65, 0x61, 0x6c, 0x6d, 0x54, 0x79, 0x70, 0x65, 0x2c, 0x20, 0x72, 0x65, 0x71, 0x75, 0x65, 0x73, 0x74, 0x4c, 0x61, 0x6e, 0x67, 0x75, 0x61, 0x67, 0x65, 0x3a, 0x20, 0x24, 0x72, 0x65, 0x71, 0x75, 0x65, 0x73, 0x74, 0x4c, 0x61, 0x6e, 0x67, 0x75, 0x61, 0x67, 0x65, 0x29, 0x20, 0x7d};
        public global::StrawberryShake.DocumentHash Hash { get; } = new global::StrawberryShake.DocumentHash("md5Hash", "8867fe2775ba9b1603c64f232456af15");
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
