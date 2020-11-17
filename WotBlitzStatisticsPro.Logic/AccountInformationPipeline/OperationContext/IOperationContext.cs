namespace WotBlitzStatisticsPro.Logic.AccountInformationPipeline.OperationContext
{
    public interface IOperationContext
    {
        AccountRequest Request { get; }

        void AddOrReplace<TContextData>(TContextData data);

        TContextData Get<TContextData>();
    }
}