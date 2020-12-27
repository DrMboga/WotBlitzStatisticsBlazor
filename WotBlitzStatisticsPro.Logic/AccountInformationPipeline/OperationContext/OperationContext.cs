namespace WotBlitzStatisticsPro.Logic.AccountInformationPipeline.OperationContext
{
    public class OperationContext : IOperationContext
    {
        private object? _contextData;


        public OperationContext(AccountRequest request)
        {
            Request = request;
        }

        public AccountRequest Request { get; }

        public void AddOrReplace<TContextData>(TContextData data)
        {
            _contextData = data;
        }

        public TContextData Get<TContextData>()
        {
            _contextData ??= default(TContextData);

            return (TContextData)_contextData!;
        }
    }
}