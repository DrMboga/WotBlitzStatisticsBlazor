using System;

namespace WotBlitzStatisticsPro.Logic.Model
{
    public class CacheItem<T>
    {
        private const int ExpirationTimeoutInMinutes = 60;
        private DateTime? _lastRefreshed = null;

        private T? _itemData = default(T);

        public long AccountId { get; set; }

        public bool IsExpired => _lastRefreshed != null &&
                                 (DateTime.Now - _lastRefreshed.Value).TotalMinutes > ExpirationTimeoutInMinutes;

        public T? Data
        {
            get => _itemData;
            set
            {
                _itemData = value;
                _lastRefreshed = DateTime.Now;

            }
        }
    }
}