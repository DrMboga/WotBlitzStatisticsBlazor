﻿// <auto-generated/>
#nullable enable

namespace WotBlitzStatisticsPro.Blazor.GraphQl.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "12.12.1.0")]
    public partial class DictionaryBuilder : global::StrawberryShake.IOperationResultBuilder<global::System.Text.Json.JsonDocument, global::WotBlitzStatisticsPro.Blazor.GraphQl.IDictionaryResult>
    {
        private readonly global::StrawberryShake.IEntityStore _entityStore;
        private readonly global::StrawberryShake.IEntityIdSerializer _idSerializer;
        private readonly global::StrawberryShake.IOperationResultDataFactory<global::WotBlitzStatisticsPro.Blazor.GraphQl.IDictionaryResult> _resultDataFactory;
        private readonly global::StrawberryShake.Serialization.ILeafValueParser<global::System.String, global::WotBlitzStatisticsPro.Blazor.GraphQl.RequestLanguage> _requestLanguageParser;
        private readonly global::StrawberryShake.Serialization.ILeafValueParser<global::System.String, global::System.String> _stringParser;
        private readonly global::StrawberryShake.Serialization.ILeafValueParser<global::System.Int64, global::System.Int64> _longParser;
        private readonly global::StrawberryShake.Serialization.ILeafValueParser<global::System.Boolean, global::System.Boolean> _booleanParser;
        private readonly global::StrawberryShake.Serialization.ILeafValueParser<global::System.Int32, global::System.Int32> _intParser;
        private readonly global::StrawberryShake.Serialization.ILeafValueParser<global::System.Decimal, global::System.Decimal> _decimalParser;
        public DictionaryBuilder(global::StrawberryShake.IEntityStore entityStore, global::StrawberryShake.IEntityIdSerializer idSerializer, global::StrawberryShake.IOperationResultDataFactory<global::WotBlitzStatisticsPro.Blazor.GraphQl.IDictionaryResult> resultDataFactory, global::StrawberryShake.Serialization.ISerializerResolver serializerResolver)
        {
            _entityStore = entityStore ?? throw new global::System.ArgumentNullException(nameof(entityStore));
            _idSerializer = idSerializer ?? throw new global::System.ArgumentNullException(nameof(idSerializer));
            _resultDataFactory = resultDataFactory ?? throw new global::System.ArgumentNullException(nameof(resultDataFactory));
            _requestLanguageParser = serializerResolver.GetLeafValueParser<global::System.String, global::WotBlitzStatisticsPro.Blazor.GraphQl.RequestLanguage>("RequestLanguage") ?? throw new global::System.ArgumentException("No serializer for type `RequestLanguage` found.");
            _stringParser = serializerResolver.GetLeafValueParser<global::System.String, global::System.String>("String") ?? throw new global::System.ArgumentException("No serializer for type `String` found.");
            _longParser = serializerResolver.GetLeafValueParser<global::System.Int64, global::System.Int64>("Long") ?? throw new global::System.ArgumentException("No serializer for type `Long` found.");
            _booleanParser = serializerResolver.GetLeafValueParser<global::System.Boolean, global::System.Boolean>("Boolean") ?? throw new global::System.ArgumentException("No serializer for type `Boolean` found.");
            _intParser = serializerResolver.GetLeafValueParser<global::System.Int32, global::System.Int32>("Int") ?? throw new global::System.ArgumentException("No serializer for type `Int` found.");
            _decimalParser = serializerResolver.GetLeafValueParser<global::System.Decimal, global::System.Decimal>("Decimal") ?? throw new global::System.ArgumentException("No serializer for type `Decimal` found.");
        }

        public global::StrawberryShake.IOperationResult<IDictionaryResult> Build(global::StrawberryShake.Response<global::System.Text.Json.JsonDocument> response)
        {
            (IDictionaryResult Result, DictionaryResultInfo Info)? data = null;
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

            return new global::StrawberryShake.OperationResult<IDictionaryResult>(data?.Result, data?.Info, _resultDataFactory, errors);
        }

        private (IDictionaryResult, DictionaryResultInfo) BuildData(global::System.Text.Json.JsonElement obj)
        {
            var entityIds = new global::System.Collections.Generic.HashSet<global::StrawberryShake.EntityId>();
            global::StrawberryShake.IEntityStoreSnapshot snapshot = default !;
            _entityStore.Update(session =>
            {
                snapshot = session.CurrentSnapshot;
            });
            var resultInfo = new DictionaryResultInfo(DeserializeNonNullableIDictionary_VehiclesNonNullableArray(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "vehicles")), entityIds, snapshot.Version);
            return (_resultDataFactory.Create(resultInfo), resultInfo);
        }

        private global::System.Collections.Generic.IReadOnlyList<global::WotBlitzStatisticsPro.Blazor.GraphQl.State.VehicleResponseData> DeserializeNonNullableIDictionary_VehiclesNonNullableArray(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            var vehicleResponses = new global::System.Collections.Generic.List<global::WotBlitzStatisticsPro.Blazor.GraphQl.State.VehicleResponseData>();
            foreach (global::System.Text.Json.JsonElement child in obj.Value.EnumerateArray())
            {
                vehicleResponses.Add(DeserializeNonNullableIDictionary_Vehicles(child));
            }

            return vehicleResponses;
        }

        private global::WotBlitzStatisticsPro.Blazor.GraphQl.State.VehicleResponseData DeserializeNonNullableIDictionary_Vehicles(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            var typename = obj.Value.GetProperty("__typename").GetString();
            if (typename?.Equals("VehicleResponse", global::System.StringComparison.Ordinal) ?? false)
            {
                return new global::WotBlitzStatisticsPro.Blazor.GraphQl.State.VehicleResponseData(typename, tankId: DeserializeNonNullableInt64(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "tankId")), name: DeserializeNonNullableString(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "name")), description: DeserializeNonNullableString(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "description")), isPremium: DeserializeNonNullableBoolean(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "isPremium")), typeId: DeserializeNonNullableString(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "typeId")), nationId: DeserializeNonNullableString(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "nationId")), tier: DeserializeNonNullableInt32(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "tier")), previewImage: DeserializeNonNullableString(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "previewImage")), normalImage: DeserializeNonNullableString(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "normalImage")), priceCredit: DeserializeNonNullableDecimal(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "priceCredit")), priceGold: DeserializeNonNullableDecimal(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "priceGold")), nexTanksInTree: DeserializeInt64NonNullableArray(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "nexTanksInTree")));
            }

            throw new global::System.NotSupportedException();
        }

        private global::System.Int64 DeserializeNonNullableInt64(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            return _longParser.Parse(obj.Value.GetInt64()!);
        }

        private global::System.String DeserializeNonNullableString(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            return _stringParser.Parse(obj.Value.GetString()!);
        }

        private global::System.Boolean DeserializeNonNullableBoolean(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            return _booleanParser.Parse(obj.Value.GetBoolean()!);
        }

        private global::System.Int32 DeserializeNonNullableInt32(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            return _intParser.Parse(obj.Value.GetInt32()!);
        }

        private global::System.Decimal DeserializeNonNullableDecimal(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            return _decimalParser.Parse(obj.Value.GetDecimal()!);
        }

        private global::System.Collections.Generic.IReadOnlyList<global::System.Int64>? DeserializeInt64NonNullableArray(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                return null;
            }

            var @longs = new global::System.Collections.Generic.List<global::System.Int64>();
            foreach (global::System.Text.Json.JsonElement child in obj.Value.EnumerateArray())
            {
                @longs.Add(DeserializeNonNullableInt64(child));
            }

            return @longs;
        }
    }
}
