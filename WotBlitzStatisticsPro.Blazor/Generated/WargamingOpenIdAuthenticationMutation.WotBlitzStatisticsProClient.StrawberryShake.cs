﻿// <auto-generated/>
#nullable enable

namespace WotBlitzStatisticsPro.Blazor.GraphQl
{
    /// <summary>
    /// Represents the operation service of the WargamingOpenIdAuthentication GraphQL operation
    /// <code>
    /// mutation WargamingOpenIdAuthentication($oldToken: String!, $realmType: RealmType!) {
    ///   prolongAuthToken(oldToken: $oldToken, realm: $realmType) {
    ///     __typename
    ///     accessToken
    ///     accountId
    ///     expirationTimeStamp
    ///   }
    /// }
    /// </code>
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.2.2.0")]
    public partial class WargamingOpenIdAuthenticationMutation : global::WotBlitzStatisticsPro.Blazor.GraphQl.IWargamingOpenIdAuthenticationMutation
    {
        private readonly global::StrawberryShake.IOperationExecutor<IWargamingOpenIdAuthenticationResult> _operationExecutor;
        private readonly global::StrawberryShake.Serialization.IInputValueFormatter _stringFormatter;
        private readonly global::StrawberryShake.Serialization.IInputValueFormatter _realmTypeFormatter;
        public WargamingOpenIdAuthenticationMutation(global::StrawberryShake.IOperationExecutor<IWargamingOpenIdAuthenticationResult> operationExecutor, global::StrawberryShake.Serialization.ISerializerResolver serializerResolver)
        {
            _operationExecutor = operationExecutor ?? throw new global::System.ArgumentNullException(nameof(operationExecutor));
            _stringFormatter = serializerResolver.GetInputValueFormatter("String");
            _realmTypeFormatter = serializerResolver.GetInputValueFormatter("RealmType");
        }

        global::System.Type global::StrawberryShake.IOperationRequestFactory.ResultType => typeof(IWargamingOpenIdAuthenticationResult);
        public async global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<IWargamingOpenIdAuthenticationResult>> ExecuteAsync(global::System.String oldToken, global::WotBlitzStatisticsPro.Blazor.GraphQl.RealmType realmType, global::System.Threading.CancellationToken cancellationToken = default)
        {
            var request = CreateRequest(oldToken, realmType);
            return await _operationExecutor.ExecuteAsync(request, cancellationToken).ConfigureAwait(false);
        }

        public global::System.IObservable<global::StrawberryShake.IOperationResult<IWargamingOpenIdAuthenticationResult>> Watch(global::System.String oldToken, global::WotBlitzStatisticsPro.Blazor.GraphQl.RealmType realmType, global::StrawberryShake.ExecutionStrategy? strategy = null)
        {
            var request = CreateRequest(oldToken, realmType);
            return _operationExecutor.Watch(request, strategy);
        }

        private global::StrawberryShake.OperationRequest CreateRequest(global::System.String oldToken, global::WotBlitzStatisticsPro.Blazor.GraphQl.RealmType realmType)
        {
            var variables = new global::System.Collections.Generic.Dictionary<global::System.String, global::System.Object?>();
            variables.Add("oldToken", FormatOldToken(oldToken));
            variables.Add("realmType", FormatRealmType(realmType));
            return CreateRequest(variables);
        }

        private global::StrawberryShake.OperationRequest CreateRequest(global::System.Collections.Generic.IReadOnlyDictionary<global::System.String, global::System.Object?>? variables)
        {
            return new global::StrawberryShake.OperationRequest(id: WargamingOpenIdAuthenticationMutationDocument.Instance.Hash.Value, name: "WargamingOpenIdAuthentication", document: WargamingOpenIdAuthenticationMutationDocument.Instance, strategy: global::StrawberryShake.RequestStrategy.Default, variables: variables);
        }

        private global::System.Object? FormatOldToken(global::System.String value)
        {
            if (value is null)
            {
                throw new global::System.ArgumentNullException(nameof(value));
            }

            return _stringFormatter.Format(value);
        }

        private global::System.Object? FormatRealmType(global::WotBlitzStatisticsPro.Blazor.GraphQl.RealmType value)
        {
            return _realmTypeFormatter.Format(value);
        }

        global::StrawberryShake.OperationRequest global::StrawberryShake.IOperationRequestFactory.Create(global::System.Collections.Generic.IReadOnlyDictionary<global::System.String, global::System.Object?>? variables)
        {
            return CreateRequest(variables!);
        }
    }
}