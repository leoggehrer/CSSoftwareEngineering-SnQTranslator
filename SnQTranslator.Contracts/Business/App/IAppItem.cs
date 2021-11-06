namespace SnQTranslator.Contracts.Business.App
{
    public interface IAppItem : IIdentifiable, ICopyable<IAppItem>
    {
        string Name { get; }
    }
}
