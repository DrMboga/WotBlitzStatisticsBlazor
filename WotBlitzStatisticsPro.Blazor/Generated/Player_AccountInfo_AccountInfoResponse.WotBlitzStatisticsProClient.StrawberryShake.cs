﻿// <auto-generated/>
#nullable enable

namespace WotBlitzStatisticsPro.Blazor.GraphQl
{
    /// <summary>
    /// Information about player
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.2.2.0")]
    public partial class Player_AccountInfo_AccountInfoResponse : global::System.IEquatable<Player_AccountInfo_AccountInfoResponse>, IPlayer_AccountInfo_AccountInfoResponse
    {
        public Player_AccountInfo_AccountInfoResponse(global::System.Int64 accountId, global::System.DateTimeOffset createdAt, global::System.String? nickname, global::System.Int64 maxFragsTankId, global::System.Int64 maxXpTankId, global::System.Double avgTier, global::System.DateTimeOffset lastBattleTime, global::System.Int64 battles, global::System.Int64 capturePoints, global::System.Int64 damageDealt, global::System.Int64 damageReceived, global::System.Int64 droppedCapturePoints, global::System.Int64 frags, global::System.Int64 frags8P, global::System.Int64 hits, global::System.Int64 losses, global::System.Int64 maxFrags, global::System.Int64 maxXp, global::System.Int64 shots, global::System.Int64 spotted, global::System.Int64 survivedBattles, global::System.Int64 winAndSurvived, global::System.Int64 wins, global::System.Int64 xp, global::System.Double wn7, global::System.Decimal winRate, global::System.Decimal avgDamage, global::System.Decimal avgXp, global::System.Decimal damageCoefficient, global::System.Decimal survivalRate, global::WotBlitzStatisticsPro.Blazor.GraphQl.IPlayer_AccountInfo_ClanInfo? clanInfo, global::System.Collections.Generic.IReadOnlyList<global::WotBlitzStatisticsPro.Blazor.GraphQl.IPlayer_AccountInfo_Tanks>? tanks)
        {
            AccountId = accountId;
            CreatedAt = createdAt;
            Nickname = nickname;
            MaxFragsTankId = maxFragsTankId;
            MaxXpTankId = maxXpTankId;
            AvgTier = avgTier;
            LastBattleTime = lastBattleTime;
            Battles = battles;
            CapturePoints = capturePoints;
            DamageDealt = damageDealt;
            DamageReceived = damageReceived;
            DroppedCapturePoints = droppedCapturePoints;
            Frags = frags;
            Frags8P = frags8P;
            Hits = hits;
            Losses = losses;
            MaxFrags = maxFrags;
            MaxXp = maxXp;
            Shots = shots;
            Spotted = spotted;
            SurvivedBattles = survivedBattles;
            WinAndSurvived = winAndSurvived;
            Wins = wins;
            Xp = xp;
            Wn7 = wn7;
            WinRate = winRate;
            AvgDamage = avgDamage;
            AvgXp = avgXp;
            DamageCoefficient = damageCoefficient;
            SurvivalRate = survivalRate;
            ClanInfo = clanInfo;
            Tanks = tanks;
        }

        /// <summary>
        /// Player account identifier
        /// </summary>
        public global::System.Int64 AccountId { get; }

        /// <summary>
        /// Account creation date
        /// </summary>
        public global::System.DateTimeOffset CreatedAt { get; }

        /// <summary>
        /// Player's nick
        /// </summary>
        public global::System.String? Nickname { get; }

        /// <summary>
        /// Tank id, which kills max frags per battle
        /// </summary>
        public global::System.Int64 MaxFragsTankId { get; }

        /// <summary>
        /// Tank Id which created max experience per battle
        /// </summary>
        public global::System.Int64 MaxXpTankId { get; }

        /// <summary>
        /// Average tier
        /// </summary>
        public global::System.Double AvgTier { get; }

        /// <summary>
        /// Last battle time
        /// </summary>
        public global::System.DateTimeOffset LastBattleTime { get; }

        /// <summary>
        /// Battles count
        /// </summary>
        public global::System.Int64 Battles { get; }

        /// <summary>
        /// Capture points
        /// </summary>
        public global::System.Int64 CapturePoints { get; }

        /// <summary>
        /// Total damage amount
        /// </summary>
        public global::System.Int64 DamageDealt { get; }

        /// <summary>
        /// Total amount of received damage
        /// </summary>
        public global::System.Int64 DamageReceived { get; }

        /// <summary>
        /// Dropped capture points
        /// </summary>
        public global::System.Int64 DroppedCapturePoints { get; }

        /// <summary>
        /// Total amount of frags
        /// </summary>
        public global::System.Int64 Frags { get; }

        /// <summary>
        /// Total amount of fras grater ten 8 lvl
        /// </summary>
        public global::System.Int64 Frags8P { get; }

        /// <summary>
        /// Total amount of hits
        /// </summary>
        public global::System.Int64 Hits { get; }

        /// <summary>
        /// Total amount of losses
        /// </summary>
        public global::System.Int64 Losses { get; }

        /// <summary>
        /// Max frags per battle
        /// </summary>
        public global::System.Int64 MaxFrags { get; }

        /// <summary>
        /// Max experience per battle
        /// </summary>
        public global::System.Int64 MaxXp { get; }

        /// <summary>
        /// Total shots count
        /// </summary>
        public global::System.Int64 Shots { get; }

        /// <summary>
        /// Total count of spotted vehicles
        /// </summary>
        public global::System.Int64 Spotted { get; }

        /// <summary>
        /// Total count of survived battles
        /// </summary>
        public global::System.Int64 SurvivedBattles { get; }

        /// <summary>
        /// Total count of survived and won battles
        /// </summary>
        public global::System.Int64 WinAndSurvived { get; }

        /// <summary>
        /// Total wins count
        /// </summary>
        public global::System.Int64 Wins { get; }

        /// <summary>
        /// Total amount of experience
        /// </summary>
        public global::System.Int64 Xp { get; }

        /// <summary>
        /// Wn7 coefficient
        /// </summary>
        public global::System.Double Wn7 { get; }

        /// <summary>
        /// Player's win rate
        /// </summary>
        public global::System.Decimal WinRate { get; }

        /// <summary>
        /// Player's average damage
        /// </summary>
        public global::System.Decimal AvgDamage { get; }

        /// <summary>
        /// Player's average XP
        /// </summary>
        public global::System.Decimal AvgXp { get; }

        /// <summary>
        /// Damage coefficient
        /// </summary>
        public global::System.Decimal DamageCoefficient { get; }

        /// <summary>
        /// Rate of survival
        /// </summary>
        public global::System.Decimal SurvivalRate { get; }

        /// <summary>
        /// Clan info
        /// </summary>
        public global::WotBlitzStatisticsPro.Blazor.GraphQl.IPlayer_AccountInfo_ClanInfo? ClanInfo { get; }

        /// <summary>
        /// All player's tanks
        /// </summary>
        public global::System.Collections.Generic.IReadOnlyList<global::WotBlitzStatisticsPro.Blazor.GraphQl.IPlayer_AccountInfo_Tanks>? Tanks { get; }

        public virtual global::System.Boolean Equals(Player_AccountInfo_AccountInfoResponse? other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (other.GetType() != GetType())
            {
                return false;
            }

            return (AccountId == other.AccountId) && CreatedAt.Equals(other.CreatedAt) && ((Nickname is null && other.Nickname is null) || Nickname != null && Nickname.Equals(other.Nickname)) && MaxFragsTankId == other.MaxFragsTankId && MaxXpTankId == other.MaxXpTankId && AvgTier == other.AvgTier && LastBattleTime.Equals(other.LastBattleTime) && Battles == other.Battles && CapturePoints == other.CapturePoints && DamageDealt == other.DamageDealt && DamageReceived == other.DamageReceived && DroppedCapturePoints == other.DroppedCapturePoints && Frags == other.Frags && Frags8P == other.Frags8P && Hits == other.Hits && Losses == other.Losses && MaxFrags == other.MaxFrags && MaxXp == other.MaxXp && Shots == other.Shots && Spotted == other.Spotted && SurvivedBattles == other.SurvivedBattles && WinAndSurvived == other.WinAndSurvived && Wins == other.Wins && Xp == other.Xp && Wn7 == other.Wn7 && WinRate == other.WinRate && AvgDamage == other.AvgDamage && AvgXp == other.AvgXp && DamageCoefficient == other.DamageCoefficient && SurvivalRate == other.SurvivalRate && ((ClanInfo is null && other.ClanInfo is null) || ClanInfo != null && ClanInfo.Equals(other.ClanInfo)) && global::StrawberryShake.Helper.ComparisonHelper.SequenceEqual(Tanks, other.Tanks);
        }

        public override global::System.Boolean Equals(global::System.Object? obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((Player_AccountInfo_AccountInfoResponse)obj);
        }

        public override global::System.Int32 GetHashCode()
        {
            unchecked
            {
                int hash = 5;
                hash ^= 397 * AccountId.GetHashCode();
                hash ^= 397 * CreatedAt.GetHashCode();
                if (Nickname != null)
                {
                    hash ^= 397 * Nickname.GetHashCode();
                }

                hash ^= 397 * MaxFragsTankId.GetHashCode();
                hash ^= 397 * MaxXpTankId.GetHashCode();
                hash ^= 397 * AvgTier.GetHashCode();
                hash ^= 397 * LastBattleTime.GetHashCode();
                hash ^= 397 * Battles.GetHashCode();
                hash ^= 397 * CapturePoints.GetHashCode();
                hash ^= 397 * DamageDealt.GetHashCode();
                hash ^= 397 * DamageReceived.GetHashCode();
                hash ^= 397 * DroppedCapturePoints.GetHashCode();
                hash ^= 397 * Frags.GetHashCode();
                hash ^= 397 * Frags8P.GetHashCode();
                hash ^= 397 * Hits.GetHashCode();
                hash ^= 397 * Losses.GetHashCode();
                hash ^= 397 * MaxFrags.GetHashCode();
                hash ^= 397 * MaxXp.GetHashCode();
                hash ^= 397 * Shots.GetHashCode();
                hash ^= 397 * Spotted.GetHashCode();
                hash ^= 397 * SurvivedBattles.GetHashCode();
                hash ^= 397 * WinAndSurvived.GetHashCode();
                hash ^= 397 * Wins.GetHashCode();
                hash ^= 397 * Xp.GetHashCode();
                hash ^= 397 * Wn7.GetHashCode();
                hash ^= 397 * WinRate.GetHashCode();
                hash ^= 397 * AvgDamage.GetHashCode();
                hash ^= 397 * AvgXp.GetHashCode();
                hash ^= 397 * DamageCoefficient.GetHashCode();
                hash ^= 397 * SurvivalRate.GetHashCode();
                if (ClanInfo != null)
                {
                    hash ^= 397 * ClanInfo.GetHashCode();
                }

                if (Tanks != null)
                {
                    foreach (var Tanks_elm in Tanks)
                    {
                        hash ^= 397 * Tanks_elm.GetHashCode();
                    }
                }

                return hash;
            }
        }
    }
}
