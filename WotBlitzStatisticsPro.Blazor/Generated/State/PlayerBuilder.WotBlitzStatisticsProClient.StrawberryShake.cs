﻿// <auto-generated/>
#nullable enable

namespace WotBlitzStatisticsPro.Blazor.GraphQl.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.2.2.0")]
    public partial class PlayerBuilder : global::StrawberryShake.IOperationResultBuilder<global::System.Text.Json.JsonDocument, global::WotBlitzStatisticsPro.Blazor.GraphQl.IPlayerResult>
    {
        private readonly global::StrawberryShake.IEntityStore _entityStore;
        private readonly global::StrawberryShake.IEntityIdSerializer _idSerializer;
        private readonly global::StrawberryShake.IOperationResultDataFactory<global::WotBlitzStatisticsPro.Blazor.GraphQl.IPlayerResult> _resultDataFactory;
        private readonly global::StrawberryShake.Serialization.ILeafValueParser<global::System.String, global::WotBlitzStatisticsPro.Blazor.GraphQl.RealmType> _realmTypeParser;
        private readonly global::StrawberryShake.Serialization.ILeafValueParser<global::System.String, global::WotBlitzStatisticsPro.Blazor.GraphQl.RequestLanguage> _requestLanguageParser;
        private readonly global::StrawberryShake.Serialization.ILeafValueParser<global::System.String, global::WotBlitzStatisticsPro.Blazor.GraphQl.MarkOfMastery> _markOfMasteryParser;
        private readonly global::StrawberryShake.Serialization.ILeafValueParser<global::System.Int64, global::System.Int64> _longParser;
        private readonly global::StrawberryShake.Serialization.ILeafValueParser<global::System.String, global::System.DateTimeOffset> _dateTimeParser;
        private readonly global::StrawberryShake.Serialization.ILeafValueParser<global::System.String, global::System.String> _stringParser;
        private readonly global::StrawberryShake.Serialization.ILeafValueParser<global::System.Double, global::System.Double> _floatParser;
        private readonly global::StrawberryShake.Serialization.ILeafValueParser<global::System.Decimal, global::System.Decimal> _decimalParser;
        private readonly global::StrawberryShake.Serialization.ILeafValueParser<global::System.Int32, global::System.Int32> _intParser;
        private readonly global::StrawberryShake.Serialization.ILeafValueParser<global::System.Boolean, global::System.Boolean> _booleanParser;
        public PlayerBuilder(global::StrawberryShake.IEntityStore entityStore, global::StrawberryShake.IEntityIdSerializer idSerializer, global::StrawberryShake.IOperationResultDataFactory<global::WotBlitzStatisticsPro.Blazor.GraphQl.IPlayerResult> resultDataFactory, global::StrawberryShake.Serialization.ISerializerResolver serializerResolver)
        {
            _entityStore = entityStore ?? throw new global::System.ArgumentNullException(nameof(entityStore));
            _idSerializer = idSerializer ?? throw new global::System.ArgumentNullException(nameof(idSerializer));
            _resultDataFactory = resultDataFactory ?? throw new global::System.ArgumentNullException(nameof(resultDataFactory));
            _realmTypeParser = serializerResolver.GetLeafValueParser<global::System.String, global::WotBlitzStatisticsPro.Blazor.GraphQl.RealmType>("RealmType") ?? throw new global::System.ArgumentException("No serializer for type `RealmType` found.");
            _requestLanguageParser = serializerResolver.GetLeafValueParser<global::System.String, global::WotBlitzStatisticsPro.Blazor.GraphQl.RequestLanguage>("RequestLanguage") ?? throw new global::System.ArgumentException("No serializer for type `RequestLanguage` found.");
            _markOfMasteryParser = serializerResolver.GetLeafValueParser<global::System.String, global::WotBlitzStatisticsPro.Blazor.GraphQl.MarkOfMastery>("MarkOfMastery") ?? throw new global::System.ArgumentException("No serializer for type `MarkOfMastery` found.");
            _longParser = serializerResolver.GetLeafValueParser<global::System.Int64, global::System.Int64>("Long") ?? throw new global::System.ArgumentException("No serializer for type `Long` found.");
            _dateTimeParser = serializerResolver.GetLeafValueParser<global::System.String, global::System.DateTimeOffset>("DateTime") ?? throw new global::System.ArgumentException("No serializer for type `DateTime` found.");
            _stringParser = serializerResolver.GetLeafValueParser<global::System.String, global::System.String>("String") ?? throw new global::System.ArgumentException("No serializer for type `String` found.");
            _floatParser = serializerResolver.GetLeafValueParser<global::System.Double, global::System.Double>("Float") ?? throw new global::System.ArgumentException("No serializer for type `Float` found.");
            _decimalParser = serializerResolver.GetLeafValueParser<global::System.Decimal, global::System.Decimal>("Decimal") ?? throw new global::System.ArgumentException("No serializer for type `Decimal` found.");
            _intParser = serializerResolver.GetLeafValueParser<global::System.Int32, global::System.Int32>("Int") ?? throw new global::System.ArgumentException("No serializer for type `Int` found.");
            _booleanParser = serializerResolver.GetLeafValueParser<global::System.Boolean, global::System.Boolean>("Boolean") ?? throw new global::System.ArgumentException("No serializer for type `Boolean` found.");
        }

        public global::StrawberryShake.IOperationResult<IPlayerResult> Build(global::StrawberryShake.Response<global::System.Text.Json.JsonDocument> response)
        {
            (IPlayerResult Result, PlayerResultInfo Info)? data = null;
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
                errors = new global::StrawberryShake.IClientError[]{new global::StrawberryShake.ClientError(response.Exception.Message, exception: response.Exception, extensions: new global::System.Collections.Generic.Dictionary<global::System.String, global::System.Object?>{{"body", response.Body?.RootElement.ToString()}})};
            }

            return new global::StrawberryShake.OperationResult<IPlayerResult>(data?.Result, data?.Info, _resultDataFactory, errors);
        }

        private (IPlayerResult, PlayerResultInfo) BuildData(global::System.Text.Json.JsonElement obj)
        {
            var entityIds = new global::System.Collections.Generic.HashSet<global::StrawberryShake.EntityId>();
            global::StrawberryShake.IEntityStoreSnapshot snapshot = default !;
            _entityStore.Update(session =>
            {
                snapshot = session.CurrentSnapshot;
            });
            var resultInfo = new PlayerResultInfo(DeserializeNonNullableIPlayer_AccountInfo(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "accountInfo")), entityIds, snapshot.Version);
            return (_resultDataFactory.Create(resultInfo), resultInfo);
        }

        private global::WotBlitzStatisticsPro.Blazor.GraphQl.State.AccountInfoResponseData DeserializeNonNullableIPlayer_AccountInfo(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            var typename = obj.Value.GetProperty("__typename").GetString();
            if (typename?.Equals("AccountInfoResponse", global::System.StringComparison.Ordinal) ?? false)
            {
                return new global::WotBlitzStatisticsPro.Blazor.GraphQl.State.AccountInfoResponseData(typename, accountId: DeserializeNonNullableInt64(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "accountId")), createdAt: DeserializeNonNullableDateTimeOffset(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "createdAt")), lastBattleTime: DeserializeNonNullableDateTimeOffset(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "lastBattleTime")), nickname: DeserializeString(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "nickname")), maxFragsTankId: DeserializeNonNullableInt64(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "maxFragsTankId")), maxXpTankId: DeserializeNonNullableInt64(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "maxXpTankId")), battles: DeserializeNonNullableInt64(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "battles")), capturePoints: DeserializeNonNullableInt64(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "capturePoints")), damageDealt: DeserializeNonNullableInt64(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "damageDealt")), damageReceived: DeserializeNonNullableInt64(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "damageReceived")), droppedCapturePoints: DeserializeNonNullableInt64(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "droppedCapturePoints")), frags: DeserializeNonNullableInt64(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "frags")), frags8P: DeserializeNonNullableInt64(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "frags8P")), hits: DeserializeNonNullableInt64(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "hits")), losses: DeserializeNonNullableInt64(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "losses")), maxFrags: DeserializeNonNullableInt64(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "maxFrags")), maxXp: DeserializeNonNullableInt64(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "maxXp")), shots: DeserializeNonNullableInt64(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "shots")), spotted: DeserializeNonNullableInt64(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "spotted")), survivedBattles: DeserializeNonNullableInt64(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "survivedBattles")), winAndSurvived: DeserializeNonNullableInt64(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "winAndSurvived")), wins: DeserializeNonNullableInt64(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "wins")), xp: DeserializeNonNullableInt64(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "xp")), wn7: DeserializeNonNullableDouble(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "wn7")), winRate: DeserializeNonNullableDecimal(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "winRate")), avgDamage: DeserializeNonNullableDecimal(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "avgDamage")), avgXp: DeserializeNonNullableDecimal(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "avgXp")), damageCoefficient: DeserializeNonNullableDecimal(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "damageCoefficient")), survivalRate: DeserializeNonNullableDecimal(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "survivalRate")), avgTier: DeserializeNonNullableDouble(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "avgTier")), clanInfo: DeserializeIPlayer_AccountInfo_ClanInfo(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "clanInfo")), tanks: DeserializeIPlayer_AccountInfo_TanksNonNullableArray(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "tanks")));
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

        private global::System.DateTimeOffset DeserializeNonNullableDateTimeOffset(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            return _dateTimeParser.Parse(obj.Value.GetString()!);
        }

        private global::System.String? DeserializeString(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                return null;
            }

            return _stringParser.Parse(obj.Value.GetString()!);
        }

        private global::System.Double DeserializeNonNullableDouble(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            return _floatParser.Parse(obj.Value.GetDouble()!);
        }

        private global::System.Decimal DeserializeNonNullableDecimal(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            return _decimalParser.Parse(obj.Value.GetDecimal()!);
        }

        private global::WotBlitzStatisticsPro.Blazor.GraphQl.State.ClanInfoResponseData? DeserializeIPlayer_AccountInfo_ClanInfo(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                return null;
            }

            var typename = obj.Value.GetProperty("__typename").GetString();
            if (typename?.Equals("ClanInfoResponse", global::System.StringComparison.Ordinal) ?? false)
            {
                return new global::WotBlitzStatisticsPro.Blazor.GraphQl.State.ClanInfoResponseData(typename, clanId: DeserializeNonNullableInt64(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "clanId")), joinedAt: DeserializeNonNullableDateTimeOffset(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "joinedAt")), role: DeserializeString(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "role")), roleLocalized: DeserializeNonNullableString(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "roleLocalized")), name: DeserializeString(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "name")), createdAt: DeserializeNonNullableDateTimeOffset(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "createdAt")), creatorId: DeserializeInt64(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "creatorId")), creatorName: DeserializeString(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "creatorName")), description: DeserializeString(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "description")), descriptionHtml: DeserializeString(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "descriptionHtml")), leaderId: DeserializeInt64(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "leaderId")), leaderName: DeserializeString(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "leaderName")), membersCount: DeserializeInt64(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "membersCount")), motto: DeserializeString(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "motto")), tag: DeserializeString(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "tag")), updatedAt: DeserializeDateTimeOffset(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "updatedAt")));
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

        private global::System.Int64? DeserializeInt64(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                return null;
            }

            return _longParser.Parse(obj.Value.GetInt64()!);
        }

        private global::System.DateTimeOffset? DeserializeDateTimeOffset(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                return null;
            }

            return _dateTimeParser.Parse(obj.Value.GetString()!);
        }

        private global::System.Collections.Generic.IReadOnlyList<global::WotBlitzStatisticsPro.Blazor.GraphQl.State.TankInfoResponseData>? DeserializeIPlayer_AccountInfo_TanksNonNullableArray(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                return null;
            }

            var tankInfoResponses = new global::System.Collections.Generic.List<global::WotBlitzStatisticsPro.Blazor.GraphQl.State.TankInfoResponseData>();
            foreach (global::System.Text.Json.JsonElement child in obj.Value.EnumerateArray())
            {
                tankInfoResponses.Add(DeserializeNonNullableIPlayer_AccountInfo_Tanks(child));
            }

            return tankInfoResponses;
        }

        private global::WotBlitzStatisticsPro.Blazor.GraphQl.State.TankInfoResponseData DeserializeNonNullableIPlayer_AccountInfo_Tanks(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            var typename = obj.Value.GetProperty("__typename").GetString();
            if (typename?.Equals("TankInfoResponse", global::System.StringComparison.Ordinal) ?? false)
            {
                return new global::WotBlitzStatisticsPro.Blazor.GraphQl.State.TankInfoResponseData(typename, tankId: DeserializeNonNullableInt64(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "tankId")), battleLifeTimeInSeconds: DeserializeNonNullableInt32(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "battleLifeTimeInSeconds")), lastBattleTime: DeserializeNonNullableDateTimeOffset(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "lastBattleTime")), markOfMastery: DeserializeNonNullableMarkOfMastery(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "markOfMastery")), battles: DeserializeNonNullableInt64(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "battles")), capturePoints: DeserializeNonNullableInt64(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "capturePoints")), damageDealt: DeserializeNonNullableInt64(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "damageDealt")), damageReceived: DeserializeNonNullableInt64(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "damageReceived")), droppedCapturePoints: DeserializeNonNullableInt64(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "droppedCapturePoints")), frags: DeserializeNonNullableInt64(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "frags")), frags8P: DeserializeNonNullableInt64(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "frags8P")), hits: DeserializeNonNullableInt64(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "hits")), losses: DeserializeNonNullableInt64(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "losses")), maxFrags: DeserializeNonNullableInt64(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "maxFrags")), maxXp: DeserializeNonNullableInt64(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "maxXp")), shots: DeserializeNonNullableInt64(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "shots")), spotted: DeserializeNonNullableInt64(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "spotted")), survivedBattles: DeserializeNonNullableInt64(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "survivedBattles")), winAndSurvived: DeserializeNonNullableInt64(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "winAndSurvived")), wins: DeserializeNonNullableInt64(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "wins")), xp: DeserializeNonNullableInt64(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "xp")), wn7: DeserializeNonNullableDouble(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "wn7")), winRate: DeserializeNonNullableDecimal(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "winRate")), avgDamage: DeserializeNonNullableDecimal(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "avgDamage")), avgXp: DeserializeNonNullableDecimal(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "avgXp")), damageCoefficient: DeserializeNonNullableDecimal(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "damageCoefficient")), survivalRate: DeserializeNonNullableDecimal(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "survivalRate")), avgBattleLifeTimeInMinutes: DeserializeNonNullableDecimal(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "avgBattleLifeTimeInMinutes")), name: DeserializeString(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "name")), tankNationId: DeserializeString(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "tankNationId")), tankNation: DeserializeString(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "tankNation")), tier: DeserializeNonNullableInt32(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "tier")), tankTypeId: DeserializeString(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "tankTypeId")), tankType: DeserializeString(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "tankType")), isPremium: DeserializeNonNullableBoolean(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "isPremium")), previewImage: DeserializeString(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "previewImage")), normalImage: DeserializeString(global::StrawberryShake.Json.JsonElementExtensions.GetPropertyOrNull(obj, "normalImage")));
            }

            throw new global::System.NotSupportedException();
        }

        private global::System.Int32 DeserializeNonNullableInt32(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            return _intParser.Parse(obj.Value.GetInt32()!);
        }

        private global::WotBlitzStatisticsPro.Blazor.GraphQl.MarkOfMastery DeserializeNonNullableMarkOfMastery(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            return _markOfMasteryParser.Parse(obj.Value.GetString()!);
        }

        private global::System.Boolean DeserializeNonNullableBoolean(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            return _booleanParser.Parse(obj.Value.GetBoolean()!);
        }
    }
}
