using System.Collections.Generic;

namespace WotBlitzStatisticsPro.Logic.Model
{
    public class StatisticsCache
    {
        private readonly Dictionary<long, CacheItem<AccountDataCache>> _accountsCache = new();
        private readonly Dictionary<long, CacheItem<TanksDataCache>> _tanksCache = new();

        public AccountDataCache? GetAccountData(long accountId)
        {
            if (!_accountsCache.ContainsKey(accountId) || _accountsCache[accountId].IsExpired)
            {
                return null;
            }

            return _accountsCache[accountId].Data;
        }

        public TanksDataCache? GetTanksData(long accountId)
        {
            if (!_tanksCache.ContainsKey(accountId) || _tanksCache[accountId].IsExpired)
            {
                return null;
            }

            return _tanksCache[accountId].Data;
        }

        public void SetAccountData(long accountId, AccountDataCache data)
        {
            if (!_accountsCache.ContainsKey(accountId))
            {
                _accountsCache.Add(accountId, new CacheItem<AccountDataCache>());
                ClearExpiredAccounts();
            }
            _accountsCache[accountId].Data = data;
        }

        public void SetTanksData(long accountId, TanksDataCache data)
        {
            if (!_tanksCache.ContainsKey(accountId))
            {
                _tanksCache.Add(accountId, new CacheItem<TanksDataCache>());
                ClearExpiredTanks();
            }
            _tanksCache[accountId].Data = data;
        }

        private void ClearExpiredAccounts()
        {
            var expired = new List<long>();
            foreach (var cacheItem in _accountsCache)
            {
                if (cacheItem.Value.IsExpired)
                {
                    expired.Add(cacheItem.Key);
                }
            }

            foreach (var expiredKey in expired)
            {
                _accountsCache.Remove(expiredKey);
            }
        }

        private void ClearExpiredTanks()
        {
            var expired = new List<long>();
            foreach (var cacheItem in _tanksCache)
            {
                if (cacheItem.Value.IsExpired)
                {
                    expired.Add(cacheItem.Key);
                }
            }

            foreach (var expiredKey in expired)
            {
                _accountsCache.Remove(expiredKey);
            }
        }
    }
}