namespace WotBlitzStatisticsPro.Common.Model
{
    /// <summary>
    /// Represents the difference of one statistics parameter
    /// </summary>
    public class StatisticsDifferenceItem<T> where T: struct
    {
        /// <summary>
        /// The current value of statistics item
        /// </summary>
        public T CurrentValue { get; set; }

        /// <summary>
        /// The difference between current and previous value
        /// </summary>
        public T? Difference { get; set; }
    }
}