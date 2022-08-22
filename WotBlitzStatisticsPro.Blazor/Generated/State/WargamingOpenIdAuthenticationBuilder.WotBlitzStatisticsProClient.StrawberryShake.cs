﻿// <auto-generated/>
#nullable enable

namespace WotBlitzStatisticsPro.Blazor.GraphQl.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "12.12.1.0")]
    public partial class WargamingOpenIdAuthenticationBuilder : global::StrawberryShake.IOperationResultBuilder<global::System.Text.Json.JsonDocument, global::WotBlitzStatisticsPro.Blazor.GraphQl.IWargamingOpenIdAuthenticationResult>
    {
        private readonly global::StrawberryShake.IEntityStore _entityStore;
        private readonly global::StrawberryShake.IEntityIdSerializer _idSerializer;
        private readonly global::StrawberryShake.IOperationResultDataFactory<global::WotBlitzStatisticsPro.Blazor.GraphQl.IWargamingOpenIdAuthenticationResult> _resultDataFactory;
        private readonly global::StrawberryShake.Serialization.ILeafValueParser<global::System.String, global::WotBlitzStatisticsPro.Blazor.GraphQl.RealmType> _realmTypeParser;
        private readonly global::StrawberryShake.Serialization.ILeafValueParser<global::System.String, global::System.String> _stringParser;
        private readonly global::StrawberryShake.Serialization.ILeafValueParser<global::System.Int64, global::System.Int64> _longParser;
        private readonly global::StrawberryShake.Serialization.ILeafValueParser<global::System.Int32, global::System.Int32> _intParser;
        public WargamingOpenIdAuthenticationBuilder(global::StrawberryShake.IEntityStore entityStore, global::StrawberryShake.IEntityIdSerializer idSerializer, global::StrawberryShake.IOperationResultDataFactory<global::WotBlitzStatisticsPro.Blazor.GraphQl.IWargamingOpenIdAuthenticationResult> resultDataFactory, global::StrawberryShake.Serialization.ISerializerResolver serializerResolver)
        {
            _entityStore = entityStore ?? throw new global::System.ArgumentNullException(nameof(entityStore));
            _idSerializer = idSerializer ?? throw new global::System.ArgumentNullException(nameof(idSerializer));
            _resultDataFactory = resultDataFactory ?? throw new global::System.ArgumentNullException(nameof(resultDataFactory));
            _realmTypeParser = serializerResolver.GetLeafValueParser<global::System.String, global::WotBlitzStatisticsPro.Blazor.GraphQl.RealmType>("RealmType") ?? throw new global::System.ArgumentException("No serializer for type `RealmType` found.");
            _stringParser = serializerResolver.GetLeafValueParser<global::System.String, global::System.String>("String") ?? throw new global::System.ArgumentException("No serializer for type `String` found.");
            _longParser = serializerResolver.GetLeafValueParser<global::System.Int64, global::System.Int64>("Long") ?? throw new global::System.ArgumentException("No serializer for type `Long` found.");
            _intParser = serializerResolver.GetLeafValueParser<global::System.Int32, global::System.Int32>("Int") ?? throw new global::System.ArgumentException("No serializer for type `Int` found.");
        }

        public global::StrawberryShake.IOperationResult<IWargamingOpenIdAuthenticationResult> Build(global::StrawberryShake.Response<global::System.Text.Json.JsonDocument> response)
        {
            (IWargamingOpenIdAuthenticationResult Result, WargamingOpenIdAuthenticationResultInfo Info)? data = null;
            global::System.Collections.Generic.IReadOnlyList<global::StrawberryShake.IClientError>? errors = null;
            if (response.Exception is null)
            {
                try
                {
                    if (response.Body != null)
                    {
                        if (response.Body.RootElement.TryGetProperty("data", out global::System.Text.Json.JsonElement dataElement) && dataElement.ValueKind == global::System.Text.Json.JsonValueKind.Object)
                        {
                            data = BuildData(dataElement);
                        }

                        if (response.Body.RootElement.TryGetProperty("errors", out global::System.Text.Json.JsonElement errorsElement))
                        {
                            errors = global::StrawberryShake.Json.JsonErrorParser.ParseErrors(errorsElement);
                        }
                    }
                }
                catch (global::System.Exception ex)
                {
                    errors = new global::StrawberryShake.IClientError[]{new global::StrawberryShake.ClientError(ex.Message, exception: ex, extensions: new global::System.Collections.Generic.Dictionary<global::System.String, global::System.Object?>{{"body", response.Body?.RootElement.ToString()}})};
                }
            }
            else
            {
                if (response.Body != null && response.Body.RootElement.TryGetProperty("errors", out global::System.Text.Json.JsonElement errorsElement))
                {
                    errors = global::StrawberryShake.Json.JsonErrorParser.ParseErrors(errorsElement);
                }
                else
                {
                    errors = new global::StrawberryShake.IClientError[]{new global::StrawberryShake.ClientError(response.Exception.Message, exception: response.Exception, extensions: new global::System.Collections.Generic.Dictionary<global::System.String, global::System.Object?>{{"body", response.Body?.RootElement.ToString()}})};
                }
            }

            return new global::StrawberryShake.OperationResult<IWargamingOpenIdAuthenticationResult>(data?.Result, data?.Info, _resultDataFactory, errors);
        }

        private (IWargamingOpenIdAuthenticationResult, WargamingOpenIdAuthenticationResultInfo) BuildData(global::System.Text.Json.JsonElement obj)
        {
            var entityIds = new global::System.Collections.Generic.HashSet<global::StrawberryShake.EntityId>();
            global::StrawberryShake.IEntityStoreSnapshot snapshot = default !;
            _entityStore.Update(session =>
            {
                snapshot = session.CurrentSnapshot;
            });
            var resultInfo = new WargamingOpenIdAuthenticationResultInfo(DeserializeNonNullableIWargamingOpenIdAuthentication_ProlongAuthToken(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "prolongAuthToken")), entityIds, snapshot.Version);
            return (_resultDataFactory.Create(resultInfo), resultInfo);
        }

        private global::WotBlitzStatisticsPro.Blazor.GraphQl.State.WargamingProlongInfoData DeserializeNonNullableIWargamingOpenIdAuthentication_ProlongAuthToken(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            var typename = obj.Value.GetProperty("__typename").GetString();
            if (typename?.Equals("WargamingProlongInfo", global::System.StringComparison.Ordinal) ?? false)
            {
                return new global::WotBlitzStatisticsPro.Blazor.GraphQl.State.WargamingProlongInfoData(typename, accessToken: DeserializeNonNullableString(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "accessToken")), accountId: DeserializeNonNullableInt64(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "accountId")), expirationTimeStamp: DeserializeNonNullableInt32(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "expirationTimeStamp")));
            }

            throw new global::System.NotSupportedException();
        }

        private global::System.String DeserializeNonNullableString(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            return _stringParser.Parse(obj.Value.GetString()!);
        }

        private global::System.Int64 DeserializeNonNullableInt64(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            return _longParser.Parse(obj.Value.GetInt64()!);
        }

        private global::System.Int32 DeserializeNonNullableInt32(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            return _intParser.Parse(obj.Value.GetInt32()!);
        }
    }
}
